using Servicios.Repositories;
using Servicios.UnitOfWork;

namespace Servicios.DataAccess
{
    public class ServiciosUnitOfWork : IUnitOfWork
    {
        public ServiciosUnitOfWork(string connectionString)
        {
            Customer = new CustomerRepository(connectionString);
            User = new UserRepository(connectionString);
            Supplier = new SupplierRepository(connectionString);
            Order = new OrderRepository(connectionString);
            Producto = new ProductosRepository(connectionString);
        }
        public ICustomerRepository Customer { get; private set; }
        public IUserRepository User { get; private set; }
        public ISupplierRepository Supplier { get; private set; }
        public IOrderRepository Order { get; private set; }
        public IProductosRepository Producto { get; private set; }
    }
}
