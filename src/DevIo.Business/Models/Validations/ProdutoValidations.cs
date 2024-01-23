using FluentValidation;

namespace DevIo.Business.Models.Validations
{
    public class ProdutoValidations : AbstractValidator<Produto>
    {
        public ProdutoValidations()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                    .WithMessage("O campo {PropertyName} precisa ser fornecido.")
                .Length(2, 200)
                    .WithMessage("O campo {PropertyName} precisa conter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(x => x.Descricao)
                .NotEmpty()
                    .WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 1000)
                    .WithMessage("O campo {PropertyName} deve ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(x => x.Valor)
                .GreaterThan(0)
                    .WithMessage("O campo {PropertyName} deve ser maior que {ComparisonValue}.");
        }
    }
}
