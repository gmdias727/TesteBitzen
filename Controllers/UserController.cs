using Microsoft.AspNetCore.Mvc;
using TesteBitzen.Models;
using TesteBitzen.Repositories.Interfaces;
using TesteBitzen.ViewModels;

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
        public async Task<ActionResult<UserModel>> AddUser([FromBody] CreateUserViewModel user)
        {
            var providedUser = new UserModel
            {
                UserName = user.UserName,
                UserEmail = user.UserEmail,
                UserPhone = user.UserPhone,
            };

            UserModel ProvidedUser = await _userRepository.AddUser(providedUser);
            return Ok(ProvidedUser);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> UpdateUser([FromBody] UpdateUserViewModel userModel, int id)
        {
            var user = await _userRepository.GetUserById(id);

            if (user == null)
            {
                return NotFound("User not found");
            }

            user.UserName = userModel.UserName ?? user.UserName;
            user.UserPhone = userModel.UserPhone ?? user.UserPhone;
            user.UserEmail = userModel.UserEmail ?? user.UserEmail;

            await _userRepository.UpdateUser(user, id);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<VehicleModel>> DeleteUser(int userId)
        {
            bool ProvidedUser= await _userRepository.DeleteUser(userId);
            return Ok(ProvidedUser);
        }
    }
}