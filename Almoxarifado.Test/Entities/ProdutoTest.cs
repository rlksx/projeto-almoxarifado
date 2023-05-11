namespace Almoxarifado.Test;

using Almoxarifado.Domain.Entities;
using Xunit;

public class ProdutoTest
{
   // testando produto valido
   public static readonly Produto _produto = new Produto("item", 200, "descricao");

   [Fact]
   public void dado_um_novo_produto_valido_gerar_cod_com_8_caracteres()
   {
      Assert.Equal(8, _produto.Codigo.Length);
   }

   public void dado_um_novo_produto_valido_gerar_com_0_unidades()
   {
      Assert.Equal(0, _produto.Unidades);
   }

   public void dado_um_novo_produto_com_valor_menor_ou_igual_a_zero_nao_deve_ser_adicionado()
   {
      Assert.True(_produto.Valor > 0);
   }

   public void dado_um_novo_produto_descricao_nao_deve_ser_vazio()
   {
      Assert.False(string.IsNullOrEmpty(_produto.Descricao));
   }

   public void dado_um_novo_produto_nome_nao_deve_ser_vazio()
   {
      Assert.False(string.IsNullOrEmpty(_produto.Nome));
   }

   // testando adcionar unidades
}
