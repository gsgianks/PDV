using Servicios.Repositories;

namespace Servicios.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customer { get; }
        IUserRepository User { get; }
        ISupplierRepository Supplier { get; }
        IOrderRepository Order { get; }
        IProductosRepository Producto { get; }
    }
}
