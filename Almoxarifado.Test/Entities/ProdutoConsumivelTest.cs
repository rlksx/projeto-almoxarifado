namespace Almoxarifado.Test;

using Almoxarifado.Domain.Entities;

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
   [Theory]
   [InlineData(0)]
   [InlineData(-1)]
   public void ao_adicionar_unidades_de_produto_unidades_deve_ser_maior_que_0(int _unidades)
   {
      var produtoConsumivel = new ProdutoConsumivel("item", 200, "descricao", 120);
      Assert.Throws<ArgumentException>(() => produtoConsumivel.AdicionarUnidades(_unidades))
         .Message.Equals("Unidades deve ser maior que zero");
   }

   [Fact]
   public void ao_remover_unidades_de_produto_produto_deve_ter_mais_ou_igual_unidades()
   {
      var produtoConsumivel = new ProdutoConsumivel("item", 200, "descricao", 120);
      produtoConsumivel.AdicionarUnidades(10);
      Assert.Throws<ArgumentException>(() => produtoConsumivel.RemoverUnidades(11))
         .Message.Equals("Produto não tem unidades suficientes");
   }


   [Theory]
   [InlineData(0)]
   [InlineData(-1)]
   public void ao_remover_unidades_unidades_deve_ver_maior_que_0(int _unidades)
   {
      var produto = new ProdutoConsumivel("item", 200, "descricao", 120);
      Assert.Throws<ArgumentException>(() => produto.RemoverUnidades(_unidades))
         .Message.Equals("Unidades deve ser maior que zero");
   }

   [Fact]
   public void ao_adicionar_10_unidades_de_um_produto_consumivel_deve_haver_10_unidades()
   {
      var produtoConsumivel = new ProdutoConsumivel("item", 200, "descricao", 120);
      produtoConsumivel.AdicionarUnidades(10);
      Assert.Equal(10, produtoConsumivel.Unidades);
   }

   [Fact]
   public void ao_remover_5_unidades_de_um_produto_consumivel_com_10_deve_haver_5_unidades()
   {
      var produtoConsumivel = new ProdutoConsumivel("item", 200, "descricao", 60);
      produtoConsumivel.AdicionarUnidades(10);
      produtoConsumivel.RemoverUnidades(5);
      Assert.Equal(5, produtoConsumivel.Unidades);
   }
}
