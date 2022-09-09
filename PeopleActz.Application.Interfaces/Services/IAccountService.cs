using Microsoft.AspNetCore.Identity;
using PeopleActz.Application.DTOs.Requests.AppUser;
using PeopleActz.Application.DTOs.Responses.AppUser;
using PeopleActz.Application.DTOs.Responses.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleActz.Application.Interfaces.Services
{
    public interface IAccountService
    {
        Task<Result<ResponseLogin>> Login(LoginRequest request);
        Task<IdentityResult> Register(RegisterRequest request);
      
    }
}
