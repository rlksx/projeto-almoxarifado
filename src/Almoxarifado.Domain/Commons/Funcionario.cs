namespace Almoxarifado.Domain.Commons;
public abstract class Funcionario
{
    public string Nome { get; private set; }
    public string Senha { get; private set; }
    public int Telefone { get; private set; }
    public int Cpf { get; private set; }
    public string Matricula { get; set; }

    public Funcionario(string nome, string senha, int telefone, int cpf)
    {
        if (String.IsNullOrEmpty(nome)) throw new ArgumentException("Senha invalida");
        if (String.IsNullOrEmpty(senha)) throw new ArgumentException("Nome invalido");
        if (telefone <= 0) throw new ArgumentException("Telefone invalido");
        if (cpf <= 0) throw new ArgumentException("Cpf invalido");

        Nome = nome;
        Telefone = telefone;
        Senha = senha;
        Cpf = cpf;
        Matricula = GerarMatricula();
    }

    private string GerarMatricula()
    {
        // string pois é mlr de testar;  
        string matricula = string.Empty;
        var rndNumero = new Random();
        for (int i = 0; i < 8; i++)
            matricula += rndNumero.Next(0, 9).ToString();

        return matricula;
    }
}
