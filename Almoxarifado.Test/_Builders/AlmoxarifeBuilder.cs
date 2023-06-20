
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

   public AlmoxarifeBuilder ComNome(string nome)
       => this._nome = nome;

j   public AlmoxarifeBuilder ComSenha(string senha)
       => this._senha = senha;

   public AlmoxarifadoBuilder ComTelefone(int telefone)
       => this._telefone = telefone;

   public AlmoxarifeBuilder ComCpf(int cpf)
       => this._cpf = cpf;

   public AlmoxarifeBuilder ComMatricula(string matricula)
       => this._matricula = matricula;
}
