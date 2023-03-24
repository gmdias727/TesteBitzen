using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using TesteBitzen.Models;
using TesteBitzen.Repositories;
using TesteBitzen.Repositories.Interfaces;

namespace TesteBitzen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> GetAllUsers()
        {
            List<UserModel> users = await _userRepository.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetUserById(int id)
        {
            UserModel user =  await _userRepository.GetUserById(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> AddUser([FromBody] UserModel userModel)
        {
            UserModel ProvidedUser = await _userRepository.AddUser(userModel);
            return Ok(ProvidedUser);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> UpdateUser([FromBody] UserModel userModel, int id)
        {
            userModel.UserId = id;
            UserModel ProvidedUser = await _userRepository.UpdateUser(userModel, id);
            return Ok(ProvidedUser);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<VehicleModel>> DeleteUser(int userId)
        {
            bool ProvidedUser= await _userRepository.DeleteUser(userId);
            return Ok(ProvidedUser);
        }
    }
}
