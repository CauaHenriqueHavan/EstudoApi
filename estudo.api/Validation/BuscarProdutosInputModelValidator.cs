using estudo.domain.DTO_s.InputModels;
using FluentValidation;

namespace estudo.api.Validation
{
    public class BuscarProdutosInputModelValidator : AbstractValidator<BuscarProdutosInputModel>
    {
        public BuscarProdutosInputModelValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan((short)0)
                .When(x => x != null)
                .WithMessage(ResourceApi.IdInvalido);
        }
    }
}
