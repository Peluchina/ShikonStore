using ShikonStore.Domain.Agregates;

namespace ShikonStore.Domain.Contracts
{
    public interface IProductRepositoryRO
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
    }
}
