using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PeopleActz.Infrastructure.Utils.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleActz.Infrastructure.Utils.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(new IdentityRole
            {
                Name = AppUserRoles.AppUser,
                NormalizedName = AppUserRoles.NormalizedAppUser
            },
          new IdentityRole
          {
              Name = AppUserRoles.Administrator,
              NormalizedName = AppUserRoles.NormalizedAdministrator
          }
         );
        }
    }
}
