using AutoFixture;
using Moq;
using PeopleActz.Domain.Entities.Models;
using PeopleActz.Infrastructure.Utils.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PeopleActz.Infrastructure.Test
{
    public class PostRepositoryTest
    {
        private readonly Mock<IPostRepository> _mockpostRepository = new Mock<IPostRepository>();
        protected readonly Fixture _fixture = new Fixture();

        [Fact]
        public async Task Return_Posts()
        {


            var post = GetPost();

            _mockpostRepository.Setup(x => x.GetAll(post.Lis)).ReturnsAsync();



        }



       public Post GetPost()
        {
            Post post = new Post
            {
                Id = Guid.NewGuid().ToString(),
                Body = "BESİKTAS",
                Name = " BESİKTAS",
                UserId = Guid.NewGuid().ToString(),
                Title = "Şampiyon",
                Comments = null,
                
            };

            return post;
        }
       

    }
}
