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

   public void AdicionarUnidadesDeProduto(Produto produto, int unidades)
   {
      if(produto == null) throw new ArgumentException("Produto invalido");
      if(unidades <= 0) throw new ArgumentException("Unidades deve ser maior que zero");
      produto.AdicionarUnidades(unidades);
   }
   
}