namespace Almoxarifado.Domain.Entities;
using Almoxarifado.Domain.Commons;

public class Almoxarife : Funcionario
{
   public Almoxarife(string nome, string senha, int telefone) : base(nome, senha, telefone)
   {
   }

   // aceitar pedido e bla bla bla
}