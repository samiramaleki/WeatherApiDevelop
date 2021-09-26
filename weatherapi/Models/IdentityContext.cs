using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace weatherapi.Models
{
    public class IdentityContext : DbContext
    {
        public IdentityContext()
        {

        }

        public DbSet<User> Users { get; set; }
        public IdentityContext(DbContextOptions<IdentityContext> dbContextOptions)
          : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
