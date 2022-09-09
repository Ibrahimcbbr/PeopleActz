using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using PeopleActz.Application.Helpers.Settings;
using System.Text;

namespace PeopleActz.API.Extensions
{
    public static class AuthenticationExtension
    {
        /// <summary>
        /// Extends Customized Authentication
        /// </summary>
        /// <param name="this">Injected <see cref="IServiceCollection"/></param>
        /// <param name="JwtSettings">Injected <see cref="JwtSettings"/></param>
        public static void AddCustomizedAuthentication(this IServiceCollection services, JwtSettings _JwtSettings)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,
                       ValidIssuer = _JwtSettings.JwtIssuer,
                       ValidAudiences = _JwtSettings.JwtAudiences,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_JwtSettings.JwtKey))
                   };
               });
        }
    }
}
