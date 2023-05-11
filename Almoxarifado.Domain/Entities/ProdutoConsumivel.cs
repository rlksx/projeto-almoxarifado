namespace Almoxarifado.Domain.Entities;

public class ProdutoConsumivel : Produto
{
   public DateTime Validade { get; private set; }
   public bool ValidadeStatus => Validade < DateTime.Now;

   public ProdutoConsumivel(string nome, double valor, string descricao, int validadeEmDias) 
   : base(nome, valor, descricao)
      => Validade = DateTime.Now.AddDays(validadeEmDias);
}