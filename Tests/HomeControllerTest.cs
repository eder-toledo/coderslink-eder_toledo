using BackEnd.Controllers;
using BackEnd.Models;
using BackEnd.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Tests
{
    public class HomeControllerTest
    {
        HomeController _controller;
        IUserService _service;

        public HomeControllerTest() {
            _service = new LocalUserService();
            _controller = new HomeController(_service);

        }

        [Fact]
        public void LoginUserTest() {
            var user = new User()
            {
                firstName = "Eder",
                lastName = "Toledo",
                email = "edertoledon@gmail.com"
            };

            var createResponse = _controller.LoginUser(user);
            Assert.IsType<OkObjectResult>(createResponse);

            var item = createResponse as OkObjectResult;
            Assert.IsType<User>(item.Value);

            var userItem = item.Value as User;
            Assert.Equal(user.firstName, userItem.firstName);
            Assert.Equal(user.lastName, userItem.lastName);
            Assert.Equal(user.email, userItem.email);

        }

        [Fact]
        public void GetEmailListTest() {
            var result = _controller.GetEmailList(null, null);

            var okResult = result as OkObjectResult;

            Assert.NotNull(okResult);
            Assert.True(okResult is OkObjectResult);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }
    }
}
