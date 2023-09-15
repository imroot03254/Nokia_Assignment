using BrokenAPI.Interface;
using BrokenAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrokenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IUserService _userService;
        public HomeController(IUserService userService)
        {
                _userService = userService;
        }
        [HttpGet]
        public async Task<List<User>> Get(string? sSearch)
        {
            return await  _userService.GetUsers(sSearch);
            
        }
    }
}
