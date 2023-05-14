namespace Almoxarifado.Domain.Entities;
using Almoxarifado.Domain.Commons;
using Almoxarifado.Domain.Enums;

public class Colaborador : Funcionario
{
   public string Matricula { get; private set; }
   public int Cpf { get; private set; }
   public TipoColaborador TipoColaborador { get; private set; }
   public CargoColaborador Cargo { get; private set; }
   public Colaborador(string nome, string senha, int telefone, int cpf, TipoColaborador tipoColaborador, CargoColaborador cargo) : base(nome, senha, telefone)
   {
      Matricula = GerarMatricula();
      Cpf = cpf;
      TipoColaborador = tipoColaborador;
      Cargo = cargo;
   }

   private string GerarMatricula() 
   {
      // string pois é mlr de testar;  
      string matricula = string.Empty;
      var rndNumero = new Random();
      for(int i=0; i<8; i++)
         matricula += rndNumero.Next(0, 9).ToString();

      return matricula;
   }
}