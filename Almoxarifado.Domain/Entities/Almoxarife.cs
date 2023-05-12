namespace Almoxarifado.Domain.Entities;
using Almoxarifado.Domain.Commons;

public class Almoxarife : Funcionario
{
   public Almoxarife(string nome, string senha, int telefone) : base(nome, senha, telefone)
   {
   }

   public void CadastrarNovoProduto(string nome, double valor, string descricao)
   {
   }

   public void AdicionarUnidades(string codigo, int unidades)
   {
   }
}