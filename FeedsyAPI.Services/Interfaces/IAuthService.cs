using System.Collections.Generic;
using System.Threading.Tasks;
using FeedsyAPI.Models;

namespace FeedsyAPI.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<User> GetUserByIdAsync(string userId);

        public Task<IEnumerable<User>> GetAllUsersAsync();

        public Task CreateUserAsync(User user);

        public Task UpdateUserAsync(User user);

        public Task DeleteUserAsync(string userId);
    }
}