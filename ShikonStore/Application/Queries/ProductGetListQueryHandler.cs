using ShikonStore.Application.DTOs;
using ShikonStore.Domain.Contracts;

namespace ShikonStore.Application.Queries
{
    public class ProductGetListQueryHandler
    {
        private readonly IProductRepositoryRO _repository;

        public ProductGetListQueryHandler(IProductRepositoryRO repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProductGetListResponse>> HandleAsync(ProductGetListQuery query)
        {
            var products = await _repository.GetAllAsync();
            return products.Select(p => new ProductGetListResponse
            {
                IdProducto = p.IdProducto,
                NombreProducto = p.NombreProducto,
                Categoria = p.Categoria,
                Descripcion = p.Descripcion,
                Cantidad = p.Cantidad,
                Precio = p.Precio,
                Estado = p.Estado
            });
        }
    }
}
