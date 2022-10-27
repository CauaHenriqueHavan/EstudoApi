using Microsoft.AspNetCore.Http;

namespace estudo.domain.DTO_s.InputModels
{
    public class CriarProdutoInputModel
    {
        public string Nome { get; set; }
        public IFormFile Imagem { get; set; }
        public decimal Preco { get; set; }
        public short Fornecedor { get; set; }

    }
}
