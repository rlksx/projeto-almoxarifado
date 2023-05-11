namespace Almoxarifado.Test;

using Almoxarifado.Domain.Entities;
using Xunit;

public class ProdutoConsumivelTest
{
   // testando produto valido
   public static readonly ProdutoConsumivel _produtoConsumivel = new ProdutoConsumivel("item", 200, "descricao", 87);

   // [Fact]
   public void dado_um_novo_produto_consumivel_validade_menor_que_30_nao_deve_ser_adicionada()
   {
      var produto = new ProdutoConsumivel("item", 200, "descricao", 31);
      Assert.True(produto.Validade > DateTime.Now.AddDays(30));
   }

   // [Fact]
   public void dado_um_novo_produto_valido_gerar_cod_com_8_caracteres()
      => Assert.Equal(8, _produtoConsumivel.Codigo.Length);


   // [Fact]
   public void dado_um_novo_produto_valido_gerar_com_0_unidades()
      => Assert.Equal(0, _produtoConsumivel.Unidades);
   

   [Fact]
   public void dado_um_novo_produto_com_valor_menor_ou_igual_a_zero_nao_deve_ser_adicionado()
      => Assert.True(_produtoConsumivel.Valor > 0);
   

   // [Fact]
   public void dado_um_novo_produto_descricao_nao_deve_ser_vazio()
      => Assert.False(string.IsNullOrEmpty(_produtoConsumivel.Descricao));

   // [Fact]
   public void dado_um_novo_produto_nome_nao_deve_ser_vazio()
      => Assert.False(string.IsNullOrEmpty(_produtoConsumivel.Nome));
}