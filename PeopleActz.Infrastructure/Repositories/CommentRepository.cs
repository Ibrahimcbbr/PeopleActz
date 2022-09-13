using Microsoft.EntityFrameworkCore;
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
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        private readonly PeopleActzDbContext _context;
        public CommentRepository(PeopleActzDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Comment>> GetAllCommentsByPostId(string id)
        {
          var commentByPostId =await _context.Comments.
                Include(x=>x.Post).
                OrderBy(x => x.PostId == id).
                ToListAsync();
          return commentByPostId;
        }

        public async Task<Comment> GetCommentById(string id)
        {
            var comment = await Get(x => x.Id == id);
            return comment;
            
        }
    }
}
