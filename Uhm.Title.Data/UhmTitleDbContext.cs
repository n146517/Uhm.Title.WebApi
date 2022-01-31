using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uhm.Title.Data.Models;

namespace Uhm.Title.Data
{
    public class UhmTitleDbContext : DbContext
    {
        public UhmTitleDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<ErrorLogging> ErrorLoggings { get; set; }
    }
}
