using PeopleActz.Infrastructure.Context;
using PeopleActz.Infrastructure.Repositories;
using PeopleActz.Infrastructure.Utils.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleActz.Infrastructure.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly PeopleActzDbContext _context;

        private readonly Lazy<IPostRepository> _postRepository;
        public UnitOfWork(PeopleActzDbContext context)
        {
            _context = context;
            _postRepository = new Lazy<IPostRepository>(() => new PostRepository(context));

        }

        public IPostRepository Post => _postRepository.Value;
        public async Task Save() => await _context.SaveChangesAsync();
    }
}
