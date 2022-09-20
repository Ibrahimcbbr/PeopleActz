using AutoFixture;
using AutoMapper;
using Moq;
using PeopleActz.Application.Interfaces.Services;
using PeopleActz.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleActz.Application.Tests.CommentService
{
    public class CommentServiceTestsBase
    {
        protected readonly Fixture _fixture = new Fixture();
        protected Mock<IMapper> _mapper;
        protected Mock<IUnitOfWork> _uow;
        protected Mock<ICommentService> _commentService;
        public CommentServiceTestsBase()
        {
            _commentService = new Mock<ICommentService>(_uow.Object,_mapper.Object);
            _mapper = new Mock<IMapper>();
            _uow = new Mock<IUnitOfWork>();
            
        }

    }
}
