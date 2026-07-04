using FluentValidation;
using ShikonStore.Domain.Agregates;
using ShikonStore.Domain.Contracts;

namespace ShikonStore.Application.Commands
{
    public class ProductUpdateCommandHandler
    {
        private readonly IProductRepositoryWR _repository;
        private readonly IValidator<ProductUpdateCommand> _validator;

        public ProductUpdateCommandHandler(IProductRepositoryWR repository, IValidator<ProductUpdateCommand> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<bool> HandleAsync(ProductUpdateCommand command)
        {
            await _validator.ValidateAndThrowAsync(command);
            var product = new Product
            {
                IdProducto = command.Parameters.IdProducto,
                NombreProducto = command.Request.NombreProducto,
                Categoria = command.Request.Categoria,
                Descripcion = command.Request.Descripcion,
                Cantidad = command.Request.Cantidad,
                Precio = command.Request.Precio,
                Estado = command.Request.Estado
            };

            return await _repository.UpdateAsync(product);
        }
    }
}
