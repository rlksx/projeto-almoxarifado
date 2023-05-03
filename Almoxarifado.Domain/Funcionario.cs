namespace Almoxarifado.Domain;
public class Funcionario
{
   public string Nome { get; private set; }
   public string Codigo { get; private set; } = gerarCodigo();
   public TipoFuncionario Cargo { get; private set; }
   public Funcionario(string nome, string codigo, TipoFuncionario cargo)
   {
      Nome = nome;
      Codigo = codigo;
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
