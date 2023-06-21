namespace Almoxarifado.Test;

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
      estoque.AdicionarProduto(ProdutoBuilder.Novo().Criar());

      var estoque2 = Estoque.PegarEstoque();
      Assert.Equal(estoque, estoque2);
   }
}
