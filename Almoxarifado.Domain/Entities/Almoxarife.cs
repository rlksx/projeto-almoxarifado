namespace Almoxarifado.Domain.Entities;
using Almoxarifado.Domain.Commons;

public class Almoxarife : Funcionario
{
   public Almoxarife(string nome, string senha, int telefone, int cpf) : base(nome, senha, telefone, cpf)
   {

   }

   public void CadastrarNovoProduto(string nome, double valor, string descricao)
   {
   }

   public void CadastrarNovoColaborador()
   {

   }

   public void AdicionarUnidades(string codigo, int unidades)
   {
   }
}