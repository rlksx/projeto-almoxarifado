namespace Almoxarifado.Domain.Entities;

public class Estoque
{
   // usando siingleton para garantir que só exista um estoque
   private static Estoque? Singleton = null;
   public static List<Produto>? Produtos { get; private set; }

   private Estoque() => Produtos = new List<Produto>();

   public static Estoque PegarEstoque()
   {
      if (Singleton == null)
      {
         Singleton = new Estoque();
      }

      return Singleton;
   }

   public void AdicionarProduto(Produto produto) => Produtos.Add(produto);
}