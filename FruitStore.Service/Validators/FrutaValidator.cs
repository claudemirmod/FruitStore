using FluentValidation;
using FruitStore.Domain.Entities;

namespace FruitStore.Service.Validators
{
    public class FrutaValidator : AbstractValidator<Fruta>
    {
        public FrutaValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O campo Nome é obrigatório!")
                .NotNull().WithMessage("O campo Nome é obrigatório!");

            RuleFor(c => c.Quantidade)
                .NotEmpty().WithMessage("O campo Quantidade é obrigatório!")
                .NotNull().WithMessage("O campo Quantidade é obrigatório!");

            RuleFor(c => c.Valor)
                .NotEmpty().WithMessage("O campo Valor é obrigatório!")
                .NotNull().WithMessage("O campo Valor é obrigatório!");
        }
    }
}
