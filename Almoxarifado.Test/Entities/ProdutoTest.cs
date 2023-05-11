namespace Almoxarifado.Test;

using Almoxarifado.Domain.Entities;
using Xunit;

public class ProdutoTest
{
   // testando novo produto

   [Fact]
   public void dado_um_novo_produto_valido_gerar_cod_com_8_caracteres()
   {
      var produto = new Produto("item", 200, "descricao");
      Assert.Equal(8, produto.Codigo.Length);
   } 
   

   [Fact]
   public void dado_um_novo_produto_valido_gerar_com_0_unidades()
   {
      var produto = new Produto("item", 200, "descricao");
      Assert.Equal(0, produto.Unidades);
   }
   

   [Theory]
   [InlineData(0)]
   [InlineData(-1)]
   public void dado_um_novo_produto_com_valor_menor_ou_igual_a_zero_nao_deve_ser_adicionado(double _valor)
   {
      Assert.Throws<ArgumentException>(() => new Produto("item", _valor, "descricao"))
         .Message.Equals("Valor pode ser maior que zero");
   } 
   

   [Theory]
   [InlineData("")]
   [InlineData(null)]
   public void dado_um_novo_produto_descricao_pode_ser_vazia(string _descricao)
   {
      Assert.Throws<ArgumentException>(() => new Produto("item", 200, _descricao))
         .Message.Equals("Descrição não pode ser vazia");
   }
   

   [Theory]
   [InlineData("")]
   [InlineData(null)]
   public void dado_um_novo_produto_nome_nao_deve_ser_vazio(string _nome)
   {
      Assert.Throws<ArgumentException>(() => new Produto(_nome, 200, "descricao"))
         .Message.Equals("Nome não pode ser vazio");
   }

   // testando produto
}
