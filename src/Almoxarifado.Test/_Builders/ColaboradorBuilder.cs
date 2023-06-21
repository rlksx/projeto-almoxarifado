namespace Almoxarifado.Test._Builders;

public class ColaboradorBuilder
{
   private string _nome = "Mark Zukerberg";
   private string _senha = "1029384756";
   private int _telefone = 47991522;
   private int _cpf = 48294482;
   private string _matricula = "012D2B321A";
   private TipoColaborador _tipoColaborador = TipoColaborador.Interno;
   private CargoColaborador _cargoColaborador = CargoColaborador.Gerente;


    public static ColaboradorBuilder Novo()
        => new ColaboradorBuilder();

    public Colaborador Criar()
        => new Colaborador(_nome, _senha, _telefone, _cpf, _tipoColaborador, _cargoColaborador);

    public ColaboradorBuilder ComNome(string nome)
    {
        this._nome = nome;

        return this;
    }

    public ColaboradorBuilder ComSenha(string senha)
    {
        this._senha = senha;

        return this;
    }

    public ColaboradorBuilder ComTelefone(int telefone)
    {
        this._telefone = telefone;

        return this;
    }

    public ColaboradorBuilder ComCpf(int cpf)
    {
        this._cpf = cpf;

        return this;
    }
    
    public ColaboradorBuilder ComMatricula(string matricula)
    {
        this._matricula = matricula;

        return this;
    }

    public ColaboradorBuilder ComTipoColaborador(CargoColaborador cargoColaborador)
    {
        this._cargoColaborador = cargoColaborador;

        return this;
    }

    public ColaboradorBuilder ComCargoColaborador(CargoColaborador cargoColaborador)
    {
        this._cargoColaborador = cargoColaborador;

        return this;
    }
}
