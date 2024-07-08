using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementSystem.Controllers;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace LibraryManagementSystem.Tests.Controllers
{
    public class UsersControllerTests
    {
        private DbContextOptions<ApplicationDbContext> GetDbContextOptions()
        {
            return new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "LibraryTestDb")
                .Options;
        }

        [Fact]
        public async Task GetUsers_ReturnsAllUsers()
        {
            // Arrange
            var options = GetDbContextOptions();
            using (var context = new ApplicationDbContext(options))
            {
                context.Users.Add(new User { Username = "TestUser1", Password = "Password1" });
                context.Users.Add(new User { Username = "TestUser2", Password = "Password2" });
                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                var controller = new UsersController(context);

                // Act
                var result = await controller.GetUsers();

                // Assert
                var users = Assert.IsType<List<User>>(result.Value);
                Assert.Equal(2, users.Count);
            }
        }
    }
}
