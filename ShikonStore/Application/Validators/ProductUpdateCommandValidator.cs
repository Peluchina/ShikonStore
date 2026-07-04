using FluentValidation;
using ShikonStore.Application.Commands;

namespace ShikonStore.Application.Validators
{
    public class ProductUpdateCommandValidator : AbstractValidator<ProductUpdateCommand>
    {
        public ProductUpdateCommandValidator()
        {
            RuleFor(x => x.Parameters)
                .NotNull().WithMessage("Los parámetros de ruta son obligatorios.");
            RuleFor(x => x.Parameters.IdProducto)
                .GreaterThan(0).WithMessage("El ID del producto debe ser mayor a 0.");
            RuleFor(x => x.Request)
                .NotNull().WithMessage("Los datos de actualización son obligatorios.");
            RuleFor(x => x.Request.NombreProducto)
                .NotEmpty().WithMessage("El nombre del producto es obligatorio.")
                .MaximumLength(150).WithMessage("El nombre del producto no puede superar los 150 caracteres.");
            RuleFor(x => x.Request.Precio)
                .GreaterThan(0).WithMessage("El precio debe ser mayor a 0.");
            RuleFor(x => x.Request.Cantidad)
                .GreaterThanOrEqualTo(0).WithMessage("La cantidad no puede ser negativa.");
        }
    }
}
