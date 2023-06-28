namespace Almoxarifado.Test;

public class ColaboradorTest
{
    private static Colaborador? _colaborador;

    public ColaboradorTest()
        => _colaborador = ColaboradorBuilder.Novo().Criar();

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void dado_um_novo_colaborador_cpf_deve_ser_maior_que_0(int _cpf)
    {
        Assert.Throws<ArgumentException>(() => ColaboradorBuilder.Novo().ComCpf(_cpf).Criar())
            .Message.Equals("Cpf invalido");
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void dado_um_novo_colaborador_telefone_deve_ser_maior_que_0(int _telefone)
    {
        Assert.Throws<ArgumentException>(() => ColaboradorBuilder.Novo().ComTelefone(_telefone).Criar())
            .Message.Equals("Telefone invalido");
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void dado_um_novo_colaborador_senha_nao_deve_ser_vazia(string _senha)
    {
        Assert.Throws<ArgumentException>(() => ColaboradorBuilder.Novo().ComSenha(_senha).Criar())
            .Message.Equals("Senha invalida");
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void dado_um_novo_colaborador_nome_nao_deve_ser_vazia(string _nome)
    {
        Assert.Throws<ArgumentException>(() => ColaboradorBuilder.Novo().ComNome(_nome).Criar())
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