using estudo.domain.Enums;

namespace estudo.domain.DTO_s.OutputModels.Auxiliares
{
    public class FornecedorOutputModel
    {
        public short Id { get; set; }
        public string Nome { get; set; }
        public SituacaoEnum Situacao { get; set; }
    }
}
