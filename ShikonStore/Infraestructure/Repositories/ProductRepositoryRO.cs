using System.Data;
using Microsoft.Data.SqlClient;
using ShikonStore.Domain.Agregates;
using ShikonStore.Domain.Contracts;
using ShikonStore.Infraestructure.Data;

namespace ShikonStore.Infraestructure.Repositories
{
    public class ProductRepositoryRO : IProductRepositoryRO
    {
        private readonly IConnectionSQL _connectionSQL;

        public ProductRepositoryRO(IConnectionSQL connectionSQL)
        {
            _connectionSQL = connectionSQL;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var products = new List<Product>();
            using var connection = (SqlConnection)_connectionSQL.GetConnection();
            using var command = new SqlCommand("dbo.USP_Producto_Listar", connection);
            command.CommandType = CommandType.StoredProcedure;
            
            await connection.OpenAsync();
            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                products.Add(new Product
                {
                    IdProducto = reader.GetInt32(0),
                    NombreProducto = reader.IsDBNull(1) ? null : reader.GetString(1),
                    Categoria = reader.IsDBNull(2) ? null : reader.GetString(2),
                    Descripcion = reader.IsDBNull(3) ? null : reader.GetString(3),
                    Cantidad = reader.GetInt32(4),
                    Precio = reader.GetDecimal(5),
                    Estado = reader.GetBoolean(6)
                });
            }
            return products;
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            using var connection = (SqlConnection)_connectionSQL.GetConnection();
            using var command = new SqlCommand("dbo.USP_Producto_ObtenerPorId", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@IdProducto", id);

            await connection.OpenAsync();
            using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new Product
                {
                    IdProducto = reader.GetInt32(0),
                    NombreProducto = reader.IsDBNull(1) ? null : reader.GetString(1),
                    Categoria = reader.IsDBNull(2) ? null : reader.GetString(2),
                    Descripcion = reader.IsDBNull(3) ? null : reader.GetString(3),
                    Cantidad = reader.GetInt32(4),
                    Precio = reader.GetDecimal(5),
                    Estado = reader.GetBoolean(6)
                };
            }
            return null;
        }
    }
}
