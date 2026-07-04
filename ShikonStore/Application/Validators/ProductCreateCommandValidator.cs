using FluentValidation;
using ShikonStore.Application.Commands;

namespace ShikonStore.Application.Validators
{
    public class ProductCreateCommandValidator : AbstractValidator<ProductCreateCommand>
    {
        public ProductCreateCommandValidator()
        {
            RuleFor(x => x.Request)
                .NotNull().WithMessage("Los datos del producto son obligatorios.");
            RuleFor(x => x.Request.NombreProducto)
                .NotEmpty().WithMessage("El nombre del producto es obligatorio.")
                .MaximumLength(150).WithMessage("El nombre del producto no puede superar los 150 caracteres.");
            RuleFor(x => x.Request.Categoria)
                .NotEmpty().WithMessage("La categoría es obligatoria.");
            RuleFor(x => x.Request.Precio)
                .GreaterThan(0).WithMessage("El precio debe ser mayor a 0.");
            RuleFor(x => x.Request.Cantidad)
                .GreaterThanOrEqualTo(0).WithMessage("La cantidad no puede ser negativa.");
        }
    }
}
