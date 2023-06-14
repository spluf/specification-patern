using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Capon.Users.Domain.Contracts.Services;
using Capon.Users.Application.Services;
using Capon.Users.Domain.Models.ViewModels;

namespace CapOn.Users.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        public UsersController(IUserService userService) 
        {
            this.userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult> Register(UserVM user)
        {
            await userService.RegisterUser(user);
            return Ok();
        }

        [HttpGet]
        public async Task<UserVM[]> Get()
        {
            var result = await userService.Get();
            return result;
        }
    }
}
