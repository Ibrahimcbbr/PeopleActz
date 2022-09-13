using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PeopleActz.Application.DTOs.Responses.AppUser;
using PeopleActz.Application.DTOs.Responses.Common;
using PeopleActz.Application.Interfaces.Services;
using PeopleActz.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleActz.Application.Implementation.ServiceManagers
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public UserService(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<UserResponse>>> GetAll()
        {
            var users = await _userManager.Users.ToListAsync();
            var payload = _mapper.Map<IEnumerable<AppUser>>(users);
            

            return new Result<IEnumerable<UserResponse>>
            {
                IsSuccessful = true,
                Payload = _mapper.Map<IEnumerable<UserResponse>>(payload)
            };
        }

        public async Task<Result<Result<UserResponse>>> GetById(string id)
        {
           var user = await _userManager.FindByIdAsync(id);
            if (user is null)
            {
                return new Result<Result<UserResponse>>
                {
                    IsSuccessful = false,
                    Info = "There is no user whit that id in the system",
                    StatusCode = StatusCodes.Status204NoContent
                };
            }

            return new Result<Result<UserResponse>>
            {
                IsSuccessful = true,
                Payload = _mapper.Map<AppUser>(user),
                StatusCode=StatusCodes.Status200OK
            };
        }
    }
}
