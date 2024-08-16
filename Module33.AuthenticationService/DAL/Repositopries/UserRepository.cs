using System;
using System.Collections.Generic;
using System.Linq;
using Module33.AuthenticationService.DAL.Models;

namespace Module33.AuthenticationService.DAL.Repositopries
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
                    Password = "1",
                    Role = new Role() {
                        Id = 1,
                        Name = "Пользователь"
                    }
                },
                new()  {
                    Id = Guid.NewGuid(),
                    Name = "Иван",
                    SurName = "Иванов",
                    Email = "ivan@bord.ru",
                    Login = "iva",
                    Password = "111",
                    Role = new Role() {
                        Id = 1,
                        Name = "Администратор"
                    }
                },
                new() {
                    Id = Guid.NewGuid(),
                    Name = "Darko",
                    SurName = "Volovich",
                    Email = "volodar@oohya.com",
                    Login = "Dark",
                    Password = "123qweasdzxc",
                    Role = new Role() {
                        Id = 1,
                        Name = "Пользователь"
                    }
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
