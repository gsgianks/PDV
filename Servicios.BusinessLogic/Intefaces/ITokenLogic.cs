using Servicios.Models;

namespace Servicios.BusinessLogic.Intefaces
{
    public interface ITokenLogic
    {
        User ValidateUser(string email, string password);
    }
}
