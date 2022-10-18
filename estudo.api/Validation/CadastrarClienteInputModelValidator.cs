using estudo.api.Validation.Auxiliar;
using estudo.domain.DTO_s.InputModels;
using FluentValidation;

namespace estudo.api.Validation
{
    public class CadastrarClienteInputModelValidator : AbstractValidator<CadastrarClienteInputModel>
    {
        public CadastrarClienteInputModelValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage(string.Format(ResourceApi.CampoVazio, "Nome"));

            RuleFor(x => x.Sobrenome)
                .NotEmpty()
                .WithMessage(string.Format(ResourceApi.CampoVazio, "Sobrenome"));

            RuleFor(x => x.Cpf)
                .NotEmpty()
                .WithMessage(string.Format(ResourceApi.CampoVazio, "CPF"))
                .Must(x => x.ValidarCpf() == true)
                .WithMessage(ResourceApi.CpfInvalido);

            RuleFor(x => x.DataNascimento)
                .Must(x => x <= DateTime.Now)
                .WithMessage(ResourceApi.DataNascimentoInvalida);
        }
    }
}
