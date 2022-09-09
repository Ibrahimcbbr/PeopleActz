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
        public PostRepository(PeopleActzDbContext context) : base(context)
        {
        }
    }
}
