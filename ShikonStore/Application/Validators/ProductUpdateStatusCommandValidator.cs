using FluentValidation;
using ShikonStore.Application.Commands;

namespace ShikonStore.Application.Validators
{
    public class ProductUpdateStatusCommandValidator : AbstractValidator<ProductUpdateStatusCommand>
    {
        public ProductUpdateStatusCommandValidator()
        {
            RuleFor(x => x.Parameters)
                .NotNull().WithMessage("Los parámetros de ruta son obligatorios.");
            RuleFor(x => x.Parameters.IdProducto)
                .GreaterThan(0).WithMessage("El ID del producto debe ser mayor a 0.");
            RuleFor(x => x.Request)
                .NotNull().WithMessage("El cuerpo de la solicitud no puede estar vacío.");
        }
    }
}
