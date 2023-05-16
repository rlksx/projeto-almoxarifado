namespace Almoxarifado.Domain.Entities;
using Almoxarifado.Domain.Commons;

public class Almoxarife : Funcionario
{
   public Almoxarife(string nome, string senha, int telefone, int cpf) : base(nome, senha, telefone, cpf)
   {

   }

   public void CadastrarNovoProduto(Produto produto)
   {
      var estoque = Estoque.PegarEstoque();
      estoque.AdicionarProduto(produto);
   }

   public void CadastrarNovoColaborador()
   {

   }

   public void AdicionarUnidades(string codigo, int unidades)
   {
   }
}