namespace Almoxarifado.Domain.Commons;
public abstract class Funcionario
{
   public string Nome { get; private set; }
   public string Senha { get; private set; }
   public int Telefone { get; private set; }

   public Funcionario(string nome, string senha, int telefone)
   {
      Nome = nome;
      Telefone = telefone;
      Senha = senha;
   }
}
