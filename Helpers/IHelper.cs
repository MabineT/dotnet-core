using System.Collections.Generic;
using System.Threading.Tasks;
using causal.api.Models;

namespace causal.api.Helpers
{
    public interface IHelper
    {
        Task<User> AddUserAsync(User user);

        Task<User> RemoveUserAsync(int userId);

        Task<User> GetUserAsync(int userId);

        Task<User> UpdateUserAsync(int userId, User user);

        Task<ICollection<User>> GetAllUsers();
    }
}