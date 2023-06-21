
namespace Almoxarifado.Test._Builders;
using Almoxarifado.Domain.Entities;

public class AlmoxarifeBuilder
{
   private string _nome = "Mark Zukerberg";
   private string _senha = "1029384756";
   private int _telefone = 47991522;
   private int _cpf = 48294482;
   private string _matricula = "012D2B321A";


   public static AlmoxarifeBuilder Novo()
       => new AlmoxarifeBuilder();

   public Almoxarife Criar()
       => new Almoxarife(_nome, _senha, _telefone, _cpf);

   public string ComNome(string nome)
       => this._nome = nome;

   public string ComSenha(string senha)
       => this._senha = senha;

   public int ComTelefone(int telefone)
       => this._telefone = telefone;

   public int ComCpf(int cpf)
       => this._cpf = cpf;

   public string ComMatricula(string matricula)
       => this._matricula = matricula;
}
