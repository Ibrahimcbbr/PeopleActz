using PeopleActz.Application.DTOs.Responses.AppUser;
using PeopleActz.Application.DTOs.Responses.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleActz.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<Result<IEnumerable<UserResponse>>> GetAll();
        Task<Result<Result<UserResponse>>> GetById(string id);
    }
}
