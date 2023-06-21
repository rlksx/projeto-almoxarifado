namespace Almoxarifado.Domain.Entities;
using Almoxarifado.Domain.Commons;
using Almoxarifado.Domain.Enums;

public class Colaborador : Funcionario
{
    public TipoColaborador TipoColaborador { get; private set; }
    public CargoColaborador Cargo { get; private set; }
    public bool Status { get; private set; } = true;
    public Colaborador(string nome, string senha, int telefone, int cpf, TipoColaborador tipoColaborador, CargoColaborador cargo) : base(nome, senha, telefone, cpf)
    {
        TipoColaborador = tipoColaborador;
        Cargo = cargo;
    }
}