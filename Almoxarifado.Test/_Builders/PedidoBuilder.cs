namespace Almoxarifado.Test._Builders;
using Almoxarifado.Domain.Entities;

public class PedidoBuilder
{
   private string _titulo = "Pedido de teste";
   private string _descricao = "Pedido de teste";
   private Colaborador _autor = ColaboradorBuilder.Novo().Criar();
   private Produto _produto = ProdutoBuilder.Novo().Criar();

   public static PedidoBuilder Novo()
       => new PedidoBuilder();

   public Pedido Criar()
       => new Pedido(_titulo, _descricao, _autor, _produto);

   public PedidoBuilder ComTitulo(string titulo)
   {
      _titulo = titulo;
      
      return this;
   }

   public PedidoBuilder ComDescricao(string descricao)
   {
      _descricao = descricao;

      return this;
   }

   public PedidoBuilder ComAutor(Colaborador autor)
   {
      _autor = autor;

      return this;
   }

   public PedidoBuilder ComProduto(Produto produto)
   {
      _produto = produto;

      return this;
   }
}