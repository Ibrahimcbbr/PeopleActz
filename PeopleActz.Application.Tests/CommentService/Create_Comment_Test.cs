using AutoFixture;
using Moq;
using PeopleActz.Application.DTOs.Requests.Comment;
using PeopleActz.Application.DTOs.Responses.Common;
using PeopleActz.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PeopleActz.Application.Tests.CommentService
{
    public class Create_Comment_Test:CommentServiceTestsBase
    {
        private readonly CommentCreateRequest _request;
        private readonly Comment _comment;
        public Create_Comment_Test()
        {
            _request = _fixture.Create<CommentCreateRequest>();
            _comment = _fixture.Create<Comment>();

            _mapper.Setup(x => x.Map<CommentCreateRequest>(It.IsAny<Comment>)).Returns(_request);
            _mapper.Setup(x => x.Map<Comment>(It.IsAny<CommentCreateRequest>)).Returns(_comment);
        }

        [Fact]
        public async Task Create_Commnet_And_Return()
        {
          
        }
    }
}
