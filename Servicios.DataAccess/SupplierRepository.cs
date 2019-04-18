using Dapper;
using Servicios.Models;
using Servicios.Repositories;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Servicios.DataAccess
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(string connectionString) : base(connectionString)
        {
                
        }

        public IEnumerable<Supplier> SupplierPageList(int page, int rows, string seachTerm)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@page", page);
            parameters.Add("@rows", rows);
            parameters.Add("@searchTerm", seachTerm);

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Supplier>("dbo.SupplierPagedList",
                                                    parameters,
                                                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
