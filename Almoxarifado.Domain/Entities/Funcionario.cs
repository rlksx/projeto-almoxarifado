namespace Almoxarifado.Domain.Entities;
using Almoxarifado.Domain.Enums;
public class Funcionario
{
   public string Nome { get; private set; }
   public TipoFuncionario Cargo { get; private set; }
   public string Codigo { get; private set; } = gerarCodigo();

   public Funcionario(string nome, TipoFuncionario cargo)
   {
      Nome = nome;
      Cargo = cargo;
   }

   // gerar codifo aleatorio
   private static string gerarCodigo()
   {
      string codigo = "";
      for (int i = 0; i < 6; i++)
         codigo += new Random().Next(0, 9).ToString();
      
      return codigo;
   }
}
