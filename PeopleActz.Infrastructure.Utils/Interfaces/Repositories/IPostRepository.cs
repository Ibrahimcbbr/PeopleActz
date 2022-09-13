using PeopleActz.Application.DTOs.Requests.Post;
using PeopleActz.Application.DTOs.Responses.Common;
using PeopleActz.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleActz.Infrastructure.Utils.Interfaces.Repositories
{
    public interface IPostRepository:IBaseRepository<Post>
    {
        Task<PagedList<Post>> GetAllPostsAsync(PostParameters postParameters);
    }
}
