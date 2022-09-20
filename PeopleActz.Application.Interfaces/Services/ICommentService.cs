using PeopleActz.Application.DTOs.Requests.Comment;
using PeopleActz.Application.DTOs.Responses.Comment;
using PeopleActz.Application.DTOs.Responses.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleActz.Application.Interfaces.Services
{
    public interface ICommentService
    {
        Task<Result<NoContentResponse>> CreateComment(CommentCreateRequest request);
        Task<Result<CommentDetailResponse>>GetCommentById(string id);
        Task<Result<NoContentResponse>> UpdateComment(CommentUpdateRequest request);
        Task<Result<List<CommentDetailsListResponse>>> GetAllCommentsByPostId(string postId);   
        Task<Result<List<CommentDetailsListResponse>>> GetAllCommentsByUserId(string userId);
    }
}
