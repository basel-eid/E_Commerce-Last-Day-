using E_Commerce_Last_Day_.Dtos.PostDtos;
using E_Commerce_Last_Day_.Repos.UserRepos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Last_Day_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepo _repo;
        public UsersController(IUserRepo repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var u = _repo.GetAll();
            return Ok(u);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var u = _repo.GetById(id);
            return Ok(u);
        }
        [HttpPost]
        public IActionResult AddUserAll(User_Dto user_Dto)
        {
            _repo.AddUserAll(user_Dto);
            return Created();
        }
        [HttpPost("UserOnly")]
        public IActionResult Adduser(User_Post_Only_Dto user_Dto)
        {
            _repo.Adduser(user_Dto);
            return Created();
        }
        [HttpPut]
        public IActionResult UpdateUserAll(User_Dto user_Dto , int id)
        {
            _repo.UpdateUserAll(user_Dto, id);
            return Accepted();
        }
        [HttpPut("UserOnly")]
        public IActionResult UpdateUser(User_Only user_Dto, int id)
        {
            _repo.UpdateUser(user_Dto, id);
            return Accepted();
        }
        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            _repo.DeleteUser(id);
            return NoContent();
        }
    }
}
