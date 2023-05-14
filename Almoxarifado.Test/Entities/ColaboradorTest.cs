namespace Almoxarifado.Test;
using Almoxarifado.Domain.Entities;
using Almoxarifado.Domain.Enums;
using Xunit;

public class ColaboradorTest
{
   private static readonly Colaborador _colaborador = new Colaborador("nome", "senha", 470000, 020302, TipoColaborador.Interno, CargoColaborador.Suporte);

   [Theory]
   [InlineData("")]
   [InlineData(null)]
   public void dado_um_novo_colaborador_senha_nao_deve_ser_vazia(string _senha)
   {
      Assert.Throws<ArgumentException>(() =>
         new Colaborador("nome", _senha, 47000, 1231221321, TipoColaborador.Interno, CargoColaborador.Suporte))
            .Message.Equals("Senha invalida");
   }

   [Theory]
   [InlineData("")]
   [InlineData(null)]
   public void dado_um_novo_colaborador_nome_nao_deve_ser_vazia(string _nome)
   {
      Assert.Throws<ArgumentException>(() =>
         new Colaborador(_nome, "24524", 47000, 1231221321, TipoColaborador.Interno, CargoColaborador.Suporte))
            .Message.Equals("Nome invalido");
   }

   [Fact]
   public void dado_um_novo_colaborador_valido_gerar_matricula()
      => Assert.False(string.IsNullOrEmpty(_colaborador.Matricula));

   [Fact]
   public void dado_um_colaborador_valido_matricula_deve_ter_8_caracter()
   => Assert.Equal(8, _colaborador.Matricula.Length);

   [Fact]
   public void dado_um_novo_colaborador_status_deve_ser_ativo()
      => Assert.True(_colaborador.Status);

}