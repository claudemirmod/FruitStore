using FluentValidation;
using FruitStore.Domain.Entities;

namespace FruitStore.Service.Validators
{
    public class PedidoValidator : AbstractValidator<Pedido>
    {
        public PedidoValidator()
        {
            RuleFor(c => c.IdUsuario)
                .NotEmpty().WithMessage("O campo idUsuario é obrigatório!")
                .NotNull().WithMessage("O campo idUsuario é obrigatório!");

            RuleFor(c => c.Itens)
                .NotNull().WithMessage("O pedido deve ter pelo menos um Item");
        }
    }
}
