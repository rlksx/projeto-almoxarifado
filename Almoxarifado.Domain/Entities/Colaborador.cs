namespace Almoxarifado.Domain.Entities;
using Almoxarifado.Domain.Commons;

public class Colaborador : Funcionario
{
   public Colaborador(string nome, string senha, int telefone) : base(nome, senha, telefone)
   {
   }

   // solicitar pedido e bla bla bla
}