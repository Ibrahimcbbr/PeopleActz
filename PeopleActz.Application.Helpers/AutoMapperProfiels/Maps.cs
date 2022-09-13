using AutoMapper;
using PeopleActz.Application.DTOs.Requests.AppUser;
using PeopleActz.Application.DTOs.Requests.Comment;
using PeopleActz.Application.DTOs.Requests.Post;
using PeopleActz.Application.DTOs.Responses.AppUser;
using PeopleActz.Application.DTOs.Responses.Comment;
using PeopleActz.Application.DTOs.Responses.Post;
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
            //User Profiles
            CreateMap<RegisterRequest, AppUser>().ReverseMap();
            CreateMap<UserResponse, AppUser>().ReverseMap();
            //PostProfiles
            CreateMap<Post, PostCreateRequest>().ReverseMap();
            CreateMap<Post, PostResponse>().ReverseMap();
            CreateMap<Post, PostListResponse>().ReverseMap();
            CreateMap<Post, PostDetailResponse>();
            CreateMap<Post, PostUpdateRequest>().ReverseMap();
            //CommentProfiles
            CreateMap<Comment, CommentCreateRequest>().ReverseMap();
            CreateMap<Comment, CommentDetailResponse>().ReverseMap();
            CreateMap<Comment, CommentUpdateRequest>().ReverseMap();
            CreateMap<Comment, CommentDetailsListResponse>().ReverseMap();
        }
    }
}
