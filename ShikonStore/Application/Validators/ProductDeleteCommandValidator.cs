using FluentValidation;
using ShikonStore.Application.Commands;

namespace ShikonStore.Application.Validators
{
    public class ProductDeleteCommandValidator : AbstractValidator<ProductDeleteCommand>
    {
        public ProductDeleteCommandValidator()
        {
            RuleFor(x => x.Parameters)
                .NotNull().WithMessage("Los parámetros de ruta son obligatorios.");
            RuleFor(x => x.Parameters.IdProducto)
                .GreaterThan(0).WithMessage("El ID del producto a eliminar debe ser mayor a 0.");
        }
    }
}
