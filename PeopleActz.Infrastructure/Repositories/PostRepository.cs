using Microsoft.EntityFrameworkCore;
using PeopleActz.Application.DTOs.Requests.Post;
using PeopleActz.Application.DTOs.Responses.Common;
using PeopleActz.Domain.Entities.Models;
using PeopleActz.Infrastructure.Context;
using PeopleActz.Infrastructure.Utils.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleActz.Infrastructure.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        private readonly PeopleActzDbContext _context;

        
        public PostRepository(PeopleActzDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PagedList<Post>> GetAllPostsAsync(PostParameters postParameters)
        {
                var posts =  await _context.Posts.OrderBy(p => p.Id).
                Skip((postParameters.PageNumber-1)*postParameters.PageSize)
                .Take(postParameters.PageSize).ToListAsync();

            return PagedList<Post>.ToPagedList(posts, postParameters.PageNumber, postParameters.PageSize);
        }
    }
}
