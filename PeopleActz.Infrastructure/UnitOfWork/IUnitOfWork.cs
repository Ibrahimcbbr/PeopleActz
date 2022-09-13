using PeopleActz.Infrastructure.Utils.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleActz.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        IPostRepository Post { get; }
        ICommentRepository Comment { get; }
        void Save();
    }
}
