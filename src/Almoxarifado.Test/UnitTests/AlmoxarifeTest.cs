namespace Almoxarifado.Test;

public class AlmoxarifeTest
{
    private static Almoxarife _almoxarife;
    private static Produto _produto;

    public AlmoxarifeTest()
    {
        _almoxarife = AlmoxarifeBuilder.Novo().Criar();
        _produto = ProdutoBuilder.Novo().Criar();
    }


    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void dado_um_novo_almoxarife_cpf_deve_ser_maior_que_0(int _cpf)
    {
        Assert.Throws<ArgumentException>(() => AlmoxarifeBuilder.Novo().ComCpf(_cpf).Criar())
            .Message.Equals("Cpf invalido");
    }


    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void dado_um_novo_almoxarife_telefone_deve_ser_maior_que_0(int _telefone)
    {
        Assert.Throws<ArgumentException>(() => AlmoxarifeBuilder.Novo().ComTelefone(_telefone).Criar())
            .Message.Equals("Telefone invalido");
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void dado_um_novo_almoxarife_senha_nao_deve_ser_vazia(string _senha)
    {
        Assert.Throws<ArgumentException>(() => AlmoxarifeBuilder.Novo().ComSenha(_senha).Criar())
            .Message.Equals("Senha invalida");
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void dado_um_novo_almoxarife_nome_nao_deve_ser_vazia(string _nome)
    {
        Assert.Throws<ArgumentException>(() => AlmoxarifeBuilder.Novo().ComNome(_nome).Criar())
           .Message.Equals("Nome invalido");
    }

    [Fact]
    public void dado_um_novo_almoxarife_valido_gerar_matricula()
        => Assert.False(string.IsNullOrEmpty(_almoxarife.Matricula));

    [Fact]
    public void dado_um_almoxarife_valido_matricula_deve_ter_8_caracter()
       => Assert.Equal(8, _almoxarife.Matricula.Length);

    // test pedidos
    [Fact]
    public void almoxarife_cadastrar_novo_produto()
    {
        var pedido = PedidoBuilder.Novo().Criar();
        _almoxarife.CadastrarNovoProduto(pedido);

        Assert.True(Estoque.Produtos.Count() != 0);
    }

    [Fact]
    public void ao_remover_unidades_de_produto_produto_deve_ser_valido()
    {
        Assert.Throws<ArgumentException>(() => _almoxarife.AdicionarUnidadesDeProduto(null, 100))
           .Message.Equals("Produto invalido");
    }

    [Fact]
    public void ao_adicionar_produto_produto_deve_ser_valido()
    {
        Assert.Throws<ArgumentException>(() => _almoxarife.RemoverUnidadesDeProduto(null, 100))
           .Message.Equals("Produto invalido");
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void ao_adicionar_produto_unidades_deve_ser_maior_que_0(int _unidades)
    {
        Assert.Throws<ArgumentException>(() => _almoxarife.AdicionarUnidadesDeProduto(_produto, _unidades))
           .Message.Equals("Unidades deve ser maior que zero");
    }


    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void ao_remover_produto_unidades_deve_ser_maior_que_0(int _unidades)
    {
        Assert.Throws<ArgumentException>(() => _almoxarife.RemoverUnidadesDeProduto(_produto, _unidades))
           .Message.Equals("Unidades deve ser maior que zero");
    }

    [Fact]
    public void ao_remover_unidades_produto_deve_conter_mais_ou_igual_unidades()
    {
        _produto.AdicionarUnidades(10);
        Assert.Throws<ArgumentException>(() => _almoxarife.RemoverUnidadesDeProduto(_produto, 11))
           .Message.Equals("Não é possivel remover mais unidades do que existem");
    }

    [Fact]
    public void ao_registrar_novo_colaborador_retornar_o_mesmo()
    {
        var novoColaborador = _almoxarife.CadastrarNovoColaborador("nome", "senha", 472423, 0193748925, Domain.Enums.TipoColaborador.Externo, CargoColaborador.Suporte);

        var Colaborador = new Colaborador("nome", "senha", 472423, 0193748925, Domain.Enums.TipoColaborador.Externo, CargoColaborador.Suporte);

        Object.Equals(novoColaborador, Colaborador);
    }
}