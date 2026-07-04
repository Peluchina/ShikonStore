using FluentValidation;
using ShikonStore.Domain.Contracts;

namespace ShikonStore.Application.Commands
{
    public class ProductDeleteCommandHandler
    {
        private readonly IProductRepositoryWR _repository;
        private readonly IValidator<ProductDeleteCommand> _validator;

        public ProductDeleteCommandHandler(IProductRepositoryWR repository, IValidator<ProductDeleteCommand> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<bool> HandleAsync(ProductDeleteCommand command)
        {
            await _validator.ValidateAndThrowAsync(command);
            return await _repository.DeleteAsync(command.Parameters.IdProducto);
        }
    }
}
