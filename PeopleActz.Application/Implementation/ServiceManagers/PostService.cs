using AutoMapper;
using PeopleActz.Application.DTOs.Requests.Post;
using PeopleActz.Application.DTOs.Responses.Common;
using PeopleActz.Application.DTOs.Responses.Post;
using PeopleActz.Application.Interfaces.Services;
using PeopleActz.Infrastructure.Utils.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleActz.Application.Implementation.ServiceManagers
{
    public class PostService : IPostService
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public PostService(IUserService userService, IMapper mapper, IUnitOfWork uow)
        {
            _userService = userService;
            _mapper = mapper;
            _uow = uow;
        }

        public Task<Result<PostResponse>> CreatePost(PostCreateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
