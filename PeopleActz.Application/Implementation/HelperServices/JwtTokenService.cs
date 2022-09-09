using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PeopleActz.Application.Helpers.Settings;
using PeopleActz.Application.Interfaces.HelperServices;
using PeopleActz.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PeopleActz.Application.Implementation.HelperServices
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly IOptions<JwtSettings> _jwtSettings;
        private readonly UserManager<AppUser> _userManager;



        public JwtTokenService(IOptions<JwtSettings> jwtSettings, UserManager<AppUser> userManager)
        {
            _jwtSettings = jwtSettings;
            _userManager = userManager;
        }

        public async  Task<List<Claim>> GenerateJwtClaims(AppUser applicationUser)
        {

            var claims = new List<Claim>
            {
              
                new Claim(  
                    JwtRegisteredClaimNames.Jti,
                    Guid.NewGuid().ToString()),
                new Claim(
                    ClaimTypes.NameIdentifier,
                  applicationUser.Id.ToString()),
                new Claim(
                    ClaimTypes.Email,
                    applicationUser.Email),

                new Claim(
                    ClaimTypes.System,
                    Environment.MachineName)


            };

            var roles = await _userManager.GetRolesAsync(applicationUser);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }



        public  JwtSecurityToken GenerateJwtToken( List<Claim> claims)
        {
            return new JwtSecurityToken(
                issuer: _jwtSettings.Value.JwtIssuer,
                audience: null,
                claims:  claims,
                expires: GenerateTokenExpirationDate(),
                signingCredentials: GenerateSigningCredentials(GenerateSymmetricSecurityKey())
                );
        }

        

        public SigningCredentials GenerateSigningCredentials(SymmetricSecurityKey symmetricSecurityKey)
        {
            return new SigningCredentials(symmetricSecurityKey,
                                         SecurityAlgorithms.HmacSha256);
        }

        public SymmetricSecurityKey GenerateSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Value.JwtKey));
        }

        public DateTime GenerateTokenExpirationDate() => DateTime.Now.AddDays(_jwtSettings.Value.JwtExpireDays);

        public string WriteJwtToken(JwtSecurityToken jwtSecurityToken) => new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

    }
}
