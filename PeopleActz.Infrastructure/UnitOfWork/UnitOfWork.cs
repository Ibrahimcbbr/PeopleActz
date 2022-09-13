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
    public class UnitOfWork:IUnitOfWork,IDisposable
    {
        private readonly PeopleActzDbContext _context;

        private readonly Lazy<IPostRepository> _postRepository;
        private readonly Lazy<ICommentRepository> _commentRepository;
        public UnitOfWork(PeopleActzDbContext context)
        {
            _context = context;
            _postRepository = new Lazy<IPostRepository>(() => new PostRepository(context));
            _commentRepository = new Lazy<ICommentRepository>(() => new CommentRepository(context));    

        }

        public IPostRepository Post => _postRepository.Value;

        public ICommentRepository Comment => _commentRepository.Value;

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
