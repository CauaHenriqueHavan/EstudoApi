using estudo.domain.Enums;

namespace estudo.domain.Entities
{
    public class FornecedorEntity
    {
        public short Id { get; private set; }
        public string Nome { get; private set; }
        public SituacaoEnum Situacao { get; private set; }
    }
}
