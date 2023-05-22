using Microsoft.AspNetCore.Http;

namespace estudo.infra.Repository.Extensions
{
    public static class StringExtensions
    {
        public static string ImagemToString(this IFormFile imagem)
        {
            var ms = new MemoryStream();
            imagem.OpenReadStream().CopyTo(ms);

            return Convert.ToBase64String(ms.ToArray());
        }
    }
}