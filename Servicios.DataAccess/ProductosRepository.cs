using Dapper;
using Servicios.Models;
using Servicios.Repositories;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

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

        /// <summary>
        /// Método que obtiene un producto por código de barra
        /// </summary>
        /// <param name="barCode"></param>
        /// <returns></returns>
        public Inv_Productos GetProductByBarCode(string barCode)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@CodigoBarra", barCode);

            using (var connection = new SqlConnection(_connectionString))
            {
                var resp = connection.Query<Inv_Productos>("dbo.sp_ObtenerProductoPorCodBarra",
                                                    parameters,
                                                    commandType: System.Data.CommandType.StoredProcedure);
                return resp.FirstOrDefault();
            }
        }
    }
}
