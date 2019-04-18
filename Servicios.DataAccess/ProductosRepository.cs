using Dapper;
using Servicios.Models;
using Servicios.Repositories;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Servicios.DataAccess
{
    public class ProductosRepository : Repository<Inv_Productos>, IProductosRepository
    {

        public ProductosRepository(string connectionString) : base(connectionString)
        {
        }

        public IEnumerable<Inv_Productos> ProductosListaPaginada(int page, int rows, string seachTerm)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@page", page);
            parameters.Add("@rows", rows);
            parameters.Add("@searchTerm", seachTerm);

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Inv_Productos>("dbo.ProductosListaPaginada",
                                                    parameters,
                                                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
