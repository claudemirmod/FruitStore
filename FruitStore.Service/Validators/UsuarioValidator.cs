using FluentValidation;
using FruitStore.Domain.Entities;

namespace FruitStore.Service.Validators
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O campo Nome é obrigatório!")
                .NotNull().WithMessage("O campo Nome é obrigatório!");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("O campo e-mail é obrigatório!")
                .NotNull().WithMessage("O campo e-mail é obrigatório!");

            RuleFor(c => c.Senha)
                .NotEmpty().WithMessage("O campo Senha é obrigatório!")
                .NotNull().WithMessage("O campo Senha é obrigatório!");
        }
    }
}
