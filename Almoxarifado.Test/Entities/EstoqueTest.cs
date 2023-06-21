namespace Almoxarifado.Test;

using Almoxarifado.Domain.Entities;

public class EstoqueTest
{
   [Fact]
   public void dado_um_novo_estoque_deve_gerar_uma_lista_de_produto()
   {
      // instancia singleton
      Assert.NotNull(Estoque.Produtos);
   }

   [Fact]
   public void dado_um_estoque_existente_deve_retornar_o_mesmo_estoque()
   {
      var estoque = Estoque.PegarEstoque();
      estoque.AdicionarProduto(new Produto("Produto 1", 10, "Descrição 1"));

      var estoque2 = Estoque.PegarEstoque();
      Assert.Equal(estoque, estoque2);
   }
}
