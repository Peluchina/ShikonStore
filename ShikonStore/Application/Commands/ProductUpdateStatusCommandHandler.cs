using FluentValidation;
using ShikonStore.Domain.Contracts;

namespace ShikonStore.Application.Commands
{
    public class ProductUpdateStatusCommandHandler
    {
        private readonly IProductRepositoryWR _repository;
        private readonly IValidator<ProductUpdateStatusCommand> _validator;

        public ProductUpdateStatusCommandHandler(IProductRepositoryWR repository, IValidator<ProductUpdateStatusCommand> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<bool> HandleAsync(ProductUpdateStatusCommand command)
        {
            await _validator.ValidateAndThrowAsync(command);
            return await _repository.UpdateStatusAsync(command.Parameters.IdProducto, command.Request.Estado);
        }
    }
}
