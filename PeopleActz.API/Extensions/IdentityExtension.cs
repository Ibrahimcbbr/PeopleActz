using Microsoft.AspNetCore.Identity;
using PeopleActz.Domain.Entities.Models;
using PeopleActz.Infrastructure.Context;

namespace PeopleActz.API.Extensions
{
    public static class IdentityExtension
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<AppUser, IdentityRole>(o =>
            {
                o.Password.RequireDigit = true;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 10;
                o.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<PeopleActzDbContext>()
            .AddDefaultTokenProviders();
        }
    }
}
