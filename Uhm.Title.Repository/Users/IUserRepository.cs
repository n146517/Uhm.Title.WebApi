using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uhm.Title.Data.Models;

namespace Uhm.Title.Repository.Users
{
    public interface IUserRepository
    {
        Task<bool> CreateUser(User user);
        User UpdateUser(User user);
        Task<List<User>> GetUserList();
        bool DeleteUserById(int id);
        Task<bool> SaveErrorLogging(Exception exception);
    }
}
