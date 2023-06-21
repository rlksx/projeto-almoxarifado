namespace Almoxarifado.Test;

public class ColaboradorTest
{
    private static Colaborador? _colaborador;

    public ColaboradorTest()
       => _colaborador = new Colaborador("nome", "senha", 470000, 020302, TipoColaborador.Interno, CargoColaborador.Suporte);

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void dado_um_novo_colaborador_cpf_deve_ser_maior_que_0(int _cpf)
    {
        Assert.Throws<ArgumentException>(() => new Colaborador("nome", "123456", 47000, _cpf, TipoColaborador.Interno, CargoColaborador.Suporte))
              .Message.Equals("Cpf invalido");
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void dado_um_novo_colaborador_telefone_deve_ser_maior_que_0(int _telefone)
    {
        Assert.Throws<ArgumentException>(() => new Colaborador("nome", "123456", _telefone, 24198732, TipoColaborador.Interno, CargoColaborador.Suporte))
              .Message.Equals("Telefone invalido");
    }

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