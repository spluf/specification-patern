using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Capon.Users.Persistance.Sql
{
    public class UserDbContext : DbContext
    {

        public UserDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Capon.Users.Domain.Models.Data.User>()
                .HasOne(e => e.Address);
        }

        public DbSet<Capon.Users.Domain.Models.Data.User> Users { get; set; }
        public DbSet<Capon.Users.Domain.Models.Data.Address> Addresses { get; set; }

    }
}
