namespace Almoxarifado.Domain;

public class Produto
{
   public string Item { get; private set; }
   public string Descricao { get; private set; }
   public double Quantidade { get; private set; }

   public Produto(string item, string descricao, double quantidade)
   {
      Item = item;
      Descricao = descricao;
      Quantidade = quantidade;
   }

   public void AdicionarItem(double quantidade, Funcionario funcionario)
   {
      if (funcionario.Cargo != TipoFuncionario.Almoxarife)
         throw new Exception("Solicite ao Almoxarife para adicionar o item!");
      if (quantidade <= 0)
         throw new Exception("A quantidade deve ser maior que zero!");

      Quantidade += quantidade;
   }
}
