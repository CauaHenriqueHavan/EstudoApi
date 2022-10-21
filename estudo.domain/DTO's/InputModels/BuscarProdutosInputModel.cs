using estudo.domain.DTO_s.InputModelAuxiliar;

namespace estudo.domain.DTO_s.InputModels
{
    public class BuscarProdutosInputModel : BaseFilterInputModel
    {
        public short? Id { get; set; }
        public string? Nome { get; set; }
        public short? Fornecedor { get; set; }
    }
}
