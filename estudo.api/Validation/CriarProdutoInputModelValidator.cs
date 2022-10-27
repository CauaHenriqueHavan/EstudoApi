using estudo.domain.DTO_s.InputModels;
using FluentValidation;

namespace estudo.api.Validation
{
    public class CriarProdutoInputModelValidator : AbstractValidator<CriarProdutoInputModel>
    {
        public CriarProdutoInputModelValidator()
        {
            RuleFor(x => x.Nome)
                 .NotEmpty()
                 .WithMessage(string.Format(ResourceApi.CampoVazio, "Nome"));

            RuleFor(x => x.Preco)
                .NotNull()
                .WithMessage(ResourceApi.ValorInvalido)
                .GreaterThan(0);

            RuleFor(x => x.Fornecedor)
                .NotNull()
                .WithMessage(string.Format(ResourceApi.CampoVazio, "Fornecedor"))
                .GreaterThan((short)0)
                .WithMessage(ResourceApi.IdInvalido);

            RuleFor(x => x.Imagem)
                .NotEmpty()
                .WithMessage(string.Format(ResourceApi.CampoVazio, "Imagem"));
        }
    }
}
