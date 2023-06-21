
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
   {
      _nome = nome;
      
      return this;
   }

   public AlmoxarifeBuilder ComSenha(string senha)
   {
      _senha = senha;

      return this;
   }

   public AlmoxarifeBuilder ComTelefone(int telefone)
   {
      _telefone = telefone;

      return this;
   }

   public AlmoxarifeBuilder ComCpf(int cpf)
   {
        _cpf = cpf;

        return this;
   }

   public AlmoxarifeBuilder ComMatricula(string matricula)
    {
        _matricula = matricula;

        return this;
    }
}
