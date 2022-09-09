using AutoMapper;
using PeopleActz.Application.DTOs.Requests.AppUser;
using PeopleActz.Application.DTOs.Responses.AppUser;
using PeopleActz.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleActz.Application.Helpers.AutoMapperProfiels
{
    public class Maps:Profile
    {
        public Maps()
        {
            CreateMap<RegisterRequest, AppUser>().ReverseMap();
            CreateMap<UserResponse, AppUser>();

        }
    }
}
