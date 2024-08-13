using System.Collections.Generic;

namespace Module33.AuthenticationService.Models.Repositopries
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetByLogin(string login);
    }
}
