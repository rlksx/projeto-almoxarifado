namespace Almoxarifado.Domain.Entities;
public class Pedido
{
   public string Titulo { get; private set; }
   public string Descricao { get; private set; }
   public Colaborador Autor { get; private set; }
   public bool Status { get; private set; }
   public Produto? Produto { get; private set; }
   public ProdutoConsumivel? ProdutoConsumivel { get; private set; }


   public Pedido(string titulo, string descricao, Colaborador autor, Produto produto)
   {
      if (string.IsNullOrEmpty(titulo)) throw new ArgumentException("Titulo invalido");
      if (string.IsNullOrEmpty(descricao)) throw new ArgumentException("Descricao invalida");
      if (produto == null) throw new ArgumentException("Produto invalido");
      if (autor == null) throw new ArgumentException("Colaborador invalido");

      Titulo = titulo;
      Descricao = descricao;
      Autor = autor;
      Produto = produto;
      Autor = autor;
      Status = false;
   }

   public Pedido(string titulo, string descricao, Colaborador autor, ProdutoConsumivel produto)
   {
      if (string.IsNullOrEmpty(titulo)) throw new ArgumentException("Titulo invalido");
      if (string.IsNullOrEmpty(descricao)) throw new ArgumentException("Descricao invalida");
      if (produto == null) throw new ArgumentException("Produto invalido");
      if (autor == null) throw new ArgumentException("Autor invalido");

      Titulo = titulo;
      Descricao = descricao;
      Autor = autor;
      ProdutoConsumivel = produto;
      Autor = autor;
      Status = false;
   }

   public void AtualizarStatus()
   {
      Status = !Status;
   }
}
