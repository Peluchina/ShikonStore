using ShikonStore.Domain.Agregates;

namespace ShikonStore.Domain.Contracts
{
    public interface IProductRepositoryWR
    {
        Task<int> CreateAsync(Product product);
        Task<bool> UpdateAsync(Product product);
        Task<bool> UpdateStatusAsync(int id, bool estado);
        Task<bool> DeleteAsync(int id);
    }
}
