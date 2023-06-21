namespace Almoxarifado.Test._Builders;

public class ProdutoConsumivelBuilder
{
    private string _nome = "Marcão da Massa";
    private string _descricao = "Um produto como nenhum outro.";
    private double _valor = 198.45;
    private int _validadeEmDias = 90;

    public static ProdutoConsumivelBuilder Novo()
        => new ProdutoConsumivelBuilder();

    public ProdutoConsumivel Criar()
        => new ProdutoConsumivel(_nome, _valor, _descricao, _validadeEmDias);

    public ProdutoConsumivelBuilder ComNome(string nome)
    {
        _nome = nome;

        return this;
    }

    public ProdutoConsumivelBuilder ComValor(double valor)
    {
        _valor = valor;

        return this;
    }

    public ProdutoConsumivelBuilder ComDescricao(string descricao)
    {
        _descricao = descricao;

        return this;
    }

    public ProdutoConsumivelBuilder ComValidade(int validade)
    {
      _validadeEmDias = validade;

      return this;
    }
}
