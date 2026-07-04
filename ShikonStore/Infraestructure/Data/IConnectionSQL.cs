using System.Data;

namespace ShikonStore.Infraestructure.Data
{
    public interface IConnectionSQL
    {
        IDbConnection GetConnection();
    }
}
