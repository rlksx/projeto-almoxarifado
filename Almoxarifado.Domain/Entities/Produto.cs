namespace Almoxarifado.Domain.Entities;
using Almoxarifado.Domain.Enums;

public class Produto
{
   public string Nome { get; private set; }
   public string Descricao { get; private set; }
   public int Unidades { get; private set; } = 0;
   public double Valor { get; private set; }
   public string Codigo { get; private set; }

   public Produto(string nome, double valor, string descricao)
   {
      if(String.IsNullOrEmpty(nome)) throw new Exception("Nome não deve ser vazio");
      if(valor <= 0) throw new Exception("Valor do produto não pode ser menor ou igual a zero");
      if(String.IsNullOrEmpty(descricao)) throw new Exception("Descrição não pode ser vazia");

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
