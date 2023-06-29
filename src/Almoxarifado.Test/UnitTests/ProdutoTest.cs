namespace Almoxarifado.Test;

public class ProdutoTest
{
    // testando novo produto
    private readonly Produto _produto;
    public ProdutoTest()
        => _produto = ProdutoBuilder.Novo().Criar();


    [Fact]
    public void dado_um_novo_produto_valido_data_de_insercao_deve_ser_igual_a_data_atual()
        => Assert.Equal(DateTime.UtcNow.Date, _produto.DataDeInsercao.Date);

    [Fact]
    public void dado_um_novo_produto_valido_data_de_alteracao_deve_ser_igual_a_data_atual()
        => Assert.Equal(DateTime.UtcNow.Date, _produto.DataDeAlteracao.Date);

    [Fact]
    public void dado_um_novo_produto_valido_status_deve_ser_false()
        => Assert.False(_produto.Status);

    [Fact]
    public void dado_um_novo_produto_valido_gerar_cod_com_8_caracteres()
        => Assert.Equal(8, _produto.Codigo.Length);

    [Fact]
    public void dado_um_novo_produto_valido_gerar_com_0_unidades()
        => Assert.Equal(0, _produto.Unidades);

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void dado_um_novo_produto_com_valor_menor_ou_igual_a_zero_nao_deve_ser_adicionado(double _valor)
    {
        Assert.Throws<ArgumentException>(() => ProdutoBuilder.Novo().ComValor(_valor).Criar())
           .Message.Equals("Valor deve ser maior que zero");
    }


    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void dado_um_novo_produto_descricao_pode_ser_vazia(string _descricao)
    {
        Assert.Throws<ArgumentException>(() => ProdutoBuilder.Novo().ComDescricao(_descricao).Criar())
           .Message.Equals("Descrição não pode ser vazia");
    }


    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void dado_um_novo_produto_nome_nao_deve_ser_vazio(string _nome)
    {
        Assert.Throws<ArgumentException>(() => ProdutoBuilder.Novo().ComNome(_nome).Criar())
           .Message.Equals("Nome não pode ser vazio");
    }

    // testando produto
    [Fact]
    public void ao_adicionar_10_unidades_de_um_produto_deve_haver_10_unidades()
    {
        _produto.AdicionarUnidades(10);
        Assert.Equal(10, _produto.Unidades);
    }

    [Fact]
    public void ao_remover_5_unidades_de_um_produto_com_10_deve_haver_5_unidades()
    {
        _produto.AdicionarUnidades(10);
        _produto.RemoverUnidades(5);
        Assert.Equal(5, _produto.Unidades);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void ao_adicionar_unidades_de_produto_unidades_deve_ser_maior_que_0(int _unidades)
    {
        Assert.Throws<ArgumentException>(() => _produto.AdicionarUnidades(_unidades))
           .Message.Equals("Unidades deve ser maior que zero");
    }

    [Fact]
    public void ao_remover_unidades_de_produto_produto_deve_ter_mais_ou_igual_unidades()
    {
        _produto.AdicionarUnidades(10);
        Assert.Throws<ArgumentException>(() => _produto.RemoverUnidades(11))
           .Message.Equals("Produto não tem unidades suficientes");
    }


    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void ao_remover_produto_produto_adicionar_unidades_deve_ser_maior_que_0(int _unidades)
    {
        Assert.Throws<ArgumentException>(() => _produto.RemoverUnidades(_unidades))
           .Message.Equals("Unidades deve ser maior que zero");
    }
}
