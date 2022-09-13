using PeopleActz.Application.DTOs.Requests.Post;
using PeopleActz.Application.DTOs.Responses.Common;
using PeopleActz.Application.DTOs.Responses.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleActz.Application.Interfaces.Services
{
    public interface IPostService
    {
        Task<Result<PostResponse>> CreatePost(PostCreateRequest request);
        Task<(IEnumerable<PostListResponse> posts, MetaData metaData)> GetAllPosts(PostParameters postParameters);
        Task<Result<PostDetailResponse>>GetPostById(string id);
        Task<Result<NoContentResponse>>RemovePost(string id);
        Task<Result<NoContentResponse>> UpdatePost(PostUpdateRequest request);

      
    }
}
