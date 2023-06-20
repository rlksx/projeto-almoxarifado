
namespace Almoxarifado.Test._Builders;
using Almoxarifado.Domain.Entities;

public class ColaboradorBuilder
{
   private string _nome = "Mark Zukerberg";
   private string _senha = "1029384756";
   private int _telefone = 47991522;
   private int _cpf = 48294482;
   private string _matricula = "012D2B321A";


    public static ColaboradorBuilder Novo()
        => new ColaboradorBuilder();

    public Colaborador Criar()
        => new Almoxarifado(_nome, _senha, _telefone, _cpf);

    public ColaboradorBuilder ComNome(string nome)
        => this._nome= nome;

    public ColaboradorBuilder ComSenha(string senha)
        => this._senha = senha;

    public Almoxarifado ComTelefone(int telefone)
        => this._telefone = telefone;

    public Almoxarifado ComCpf(int cpf)
        => this._cpf = cpf;
    
    public Almoxarifado ComMatricula(string matricula)
        => this._matricula = matricula;
}
