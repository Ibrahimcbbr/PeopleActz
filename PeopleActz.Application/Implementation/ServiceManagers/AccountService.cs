using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PeopleActz.Application.DTOs.Requests.AppUser;
using PeopleActz.Application.DTOs.Responses.AppUser;
using PeopleActz.Application.DTOs.Responses.Common;
using PeopleActz.Application.Interfaces.HelperServices;
using PeopleActz.Application.Interfaces.Services;
using PeopleActz.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PeopleActz.Application.Implementation.ServiceManagers
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IMapper _mapper;

        public AccountService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IJwtTokenService jwtTokenService,IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtTokenService = jwtTokenService;
            _mapper = mapper;
        }

        public async Task<Result<ResponseLogin>> Login(LoginRequest request)
        {
            var user = await  _userManager.FindByEmailAsync(request.Email);
            var userRole = await _userManager.GetRolesAsync(user);
            if (user is null)
            {
                return new Result<ResponseLogin>
                {
                    IsSuccessful = false,
                    Info = "there is no e-mail"
                };
            }
            var loginResult = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);
            if (!loginResult.Succeeded)
            {
                return new Result<ResponseLogin>
                {
                    IsSuccessful = false,
                    Info = "Whrong password or whrong e-mail"
                };
            }

            var claim =  await _jwtTokenService.GenerateJwtClaims(user);
            
            string token = _jwtTokenService.WriteJwtToken(_jwtTokenService.GenerateJwtToken(claim));
            var loginresponse = new ResponseLogin
            {
                Token = token,
                Role = userRole
            };
            return new Result<ResponseLogin>
            {
                IsSuccessful = true,
                Info = "Whrong password or whrong e-mail",
                Payload = loginresponse
            };


        }

        public async Task<IdentityResult> Register(RegisterRequest request)
        {
            var user = _mapper.Map<AppUser>(request);
            var result = await _userManager.CreateAsync(user,
            request.Password);
            if (result.Succeeded)
                await _userManager.AddToRolesAsync(user, request.Roles);
            return result;
        }
    }
}
