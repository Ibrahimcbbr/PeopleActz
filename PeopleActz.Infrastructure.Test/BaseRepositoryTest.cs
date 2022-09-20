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
    public  class BaseRepositoryTest
    {
        [Fact]
        public async Task Add_Entity_return_Null()
        {
            var appUser = GetUser();
            var mockBaseRepo = new Mock<IBaseRepository<AppUser>>();

            mockBaseRepo.Setup(x => x.Insert(appUser)).Verifiable();
            mockBaseRepo.Object.Insert(appUser);

            mockBaseRepo.Verify();
        }
        [Fact]
        public async Task Update_Entity_Return_Null()
        {
            var appUser = GetUser();
            var mockBaseRepo = new Mock<IBaseRepository<AppUser>>();

            mockBaseRepo.Setup(x => x.Update(appUser)).Verifiable();
            mockBaseRepo.Object.Update(appUser);
            mockBaseRepo.Verify();

        }

        [Fact]
        public async Task Remove_Entity_Return_Null()
        {
            var appUser = GetUser();
            var mocBaseRepo = new Mock<IBaseRepository<AppUser>>();

            mocBaseRepo.Setup(x => x.Delete(appUser.Id)).Verifiable();
            mocBaseRepo.Object.Delete(appUser.Id);
            mocBaseRepo.Verify();
        }
        [Fact]
        public async Task Return_All_Entities()
        {
            var appUser = GetUser();
            var appUserList = new List<AppUser>() { appUser };

            var mockBaseRepo = new Mock<IBaseRepository<AppUser>>();
            mockBaseRepo.Setup(x => x.GetAll(null, null,null )).ReturnsAsync(appUserList);
            mockBaseRepo.Object.GetAll(null,null,null);
            Assert.True(appUserList.Count() >= 1);

        }
       

        public AppUser GetUser()
        {
            AppUser user = new AppUser() { Id = Guid.NewGuid().ToString(), };

            return user;
        }
    }
}
