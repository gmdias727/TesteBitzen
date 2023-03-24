using Microsoft.EntityFrameworkCore;
using TesteBitzen.Data;
using TesteBitzen.Models;
using TesteBitzen.Repositories.Interfaces;

namespace TesteBitzen.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly VehicleRentDbContext _dbContext;
        public UserRepository(VehicleRentDbContext vehicleRentDbContext) 
        {
            _dbContext = vehicleRentDbContext;
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> GetUserById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.UserId == id);
        }

        public async Task<UserModel> AddUser(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }


        public async Task<UserModel> UpdateUser(UserModel user, int id)
        {
            UserModel ProvidedUser = await GetUserById(id) ?? throw new Exception($"User ID: {id} was not found");

            ProvidedUser.UserName = user.UserName;
            ProvidedUser.UserEmail = user.UserEmail;
            ProvidedUser.UserPhone = user.UserPhone;


            _dbContext.Users.Update(ProvidedUser);
            await _dbContext.SaveChangesAsync();

            return ProvidedUser;
        }

        public async Task<bool> DeleteUser(int id)
        {
            UserModel ProvidedUser = await GetUserById(id) ?? throw new Exception($"User ID: {id} was not found");

            _dbContext.Users.Remove(ProvidedUser);
            await _dbContext.SaveChangesAsync();

            return true;

        }
    }
}
