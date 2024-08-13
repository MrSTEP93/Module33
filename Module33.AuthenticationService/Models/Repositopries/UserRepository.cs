using System;
using System.Collections.Generic;
using System.Linq;

namespace Module33.AuthenticationService.Models.Repositopries
{
    public class UserRepository : IUserRepository
    {
        List<User> users;

        public UserRepository()
        {
            users = new()
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Test",
                    SurName = "Testov",
                    Email = "Test@tester.com",
                    Login = "Test",
                    Password = "1"
                },
                new()  {
                    Id = Guid.NewGuid(),
                    Name = "Иван",
                    SurName = "Иванов",
                    Email = "ivan@ruboard.ru",
                    Login = "ivanov",
                    Password = "11111122222qq"
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Darko",
                    SurName = "Volovich",
                    Email = "volodar@yahoo.com",
                    Login = "Dark",
                    Password = "123qweasdzxc"
                }
            };
        }

        public IEnumerable<User> GetAll()
        {
            return users;
        }

        public User GetByLogin(string login)
        {
            return users.FirstOrDefault(u => u.Login == login);
        }
    }
}
