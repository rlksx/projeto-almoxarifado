namespace Almoxarifado.Test;

using Almoxarifado.Domain.Entities;
using Xunit;

public class ProdutoConsumivelTest
{
   // testando produto valido
   public static readonly ProdutoConsumivel _produtoConsumivel = new ProdutoConsumivel("item", 200, "descricao", 228);

   [Fact]

   public void dado_um_novo_produto_consumivel_validade_menor_que_30_nao_deve_ser_adicionada()
   {
      var produto = new ProdutoConsumivel("item", 200, "descricao", 0);
      Assert.True(produto.Validade > DateTime.Now.AddDays(30));
   }
   public void dado_um_novo_produto_valido_gerar_cod_com_8_caracteres()
   {
      Assert.Equal(8, _produtoConsumivel.Codigo.Length);
   }

   public void dado_um_novo_produto_valido_gerar_com_0_unidades()
   {
      Assert.Equal(0, _produtoConsumivel.Unidades);
   }

   public void dado_um_novo_produto_com_valor_menor_ou_igual_a_zero_nao_deve_ser_adicionado()
   {
      Assert.True(_produtoConsumivel.Valor > 0);
   }

   public void dado_um_novo_produto_descricao_nao_deve_ser_vazio()
   {
      Assert.False(string.IsNullOrEmpty(_produtoConsumivel.Descricao));
   }

   public void dado_um_novo_produto_nome_nao_deve_ser_vazio()
   {
      Assert.False(string.IsNullOrEmpty(_produtoConsumivel.Nome));
   }
}