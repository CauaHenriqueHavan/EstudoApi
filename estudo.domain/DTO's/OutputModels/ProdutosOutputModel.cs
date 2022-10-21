using estudo.domain.DTO_s.OutputModels.Auxiliares;
using estudo.domain.Enums;

namespace estudo.domain.DTO_s.OutputModels
{
    public class ProdutosOutputModel
    {
        public short Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public SituacaoEnum Situacao { get; set; }
        public FornecedorOutputModel Fornecedor { get; set; }
    }
}
