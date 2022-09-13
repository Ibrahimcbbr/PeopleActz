using AutoMapper;
using Microsoft.AspNetCore.Http;
using PeopleActz.Application.DTOs.Requests.Post;
using PeopleActz.Application.DTOs.Responses.Common;
using PeopleActz.Application.DTOs.Responses.Post;
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
    public class PostService : IPostService
    {
      
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public PostService( IMapper mapper, IUnitOfWork uow)
        {
          
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<Result<PostResponse>> CreatePost(PostCreateRequest request)
        {
            var post = _mapper.Map<Post>(request);
            request.UserId = post.UserId;
            var payload =  _uow.Post.Insert(post);
              
             _uow.Save();
            return new Result<PostResponse>
            {
                Info = "this is your post",
                IsSuccessful = true,
                StatusCode = StatusCodes.Status201Created,
                Payload =payload
            };      
        }

      

        public async Task<Result<NoContentResponse>> RemovePost(string id)
        {
            var post = await GetPost(id);
            var payload = _mapper.Map<Post>(post);

            if (post is null)
            {
                return new Result<NoContentResponse>
                {
                    Info = "there is no post whit this id",
                    StatusCode = StatusCodes.Status204NoContent,
                    IsSuccessful = false
                };
            }
            await _uow.Post.Delete(payload.Id);
             _uow.Save();
            return new Result<NoContentResponse>
            {
                Info = "Successfully Removed",
                IsSuccessful = true,

            };
        }

        public async Task<(IEnumerable<PostListResponse> posts, MetaData metaData)> GetAllPosts(PostParameters postParameters)
        {
            var postMeta = await _uow.Post.GetAllPostsAsync(postParameters);

            var posts = _mapper.Map<IEnumerable<PostListResponse>>(postMeta);

            return (posts: posts,  MetaData: postMeta.MetaData);
        }

        public async Task<Result<PostDetailResponse>> GetPostById(string id)
        {
            if (id is  null)
            {
                return new Result<PostDetailResponse>
                {
                    IsSuccessful = false,
                    Info = "there is no post whit this id in the system!!",
                    StatusCode = StatusCodes.Status204NoContent
                };
             
            }
            var postFromDb = await GetPost(id);
           
            var payload = _mapper.Map<PostDetailResponse>(postFromDb);


            return new Result<PostDetailResponse>
            {
                Info = "Operation Done",
                IsSuccessful = true,
                StatusCode = StatusCodes.Status200OK
              

            };
        }

        public async Task<Result<NoContentResponse>> UpdatePost(PostUpdateRequest request)
        {
            var post = await GetPost(request.Id);
            var postDto = _mapper.Map<Post>(post);
            _uow.Post.Update(postDto);
             _uow.Save();
            return new Result<NoContentResponse>
            {
                Info = "Post successfully updated",
                IsSuccessful = true,
                StatusCode = StatusCodes.Status200OK
            };


        }

        private async Task<Post> GetPost(string id)
        {
           var post = await _uow.Post.Get(x => x.Id == id);
           return post; 
        }

        
    }
}
