using System.Data;
using Microsoft.Data.SqlClient;
using ShikonStore.Domain.Agregates;
using ShikonStore.Domain.Contracts;
using ShikonStore.Infraestructure.Data;

namespace ShikonStore.Infraestructure.Repositories
{
    public class ProductRepositoyWR : IProductRepositoryWR
    {
        private readonly IConnectionSQL _connectionSQL;

        public ProductRepositoyWR(IConnectionSQL connectionSQL)
        {
            _connectionSQL = connectionSQL;
        }

        public async Task<int> CreateAsync(Product product)
        {
            using var connection = (SqlConnection)_connectionSQL.GetConnection();
            using var command = new SqlCommand("dbo.USP_Producto_Crear", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@NombreProducto", (object?)product.NombreProducto ?? DBNull.Value);
            command.Parameters.AddWithValue("@Categoria", (object?)product.Categoria ?? DBNull.Value);
            command.Parameters.AddWithValue("@Descripcion", (object?)product.Descripcion ?? DBNull.Value);
            command.Parameters.AddWithValue("@Cantidad", product.Cantidad);
            command.Parameters.AddWithValue("@Precio", product.Precio);

            await connection.OpenAsync();
            var result = await command.ExecuteScalarAsync();
            var id = result != null ? Convert.ToInt32(result) : 0;
            return id;
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            using var connection = (SqlConnection)_connectionSQL.GetConnection();
            using var command = new SqlCommand("dbo.USP_Producto_Actualizar", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@IdProducto", product.IdProducto);
            command.Parameters.AddWithValue("@NombreProducto", (object?)product.NombreProducto ?? DBNull.Value);
            command.Parameters.AddWithValue("@Categoria", (object?)product.Categoria ?? DBNull.Value);
            command.Parameters.AddWithValue("@Descripcion", (object?)product.Descripcion ?? DBNull.Value);
            command.Parameters.AddWithValue("@Cantidad", product.Cantidad);
            command.Parameters.AddWithValue("@Precio", product.Precio);

            await connection.OpenAsync();
            try
            {
                await command.ExecuteNonQueryAsync();
                return true;
            }
            catch (SqlException ex) when (ex.Number == 50001)
            {
                return false;
            }
        }

        public async Task<bool> UpdateStatusAsync(int id, bool estado)
        {
            using var connection = (SqlConnection)_connectionSQL.GetConnection();
            using var command = new SqlCommand("dbo.USP_Producto_ActualizarEstado", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@IdProducto", id);
            command.Parameters.AddWithValue("@Estado", estado);

            await connection.OpenAsync();
            using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                var codigo = reader.GetInt32(0);
                return codigo == 1;
            }
            return false;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var connection = (SqlConnection)_connectionSQL.GetConnection();
            using var command = new SqlCommand("dbo.USP_Producto_Eliminar", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@IdProducto", id);

            await connection.OpenAsync();
            try
            {
                await command.ExecuteNonQueryAsync();
                return true;
            }
            catch (SqlException ex) when (ex.Number == 50001)
            {
                return false;
            }
        }
    }
}
