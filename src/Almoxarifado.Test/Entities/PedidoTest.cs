namespace Almoxarifado.Test;

public class PedidoTest
{
    private static Colaborador? _colaborador;
    private static Produto? _produto;

    public PedidoTest()
    {
        _produto = new Produto("item", 200, "descricao");

        _colaborador = new Colaborador("nome", "1413412", 47000, 1231221321, TipoColaborador.Interno, CargoColaborador.Suporte);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void dado_um_novo_solicitacao_titulo_dele_ser_valido(string _titulo)
    {
        Assert.Throws<ArgumentException>(() => new Pedido(_titulo, "descricao", _colaborador, _produto))
           .Message.Equals("Titulo invalido");
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void dado_um_novo_solicitacao_descricao_dele_ser_valido(string _descricao)
    {
        Assert.Throws<ArgumentException>(() => new Pedido("titulo", _descricao, _colaborador, _produto))
           .Message.Equals("Descricao invalido");
    }

    [Fact]
    public void dado_um_novo_solicitacao_colaborador_dele_ser_valido()
    {
        Assert.Throws<ArgumentException>(() => new Pedido("titulo", "descricao", null, _produto))
           .Message.Equals("Colaborador invalido");
    }

    [Fact]
    public void dado_um_novo_solicitacao_produto_dele_ser_valido()
    {
        Assert.Throws<ArgumentException>(() => new Pedido("titulo", "descricao", _colaborador, null))
           .Message.Equals("Produto invalido");
    }

    [Fact]
    public void dado_uma_nova_solicitacao_status_deve_ser_false()
    {
        var pedido = new Pedido("titulo", "descricao", _colaborador, _produto);
        Assert.Equal(false, pedido.Status);
    }
}
