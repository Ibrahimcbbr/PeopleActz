using AutoMapper;
using Microsoft.AspNetCore.Http;
using PeopleActz.Application.DTOs.Requests.Comment;
using PeopleActz.Application.DTOs.Responses.Comment;
using PeopleActz.Application.DTOs.Responses.Common;
using PeopleActz.Application.Interfaces.Services;
using PeopleActz.Domain.Entities.Models;
using PeopleActz.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleActz.Application.Implementation.ServiceManagers
{
    public class CommentService : ICommentService
    {
        private readonly IMapper _mapper;
        private readonly IPostService _postService;
        private readonly IUserService _userService;
        private readonly IUnitOfWork _uow;

        public CommentService(IMapper mapper, IPostService postService, IUserService userService, IUnitOfWork uow)
        {
            _mapper = mapper;
            _postService = postService;
            _userService = userService;
            _uow = uow;
        }

        public async Task<Result<NoContentResponse>> CreateComment(CommentCreateRequest request)
        {
            var user = await _userService.GetById(request.UserId);
            if (user is null)
            {
                return new Result<NoContentResponse>
                {
                    Info ="there is no user whit this id",
                    IsSuccessful = false,
                    StatusCode = StatusCodes.Status204NoContent
                };
            }
            var post = await _postService.GetPostById(request.PostId);
            if (post is null)
            {
                return new Result<NoContentResponse>
                {
                    Info = "there is no post whit this id",
                    IsSuccessful = false,
                    StatusCode = StatusCodes.Status204NoContent
                };
            }
            var payload = _mapper.Map<Comment>(request);
            payload.PostId = request.PostId;
            payload.UserId = request.UserId;
            await _uow.Comment.Insert(payload);
            _uow.Save();
            return new Result<NoContentResponse>
            {
                IsSuccessful = true,
                StatusCode = StatusCodes.Status201Created,
                Info ="Successfully Created",
                Payload=payload
                
            };
        }

        public async Task<Result<List<CommentDetailsListResponse>>> GetAllCommentsByPostId(string postId)
        {
            var post =  await _postService.GetPostById(postId);
            if (post is null)
            {
                return new Result<List<CommentDetailsListResponse>>
                {
                    Info = "there is no post whit this id",
                    IsSuccessful = false,
                    StatusCode = StatusCodes.Status204NoContent
                };
            }
            
            var commentByPostId = await _uow.Comment.GetAllCommentsByPostId(postId);
            if (commentByPostId is null)
            {
                return new Result<List<CommentDetailsListResponse>>
                {
                    Info = "This post gone..",
                    IsSuccessful = false,
                    StatusCode = StatusCodes.Status204NoContent
                };
            }
            var payload = _mapper.Map<List<CommentDetailsListResponse>>(commentByPostId);
          
            return new Result<List<CommentDetailsListResponse>>
            {
                Info = "Operation done ",
                IsSuccessful = false,
                StatusCode = StatusCodes.Status200OK,
                Payload = payload
            };
        }

        public async Task<Result<CommentDetailResponse>> GetCommentById(string id)
        {
            var comment = await GetComment(id);
            if (comment is null)
            {
                return new Result<CommentDetailResponse>
                {
                    Info="there is no comment whit this id in the system ",
                    StatusCode = StatusCodes.Status204NoContent,
                    IsSuccessful = false
                };
            }
            var payload = _mapper.Map<CommentDetailResponse>(comment);
            return new Result<CommentDetailResponse>
            {
                Info ="operation done",
                IsSuccessful = true,
                StatusCode = StatusCodes.Status200OK,
                Payload =payload
            };

        }

        public async Task<Result<NoContentResponse>> UpdateComment(CommentUpdateRequest request)
        {
            var post = _postService.GetPostById(request.PostId);
            if (post is null)
            {
                return new Result<NoContentResponse>
                {
                    Info = "there is no post whit this id",
                    IsSuccessful = false,
                    StatusCode = StatusCodes.Status204NoContent
                };
            }
            var user = _userService.GetById(request.UserId);
            if (user is null)
            {
                return new Result<NoContentResponse>
                {
                    Info = "there is no user whit this id",
                    IsSuccessful = false,
                    StatusCode = StatusCodes.Status204NoContent
                };
            }
            var payload = _mapper.Map<Comment>(request);
            payload.PostId = request.PostId;
            payload.UserId = request.UserId;
            _uow.Comment.Update(payload);
            _uow.Save();

            return new Result<NoContentResponse>
            {
                IsSuccessful = true,
                StatusCode = StatusCodes.Status201Created,
                Info = "Successfully Updated",
                Payload = payload

            };


        }

      
        


        private async Task<Comment> GetComment(string id)
        {
            return await  _uow.Comment.GetCommentById(id);
        } 

    }
}
