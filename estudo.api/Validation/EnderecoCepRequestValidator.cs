using estudo.domain.Common.Requests;
using FluentValidation;

namespace estudo.api.Validation
{
    public class EnderecoCepRequestValidator : AbstractValidator<EnderecoCepRequest>
    {
        public EnderecoCepRequestValidator()
        {
            RuleFor(x => x.Cep)
                .Length(8)
                .WithMessage(ResourceApi.CepFormatoInvalido)
                .NotEmpty()
                .WithMessage(string.Format(ResourceApi.CampoVazio, "Cep"));
        }
    }
}
