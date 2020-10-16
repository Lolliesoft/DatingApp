using System.Threading.Tasks;
using Datingapp.API.Data;
using Datingapp.API.Dtos;
using Datingapp.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Datingapp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        //Inject IAuthRespository
        public AuthController(IAuthRepository repo)
        {
            _repo = repo;

        }

        //method after mnaking the structure
        [HttpPost("register")]

        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if (await _repo.UserExisits(userForRegisterDto.Username))
                 return BadRequest("Username already exists");
            var userToCreate = new User 
            {
                Username = userForRegisterDto.Username
            };

            var createdUser = await _repo.Register(userToCreate, userForRegisterDto.Password);
            

            return StatusCode(201);
        }
    }
}