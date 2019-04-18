using Servicios.Models;

namespace Servicios.Repositories
{
    public interface IUserRepository: IRepository<User>
    {
        User ValidateUser(string email, string password);
    }
}
