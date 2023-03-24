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
        public async Task<ActionResult<UserModel>> AddUser([FromBody] UserDTO user)
        {
            var providedUser = new UserModel
            {
                UserName = user.UserName,
                UserEmail = user.UserEmail,
                UserPhone = user.UserPhone,

                Vehicle = new VehicleModel
                {
                    VehicleName = user.Vehicle?.VehicleName,
                    VehicleAssembler = user.Vehicle?.VehicleAssembler,

                    VehicleCategory = new VehicleCategoryModel
                    {
                        VehicleCategory = user.Vehicle?.Category.VehicleCategory,
                        VehicleFuelType = user.Vehicle?.Category.VehicleFuelType,
                        VehicleRentCost = user.Vehicle?.Category.VehicleRentCost,
                    }
                }
            };

            UserModel ProvidedUser = await _userRepository.AddUser(providedUser);
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

public record UserDTO
{
    public string? UserName { get; set; }
    public string? UserEmail { get; set; }
    public string? UserPhone { get; set; }

    public VehicleDTO? Vehicle { get; set; }


    public record VehicleDTO
    {
        public string? VehicleName { get; set; }
        public string? VehicleAssembler { get; set; }
        public CategoryDTO Category { get; set; }

        public record CategoryDTO
        {
            public string? VehicleCategory { get; set; }
            public string? VehicleFuelType { get; set; }
            public double? VehicleRentCost { get; set; }
        }
    }
}