using FluentValidation;
using ShikonStore.Application.DTOs;
using ShikonStore.Domain.Agregates;
using ShikonStore.Domain.Contracts;

namespace ShikonStore.Application.Commands
{
    public class ProductCreateCommandHandler
    {
        private readonly IProductRepositoryWR _repository;
        private readonly IValidator<ProductCreateCommand> _validator;

        public ProductCreateCommandHandler(IProductRepositoryWR repository, IValidator<ProductCreateCommand> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<ProductCreateResponse> HandleAsync(ProductCreateCommand command)
        {
            await _validator.ValidateAndThrowAsync(command);
            var product = new Product
            {
                NombreProducto = command.Request.NombreProducto,
                Categoria = command.Request.Categoria,
                Descripcion = command.Request.Descripcion,
                Cantidad = command.Request.Cantidad,
                Precio = command.Request.Precio,
                Estado = command.Request.Estado
            };

            var id = await _repository.CreateAsync(product);

            return new ProductCreateResponse { IdProducto = id };
        }
    }
}
