namespace Almoxarifado.Domain.Entities;

public class ProdutoConsumivel : Produto
{
   public DateTime Validade { get; private set; }
   public bool ProdutoVencido  => Validade < DateTime.Now; 

   public ProdutoConsumivel(string nome, double valor, string descricao, int validadeEmDias) 
   : base(nome, valor, descricao) 
   {
      // validade minima para venda de 30 dias
      if(validadeEmDias < 30) throw new ArgumentException("Validade minima deve ser de 30 dias");
      Validade = DateTime.Now.AddDays(validadeEmDias);
   }
}
