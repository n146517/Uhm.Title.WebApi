using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uhm.Title.Data;
using Uhm.Title.Data.Models;
using Uhm.Title.Repository.Users;

namespace Uhm.Title.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UhmTitleDbContext _uhmTitleDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserRepository(UhmTitleDbContext uhmTitleDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _uhmTitleDbContext = uhmTitleDbContext;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<bool> CreateUser(User user)
        {
            _uhmTitleDbContext.Users.Add(user);
            _uhmTitleDbContext.SaveChanges();
            return true;

        }
        public async Task<List<User>> GetUserList()
        {
            var data = await _uhmTitleDbContext.Users.ToListAsync();
            return data;
        }
        public User UpdateUser(User user)
        {
            _uhmTitleDbContext.Users.Update(user);
            _uhmTitleDbContext.SaveChanges();
            return user;
        }
        public bool DeleteUserById(int id)
        {
            var data = _uhmTitleDbContext.Users.FirstOrDefault(x => x.Id == id);
            _uhmTitleDbContext.Users.Remove(data);
            _uhmTitleDbContext.SaveChanges();
            return true;
        }
        public async Task<bool> SaveErrorLogging(Exception exception)
        {

            var context = _httpContextAccessor.HttpContext.Request;
            string url = $"{context.Scheme}://{context.Host}{context.PathBase}{context.Path.Value}";
            var bh = exception.InnerException == null ? string.Empty : exception.InnerException.ToString();
            ErrorLogging errorLogging = new ErrorLogging
            {
                InnerException = exception.InnerException == null ? string.Empty : exception.InnerException.ToString(),
                ExceptionMsg = exception.Message == null ? string.Empty : exception.Message.ToString(),
                ExceptionType = exception.GetType().Name == null ? string.Empty : exception.GetType().Name.ToString(),
                ExceptionURL = url,
                ExceptionSource = exception.StackTrace == null ? string.Empty : exception.StackTrace.ToString(),
            };
            using (var contextdb = _uhmTitleDbContext)
            {
                await contextdb.ErrorLoggings.AddAsync(errorLogging);
                await contextdb.SaveChangesAsync();
            }
            return true;


        }
    }
}
