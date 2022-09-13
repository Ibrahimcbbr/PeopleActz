using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PeopleActz.Application.DTOs.Requests.Post;
using PeopleActz.Application.DTOs.Responses.AppUser;
using PeopleActz.Application.DTOs.Responses.Common;
using PeopleActz.Application.DTOs.Responses.Post;
using PeopleActz.Application.Implementation.ServiceManagers;
using PeopleActz.Application.Interfaces.Services;
using System.Text.Json;

namespace PeopleActz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost("CreatePost")]
        public async Task<Result<PostResponse>> CreatePost([FromBody] PostCreateRequest request)
        {
            return  await _postService.CreatePost(request);

            

        }
        [HttpGet("GetAllPosts")]
        public async Task<IActionResult> GetAllPosts([FromQuery] PostParameters postParameters)
        {
            var postPagedResponse = await _postService.GetAllPosts(postParameters);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(postPagedResponse.metaData));

            return Ok(postPagedResponse.posts);

        }
        [HttpGet("GetPostById")]
        public async Task<ActionResult<Result<PostDetailResponse>>> GetPostById(string id)
        {
            var post = await _postService.GetPostById(id);
            return StatusCode(post.StatusCode, post.Payload);
        }
        [HttpDelete("DeletePost")]
        public async Task<Result<NoContentResponse>>DeletePost(string id)
        {
            return await _postService.RemovePost(id);
        
        }
        [HttpPost("UpdatePost")]
        public async Task<Result<NoContentResponse>> UpdatePost(  PostUpdateRequest request)
        {
            return await  _postService.UpdatePost(request);
            
        }
    }
}
