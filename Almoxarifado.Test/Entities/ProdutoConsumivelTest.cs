namespace Almoxarifado.Test;
using Almoxarifado.Domain.Entities;
using Xunit;

public class ProdutoConsumivelTest
{
   // testando novo produto consumivel
   [Fact]
   public void dado_um_novo_produto_valido_data_de_insercao_deve_ser_igual_a_data_atual()
   {
      var produto = new Produto("item", 200, "descricao");
      Assert.Equal(DateTime.UtcNow.Date, produto.DataDeInsercao.Date);
   }

   [Fact]
   public void dado_um_novo_produto_valido_data_de_alteracao_deve_ser_igual_a_data_atual()
   {
      var produto = new Produto("item", 200, "descricao");
      Assert.Equal(DateTime.UtcNow.Date, produto.DataDeAlteracao.Date);
   }

   [Fact]
   public void dado_um_novo_produto_valido_status_deve_ser_false()
   {
      var produto = new Produto("item", 200, "descricao");
      Assert.False(produto.Status);
   }

   [Fact]
   public void dado_um_novo_produto_consumivel_validade_minima_de_30_dias()
   {
      Assert.Throws<ArgumentException>(() => new ProdutoConsumivel("nome", 100, "descrição", 10))
         .Message.Equals("Validade minima deve ser de 30 dias");
   }

   [Fact]
   public void dado_um_novo_produto_consumivel_valido_gerar_cod_com_8_caracteres()
   {
      var produto = new ProdutoConsumivel("item", 200, "descricao", 54);
      Assert.Equal(8, produto.Codigo.Length);
   } 
   

   [Fact]
   public void dado_um_novo_produto_consumivel_valido_gerar_com_0_unidades()
   {
      var produto = new ProdutoConsumivel("item", 200, "descricao", 220);
      Assert.Equal(0, produto.Unidades);
   }
   

   [Theory]
   [InlineData(0)]
   [InlineData(-1)]
   public void dado_um_novo_produto_consumivel_com_valor_menor_ou_igual_a_zero_nao_deve_ser_adicionado(double _valor)
   {
      Assert.Throws<ArgumentException>(() => new ProdutoConsumivel("item", _valor, "descricao", 60))
         .Message.Equals("Valor pode ser maior que zero");
   } 
   

   [Theory]
   [InlineData("")]
   [InlineData(null)]
   public void dado_um_novo_produto_consumivel_descricao_pode_ser_vazia(string _descricao)
   {
      Assert.Throws<ArgumentException>(() => new ProdutoConsumivel("item", 200, _descricao, 128))
         .Message.Equals("Descrição não pode ser vazia");
   }
   

   [Theory]
   [InlineData("")]
   [InlineData(null)]
   public void dado_um_novo_produto_consumivel_nome_nao_deve_ser_vazio(string _nome)
   {
      Assert.Throws<ArgumentException>(() => new ProdutoConsumivel(_nome, 200, "descricao", 30))
         .Message.Equals("Nome não pode ser vazio");
   }

   // testando produto consumivel
}
