using Microsoft.IdentityModel.Tokens;
using PeopleActz.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PeopleActz.Application.Interfaces.HelperServices
{
    public interface IJwtTokenService
    {
        /// <summary>
        /// Generates Jwt Token
        /// </summary>
        /// <param name="applicationUser">Injected <see cref="ApplicationUser"/></param>
        /// <returns>Instance of <see cref="JwtSecurityToken"/></returns>
        JwtSecurityToken GenerateJwtToken(List<Claim>claims);

        /// <summary>
        /// Writes Jwt Token
        /// </summary>
        /// <param name="jwtSecurityToken">>Injected <see cref="JwtSecurityToken"/></param>
        /// <returns>Instance of <see cref="string"/></returns>
        string WriteJwtToken(JwtSecurityToken jwtSecurityToken);

        /// <summary>
        /// Generates Symmetric Security Key
        /// </summary>
        /// <returns>Instance of <see cref="SymmetricSecurityKey"/></returns>
        SymmetricSecurityKey GenerateSymmetricSecurityKey();

        /// <summary>
        /// Generates Signing Credentials
        /// </summary>
        /// <param name="symmetricSecurityKey">>Injected <see cref="SymmetricSecurityKey"/></param>
        /// <returns>Instance of <see cref="SigningCredentials"/></returns>
        SigningCredentials GenerateSigningCredentials(SymmetricSecurityKey symmetricSecurityKey);

        /// <summary>
        /// Generates Token Expiration Date 
        /// </summary>
        /// <returns>Instance of <see cref="DateTime"/></returns>
        DateTime GenerateTokenExpirationDate();

        /// <summary>
        /// Generates Jwt Claims
        /// </summary>
        /// <param name="applicationUser">>Injected <see cref="ApplicationUser"/></param>
        /// <returns>Instance of <see cref="List{Claim}"/></returns>
        Task<List<Claim>> GenerateJwtClaims(AppUser applicationUser);
    }
}
