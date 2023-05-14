namespace Almoxarifado.Test;
using Almoxarifado.Domain.Entities;
using Almoxarifado.Domain.Enums;
using Xunit;

public class ColaboradorTest
{
   private static readonly Colaborador _colaborador = new Colaborador("nome", "senha", 470000, 020302, TipoColaborador.Interno, CargoColaborador.Suporte);

   [Fact]
   public void dado_um_novo_colaborador_valido_gerar_matricula()
      => Assert.False(string.IsNullOrEmpty(_colaborador.Matricula));
    
   [Fact]
   public void dado_um_colaborador_valido_matricula_deve_ter_8_caracter()
   => Assert.Equal(8, _colaborador.Matricula.Length);
   
}