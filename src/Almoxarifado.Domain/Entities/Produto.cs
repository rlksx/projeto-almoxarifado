namespace Almoxarifado.Domain.Entities;

public class Produto
{
    public string Nome { get; private set; }
    public string Descricao { get; private set; }
    public int Unidades { get; private set; } = 0;
    public double Valor { get; private set; }
    public string Codigo { get; private set; }

    public DateTime DataDeInsercao { get; private set; } = DateTime.UtcNow;
    public DateTime DataDeAlteracao { get; private set; }
    public bool Status => true ? false : Unidades > 0;

    public Produto(string nome, double valor, string descricao)
    {
        if (String.IsNullOrEmpty(nome)) throw new ArgumentException("Nome não pode ser vazio");
        if (valor <= 0) throw new ArgumentException("Valor deve ser maior que zero");
        if (String.IsNullOrEmpty(descricao)) throw new ArgumentException("Descrição não pode ser vazia");

        Nome = nome;
        Descricao = descricao;
        Valor = valor;
        Codigo = Guid.NewGuid().ToString().Substring(0, 8);

        DataDeInsercao = DateTime.UtcNow;
        DataDeAlteracao = DateTime.UtcNow;
    }

    public void AdicionarUnidades(int unidades)
    {
        if (unidades <= 0) throw new ArgumentException("Unidades deve ser maior que zero");
        Unidades += unidades;
    }

    public void RemoverUnidades(int unidades)
    {
        if (unidades <= 0) throw new ArgumentException("Unidades deve ser maior que zero");
        if (unidades > Unidades) throw new ArgumentException("Não é possivel remover mais unidades do que existem");

        Unidades -= unidades;
    }
}
