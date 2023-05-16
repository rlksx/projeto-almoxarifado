namespace Almoxarifado.Test;
using Almoxarifado.Domain.Entities;
using Xunit;

public class AlmoxarifeTest
{
   private static readonly Almoxarife _almoxarife = new Almoxarife("nome", "senha", 470000, 020302);

   [Theory]
   [InlineData(0)]
   [InlineData(-1)]
   public void dado_um_novo_almoxarife_cpf_deve_ser_maior_que_0(int _cpf)
   {
      Assert.Throws<ArgumentException>(() => new Almoxarife("nome", "123456", 47000, _cpf))
            .Message.Equals("Cpf invalido");
   }


   [Theory]
   [InlineData(0)]
   [InlineData(-1)]
   public void dado_um_novo_almoxarife_telefone_deve_ser_maior_que_0(int _telefone)
   {
      Assert.Throws<ArgumentException>(() => new Almoxarife("nome", "123456", _telefone, 24198732))
            .Message.Equals("Telefone invalido");
   }

   [Theory]
   [InlineData("")]
   [InlineData(null)]
   public void dado_um_novo_almoxarife_senha_nao_deve_ser_vazia(string _senha)
   {
      Assert.Throws<ArgumentException>(() =>
         new Almoxarife("nome", _senha, 47000, 1231221321))
            .Message.Equals("Senha invalida");
   }

   [Theory]
   [InlineData("")]
   [InlineData(null)]
   public void dado_um_novo_almoxarife_nome_nao_deve_ser_vazia(string _nome)
   {
      Assert.Throws<ArgumentException>(() =>
         new Almoxarife(_nome, "24524", 47000, 1231221321))
            .Message.Equals("Nome invalido");
   }

   [Fact]
   public void dado_um_novo_almoxarife_valido_gerar_matricula()
      => Assert.False(string.IsNullOrEmpty(_almoxarife.Matricula));

   [Fact]
   public void dado_um_almoxarife_valido_matricula_deve_ter_8_caracter()
   => Assert.Equal(8, _almoxarife.Matricula.Length);

   // test pedidos
   [Fact]
   public void almoxarife_cadastrar_novo_produto()
   {
      var produto = new Produto("nome", 123, "descrição");
      _almoxarife.CadastrarNovoProduto(produto);
      Assert.True(Estoque.Produtos.Count() != 0);
   }
}