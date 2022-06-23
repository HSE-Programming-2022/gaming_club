using System;
using System.Collections.Generic;
using backendApi.Entities;

namespace backendApi.Repositories
{
    public interface IUsersRepository
    {
        IEnumerable<User> GetUsers();
        User GetUser(Guid id);
        
        User GetUserByEmail(string email);
        
        User GetUserByPhone(string phone);

        void CreateUser(User user);

        void UpdateUser(User user);

        void DeleteUser(User user);
    }

}