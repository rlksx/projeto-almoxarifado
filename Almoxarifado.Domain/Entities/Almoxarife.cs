namespace Almoxarifado.Domain.Entities;
using Almoxarifado.Domain.Commons;
using Almoxarifado.Domain.Enums;

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

   public void AdicionarUnidadesDeProduto(Produto produto, int unidades)
   {
      if(produto == null) throw new ArgumentException("Produto invalido");
      if(unidades < 0) throw new ArgumentException("Unidades deve ser maior que zero");
      produto.AdicionarUnidades(unidades);
   }

   public void RemoverUnidadesDeProduto(Produto produto, int unidades)
   {
      if(produto == null) throw new ArgumentException("Produto invalido");
      if(unidades <= 0) throw new ArgumentException("Unidades deve ser maior que zero");
      if(unidades > produto.Unidades) throw new ArgumentException("Não é possivel remover mais unidades do que existem");

      produto.RemoverUnidades(unidades);
   }

   
   public void AdicionarUnidadesDeProduto(ProdutoConsumivel produto, int unidades)
   {
      if(produto == null) throw new ArgumentException("Produto invalido");
      if(unidades < 0) throw new ArgumentException("Unidades deve ser maior que zero");
      produto.AdicionarUnidades(unidades);
   }

   public void RemoverUnidadesDeProduto(ProdutoConsumivel produto, int unidades)
   {
      if(produto == null) throw new ArgumentException("Produto invalido");
      if(unidades <= 0) throw new ArgumentException("Unidades deve ser maior que zero");
      if(unidades > produto.Unidades) throw new ArgumentException("Não é possivel remover mais unidades do que existem");

      produto.RemoverUnidades(unidades);
   }

   public Colaborador CadastrarNovoColaborador(string nome, string senha, int telefone, int cpf, TipoColaborador tipoColaborador, CargoColaborador cargo)
   { 
      var novoColaborador = new Colaborador(nome, senha, telefone, cpf, tipoColaborador, cargo);
      return novoColaborador;
   }
}