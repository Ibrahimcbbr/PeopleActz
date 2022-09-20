using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeopleActz.Application.DTOs.Requests.Comment;
using PeopleActz.Application.DTOs.Requests.Post;
using PeopleActz.Application.DTOs.Responses.Comment;
using PeopleActz.Application.DTOs.Responses.Common;
using PeopleActz.Application.DTOs.Responses.Post;
using PeopleActz.Application.Interfaces.Services;

namespace PeopleActz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost("CreateComment")]
        public async Task<Result<NoContentResponse>> CreateComment([FromBody] CommentCreateRequest request)
        {
            return  await _commentService.CreateComment(request);
        }
        [HttpGet("GetCommentById")]
        public async Task<ActionResult<Result<CommentDetailResponse>>> GetCommentById(string id)
        {
         return await   _commentService.GetCommentById(id);
        }
        [HttpPost("UpdatePost")]
        public async Task<Result<NoContentResponse>> UpdateComment([FromBody] CommentUpdateRequest request)
        {
            return await _commentService.UpdateComment(request);
        }
        [HttpGet("GetCommentsByPostId")]
        public async Task<Result<List<CommentDetailsListResponse>>>GetCommentByPostId(string postId)
        {
            return await _commentService.GetAllCommentsByPostId(postId);
        }
        [HttpGet("GetCommentsByUserId")]
        public async Task<Result<List<CommentDetailsListResponse>>> GetCommentByUserId(string userId)
        {
            return await _commentService.GetAllCommentsByUserId(userId);
        }
    }
}
