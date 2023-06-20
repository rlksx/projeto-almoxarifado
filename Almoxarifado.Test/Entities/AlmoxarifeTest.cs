namespace Almoxarifado.Test;
using Almoxarifado.Domain.Entities;
using Almoxarifado.Domain.Enums;
using Xunit;

public class AlmoxarifeTest
{
   private static Almoxarife _almoxarife;

   public AlmoxarifeTest()
      =>  _almoxarife = new Almoxarife("nome", "senha", 470000, 020302);
   

   [Theory]
   [InlineData(0)]
   [InlineData(-1)]
   public void dado_um_novo_almoxarife_cpf_deve_ser_maior_que_0(int _cpf)
   {
      Assert.Throws<ArgumentException>(() => new Almoxarife("nome", "123456", 47000, _cpf))
            .Message.Equals("Cpf invalido");
   }


   [Theory]
   [InlineData(0)]
   [InlineData(-1)]
   public void dado_um_novo_almoxarife_telefone_deve_ser_maior_que_0(int _telefone)
   {
      Assert.Throws<ArgumentException>(() => new Almoxarife("nome", "123456", _telefone, 24198732))
            .Message.Equals("Telefone invalido");
   }

   [Theory]
   [InlineData("")]
   [InlineData(null)]
   public void dado_um_novo_almoxarife_senha_nao_deve_ser_vazia(string _senha)
   {
      Assert.Throws<ArgumentException>(() =>
         new Almoxarife("nome", _senha, 47000, 1231221321))
            .Message.Equals("Senha invalida");
   }

   [Theory]
   [InlineData("")]
   [InlineData(null)]
   public void dado_um_novo_almoxarife_nome_nao_deve_ser_vazia(string _nome)
   {
      Assert.Throws<ArgumentException>(() =>
         new Almoxarife(_nome, "24524", 47000, 1231221321))
            .Message.Equals("Nome invalido");
   }

   [Fact]
   public void dado_um_novo_almoxarife_valido_gerar_matricula()
      => Assert.False(string.IsNullOrEmpty(_almoxarife.Matricula));

   [Fact]
   public void dado_um_almoxarife_valido_matricula_deve_ter_8_caracter()
   => Assert.Equal(8, _almoxarife.Matricula.Length);

   // test pedidos
   [Fact]
   public void almoxarife_cadastrar_novo_produto()
   {
      var produto = new Produto("nome", 123, "descrição");
      var pedido = new Pedido("titulo", "descricao", new Colaborador("nome", "senha", 4748327, 817483, TipoColaborador.Externo, CargoColaborador.Suporte), produto);
      _almoxarife.CadastrarNovoProduto(pedido);
      
      Assert.True(Estoque.Produtos.Count() != 0);
   }

   [Fact]
   public void ao_remover_unidades_de_produto_produto_deve_ser_valido()
   {
      Assert.Throws<ArgumentException>(() => _almoxarife.AdicionarUnidadesDeProduto(null, 100))
         .Message.Equals("Produto invalido");
   }

   [Fact]
   public void ao_adicionar_produto_produto_deve_ser_valido()
   {
      Assert.Throws<ArgumentException>(() => _almoxarife.RemoverUnidadesDeProduto(null, 100))
         .Message.Equals("Produto invalido");
   }

   [Theory]
   [InlineData(0)]
   [InlineData(-1)]
   public void ao_adicionar_produto_unidades_deve_ser_maior_que_0(int _unidades)
   {
      var produto = new Produto("nome", 123, "descricao");
      Assert.Throws<ArgumentException>(() => _almoxarife.AdicionarUnidadesDeProduto(produto, _unidades))
         .Message.Equals("Unidades deve ser maior que zero");
   }


   [Theory]
   [InlineData(0)]
   [InlineData(-1)]
   public void ao_remover_produto_unidades_deve_ser_maior_que_0(int _unidades)
   {
      var produto = new Produto("nome", 123, "descricao");
      Assert.Throws<ArgumentException>(() => _almoxarife.RemoverUnidadesDeProduto(produto, _unidades))
         .Message.Equals("Unidades deve ser maior que zero");
   }

   [Fact]
   public void ao_remover_unidades_produto_deve_conter_mais_ou_igual_unidades()
   {
      var produto = new Produto("nome", 123, "descricao");
      produto.AdicionarUnidades(10);
      Assert.Throws<ArgumentException>(() => _almoxarife.RemoverUnidadesDeProduto(produto, 11))
         .Message.Equals("Não é possivel remover mais unidades do que existem");
   }

   [Fact]
   public void ao_registrar_novo_colaborador_retornar_o_mesmo()
   {
      var novoColaborador = _almoxarife.CadastrarNovoColaborador("nome", "senha", 472423, 0193748925, Domain.Enums.TipoColaborador.Externo, CargoColaborador.Suporte);

      var Colaborador = new Colaborador("nome", "senha", 472423, 0193748925, Domain.Enums.TipoColaborador.Externo, CargoColaborador.Suporte);
      
      Object.Equals(novoColaborador, Colaborador);
   }
}