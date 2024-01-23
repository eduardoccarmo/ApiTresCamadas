using DevIO.Business.Models.Validations.Documentos;
using FluentValidation;

namespace DevIo.Business.Models.Validations
{
    public class FornecedorValidations : AbstractValidator<Fornecedor>
    {
        public FornecedorValidations()
        {
            RuleFor(f => f.Nome)
                .NotEmpty()
                    .WithMessage("O campo {PropertyName} deve ser fornecido.")
                .Length(2, 200)
                    .WithMessage("O campo {PropertyName} de vonter entre {MinLength} e {MaxLength}.");

            When(f => f.TipoFornecedor == TipoFornecedor.PessoaFisica, () =>
            {
                RuleFor(f => f.Documento.Length)
                    .Equal(CpfValidacao.TamanhoCpf)
                        .WithMessage("O campo Documento deve conter {ComparisonValue} caracteres e foram informados {PropertyValue}.");

                RuleFor(f => CpfValidacao.Validar(f.Documento))
                    .Equal(true)
                        .WithMessage("O documento fornecido e inválido.");
            });

            When(f => f.TipoFornecedor == TipoFornecedor.PessoaJuridica, () =>
            {
                RuleFor(f => f.Documento.Length)
                    .Equal(CnpjValidacao.TamanhoCnpj)
                        .WithMessage("O campo Documento deve conter {ComparisonValue} caracteres e foram informados {PropertyValue}.");

                RuleFor(f => CpfValidacao.Validar(f.Documento))
                    .Equal(true)
                        .WithMessage("O documento fornecido e inválido.");
            });
        }
    }
}
