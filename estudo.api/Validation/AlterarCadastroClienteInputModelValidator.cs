using estudo.api.Validation.Auxiliar;
using estudo.domain.DTO_s.InputModels;
using FluentValidation;

namespace estudo.api.Validation
{
    public class AlterarCadastroClienteInputModelValidator : AbstractValidator<AlterarCadastroClienteInputModel>
    {
        public AlterarCadastroClienteInputModelValidator()
        {
            RuleFor(x => x.Cpf)
                .NotEmpty()
                .WithMessage(string.Format(ResourceApi.CampoVazio, "Cpf"))
                .Must(x => x.ValidarCpf() == true)
                .WithMessage(ResourceApi.CpfInvalido);
        }
    }
}
