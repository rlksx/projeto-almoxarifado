namespace Almoxarifado.Domain.Entities;

public class Produto
{
   public string Nome { get; private set; }
   public string Descricao { get; private set; }
   public int Unidades { get; private set; } = 0;
   public double Valor { get; private set; }
   public string Codigo { get; private set; }

   public Produto(string nome, double valor, string descricao)
   {
      if(String.IsNullOrEmpty(nome)) throw new ArgumentException("Nome não pode ser vazio");
      if(valor <= 0) throw new ArgumentException("Valor pode ser maior que zero");
      if(String.IsNullOrEmpty(descricao)) throw new ArgumentException("Descrição não pode ser vazia");

      Nome = nome;
      Descricao = descricao;
      Valor = valor;
      Codigo = Guid.NewGuid().ToString().Substring(0, 8);
   }

   // unidades seram adicionadas automaticamente apos o pedido?
   public void AdicionarUnidades(int unidades) 
   {
      
   }
}
