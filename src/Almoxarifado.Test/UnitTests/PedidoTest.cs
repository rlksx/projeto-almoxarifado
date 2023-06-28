namespace Almoxarifado.Test;

public class PedidoTest
{

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void dado_um_novo_solicitacao_titulo_dele_ser_valido(string _titulo)
    {
        Assert.Throws<ArgumentException>(() => PedidoBuilder.Novo().ComTitulo(_titulo).Criar())
           .Message.Equals("Titulo invalido");
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void dado_um_novo_solicitacao_descricao_dele_ser_valido(string _descricao)
    {
        Assert.Throws<ArgumentException>(() => PedidoBuilder.Novo().ComDescricao(_descricao).Criar())
           .Message.Equals("Descricao invalido");
    }

    [Fact]
    public void dado_um_novo_solicitacao_colaborador_dele_ser_valido()
    {
        Assert.Throws<ArgumentException>(() => PedidoBuilder.Novo().ComAutor(null).Criar())
           .Message.Equals("Colaborador invalido");
    }

    [Fact]
    public void dado_um_novo_solicitacao_produto_dele_ser_valido()
    {
        Assert.Throws<ArgumentException>(() => PedidoBuilder.Novo().ComProduto(null).Criar())
           .Message.Equals("Produto invalido");
    }

    [Fact]
    public void dado_uma_nova_solicitacao_status_deve_ser_false()
        => Assert.Equal(false, PedidoBuilder.Novo().Criar().Status);

}
