namespace Almoxarifado.Domain.Entities;

public class ProdutoConsumivel : Produto
{
   public DateTime Validade { get; private set; }
   public bool ValidadeStatus => Validade < DateTime.Now.AddDays(30); // validade minima para venda de 30 dias

   public ProdutoConsumivel(string nome, double valor, string descricao, int validadeEmDias) 
   : base(nome, valor, descricao) 
   {
      if(validadeEmDias < 30) throw new Exception("Validade minima de 30 dias");
      Validade = DateTime.Now.AddDays(validadeEmDias);
   }
}
