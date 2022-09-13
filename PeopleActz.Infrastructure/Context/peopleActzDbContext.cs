using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PeopleActz.Domain.Entities.Models;
using PeopleActz.Infrastructure.Utils.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleActz.Infrastructure.Context
{
    public class PeopleActzDbContext : IdentityDbContext<AppUser>
    {
        public PeopleActzDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Post>().Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Entity<Comment>().Property(e => e.Id).ValueGeneratedOnAdd();

            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
