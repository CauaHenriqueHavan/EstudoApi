using estudo.domain.Enums;

namespace estudo.domain.Entities
{
    public class ProdutoEntity
    {
        public short Id { get; private set; }
        public string Nome { get; private set; }
        public string Imagem { get; private set; }
        public decimal Preco { get; private set; }
        public SituacaoEnum Situacao { get; private set; }
        public short Fornecedor { get; private set; }

        public ProdutoEntity(short id, string nome, string imagem, decimal preco, SituacaoEnum situacao, short fornecedor)
        {
            Id = id;
            Nome = nome;
            Imagem = imagem;
            Preco = preco;
            Situacao = situacao;
            Fornecedor = fornecedor;
        }
    }
}
