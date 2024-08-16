using System.Collections.Generic;
using Module33.AuthenticationService.DAL.Models;

namespace Module33.AuthenticationService.DAL.Repositopries
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetByLogin(string login);
    }
}
