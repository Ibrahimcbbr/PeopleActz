using PeopleActz.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleActz.Infrastructure.Utils.Interfaces.Repositories
{
    public interface ICommentRepository:IBaseRepository<Comment>
    {
        Task<Comment> GetCommentById(string id);
        Task<List<Comment>> GetAllCommentsByPostId(string id);
    }
}
