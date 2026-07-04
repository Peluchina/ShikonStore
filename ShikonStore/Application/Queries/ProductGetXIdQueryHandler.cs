using ShikonStore.Application.DTOs;
using ShikonStore.Domain.Contracts;

namespace ShikonStore.Application.Queries
{
    public class ProductGetXIdQueryHandler
    {
        private readonly IProductRepositoryRO _repository;

        public ProductGetXIdQueryHandler(IProductRepositoryRO repository)
        {
            _repository = repository;
        }

        public async Task<ProductGetXIdResponse?> HandleAsync(ProductGetXIdQuery query)
        {
            var product = await _repository.GetByIdAsync(query.Parameters.IdProducto);
            if (product == null) return null;

            return new ProductGetXIdResponse
            {
                IdProducto = product.IdProducto,
                NombreProducto = product.NombreProducto,
                Categoria = product.Categoria,
                Descripcion = product.Descripcion,
                Cantidad = product.Cantidad,
                Precio = product.Precio,
                Estado = product.Estado
            };
        }
    }
}
