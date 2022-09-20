using AutoFixture;
using AutoMapper;
using Moq;
using PeopleActz.Application.DTOs.Requests.Post;
using PeopleActz.Application.DTOs.Responses.Common;
using PeopleActz.Application.DTOs.Responses.Post;
using PeopleActz.Application.Implementation.ServiceManagers;
using PeopleActz.Domain.Entities.Models;
using PeopleActz.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PeopleActz.Application.Tests.CommentService
{
    public class PostServiceTest
    {

        private PostService _service;
        private Mock<IUnitOfWork> _uow;
        private Mock<IMapper> _mapper;
        private Fixture _fixture;


        public PostServiceTest()
        {
            _mapper = new Mock<IMapper>();
            _uow = new Mock<IUnitOfWork>();
            _service = new PostService(_mapper.Object, _uow.Object);
            _fixture = new Fixture();
            
        }


        [Theory]
        [InlineData("B8E0A6E7-229C-4F9D-B625-A0252518BBA2")]
        public async Task Get_InValit_Id_return_Null(string postId)
        {
            Post post = null;
            _uow.Setup(x => x.Post.Get(x => x.Id == postId,null).Result).Returns(post);



            _mapper.Setup(p => p.Map<Post, PostDetailResponse>(post)).Returns(new PostDetailResponse());


            var result = await _service.GetPostById(postId);


            Assert.NotNull(result);
            Assert.True(result is Result<PostDetailResponse>);

            Assert.Equal(result.Payload,post);
        }
        [Fact]
        public async Task Should_Create_Post()
        {

            var post = _fixture.Create<Post>();
       
            
              
            

            


        }

      

    }
}
