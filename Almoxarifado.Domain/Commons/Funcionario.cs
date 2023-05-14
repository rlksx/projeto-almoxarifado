namespace Almoxarifado.Domain.Commons;
public abstract class Funcionario
{
   public string Nome { get; private set; }
   public string Senha { get; private set; }
   public int Telefone { get; private set; }
   public int Cpf { get; private set; }

   public Funcionario(string nome, string senha, int telefone, int cpf)
   {
      if(String.IsNullOrEmpty(nome)) throw new ArgumentException("Senha invalida");
      if(String.IsNullOrEmpty(senha)) throw new ArgumentException("Nome invalido");

      Nome = nome;
      Telefone = telefone;
      Senha = senha;
      Cpf = cpf;
   }
}
