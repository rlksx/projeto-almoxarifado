namespace Almoxarifado.Test._Builders;

public class ProdutoBuilder
{
    private string _nome = "Marcão da Massa";
    private string _descricao = "Um produto como nenhum outro.";
    private double _valor = 198.45;

    public static ProdutoBuilder Novo()
        => new ProdutoBuilder();

    public Produto Criar()
        => new Produto(_nome, _valor, _descricao);

    public ProdutoBuilder ComNome(string nome)
    {
        _nome = nome;

        return this;
    }

    public ProdutoBuilder ComValor(double valor)
    {
        _valor = valor;

        return this;
    }

    public ProdutoBuilder ComDescricao(string descricao)
    {
        _descricao = descricao;

        return this;
    }
}
