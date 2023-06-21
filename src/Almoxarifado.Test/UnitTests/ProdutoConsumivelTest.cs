namespace Almoxarifado.Test;

public class ProdutoConsumivelTest
{
    // testando novo produto consumivel
    private static ProdutoConsumivel _produtoConsumivel;
    public ProdutoConsumivelTest()
        => _produtoConsumivel = ProdutoConsumivelBuilder.Novo().Criar();

    [Fact]
    public void dado_um_novo_produto_valido_data_de_insercao_deve_ser_igual_a_data_atual()
        => Assert.Equal(DateTime.UtcNow.Date, _produtoConsumivel.DataDeInsercao.Date);
    

    [Fact]
    public void dado_um_novo_produto_valido_data_de_alteracao_deve_ser_igual_a_data_atual()
        => Assert.Equal(DateTime.UtcNow.Date, _produtoConsumivel.DataDeAlteracao.Date);
    

    [Fact]
    public void dado_um_novo_produto_valido_status_deve_ser_false()
        => Assert.False(_produtoConsumivel.Status);
    

    [Fact]
    public void dado_um_novo_produto_consumivel_validade_minima_de_30_dias()
    {
        Assert.Throws<ArgumentException>(() => ProdutoConsumivelBuilder.Novo().ComValidade(3).Criar())
           .Message.Equals("Validade minima deve ser de 30 dias");
    }

    [Fact]
    public void dado_um_novo_produto_consumivel_valido_gerar_cod_com_8_caracteres()
        => Assert.Equal(8, _produtoConsumivel.Codigo.Length);
    


    [Fact]
    public void dado_um_novo_produto_consumivel_valido_gerar_com_0_unidades()
        => Assert.Equal(0, _produtoConsumivel.Unidades);
    


    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void dado_um_novo_produto_consumivel_com_valor_menor_ou_igual_a_zero_nao_deve_ser_adicionado(double _valor)
    {
        Assert.Throws<ArgumentException>(() => ProdutoConsumivelBuilder.Novo().ComValor(_valor).Criar())
           .Message.Equals("Valor pode ser maior que zero");
    }


    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void dado_um_novo_produto_consumivel_descricao_pode_ser_vazia(string _descricao)
    {
        Assert.Throws<ArgumentException>(() => ProdutoConsumivelBuilder.Novo().ComDescricao(_descricao).Criar())
           .Message.Equals("Descrição não pode ser vazia");
    }


    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void dado_um_novo_produto_consumivel_nome_nao_deve_ser_vazio(string _nome)
    {
        Assert.Throws<ArgumentException>(() => ProdutoConsumivelBuilder.Novo().ComNome(_nome).Criar())
           .Message.Equals("Nome não pode ser vazio");
    }

    // testando produto consumivel
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void ao_adicionar_unidades_de_produto_unidades_deve_ser_maior_que_0(int _unidades)
    {
        Assert.Throws<ArgumentException>(() => _produtoConsumivel.AdicionarUnidades(_unidades))
           .Message.Equals("Unidades deve ser maior que zero");
    }

    [Fact]
    public void ao_remover_unidades_de_produto_produto_deve_ter_mais_ou_igual_unidades()
    {
        Assert.Throws<ArgumentException>(() => _produtoConsumivel.RemoverUnidades(11))
           .Message.Equals("Produto não tem unidades suficientes");
    }


    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void ao_remover_unidades_unidades_deve_ver_maior_que_0(int _unidades)
    {
        Assert.Throws<ArgumentException>(() => _produtoConsumivel.RemoverUnidades(_unidades))
           .Message.Equals("Unidades deve ser maior que zero");
    }

    [Fact]
    public void ao_adicionar_10_unidades_de_um_produto_consumivel_deve_haver_10_unidades()
    {
        _produtoConsumivel.AdicionarUnidades(10);
        Assert.Equal(10, _produtoConsumivel.Unidades);
    }

    [Fact]
    public void ao_remover_5_unidades_de_um_produto_consumivel_com_10_deve_haver_5_unidades()
    {
        _produtoConsumivel.AdicionarUnidades(10);
        _produtoConsumivel.RemoverUnidades(5);
        Assert.Equal(5, _produtoConsumivel.Unidades);
    }
}
