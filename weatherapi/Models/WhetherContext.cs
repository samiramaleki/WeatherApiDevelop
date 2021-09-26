using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace weatherapi.Models
{
    public class WhetherContext : DbContext
    {
        public WhetherContext()
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Weather> Weathers { get; set; }
        public WhetherContext(DbContextOptions<WhetherContext> dbContextOptions)
          : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
