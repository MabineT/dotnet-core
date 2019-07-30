using System.Collections.Generic;
using System.Threading.Tasks;
using causal.api.Data;
using causal.api.Models;
using Microsoft.EntityFrameworkCore;

namespace causal.api.Helpers
{
    public class Helper : IHelper
    {
        private readonly DataContext _context;

        public Helper(DataContext context)
        {
            _context = context;
        }

        public async Task<User> AddUserAsync(User user)
        {

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> GetUserAsync(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (user.Equals(null))
            {
                return null;
            }
            return user;
        }


        public async Task<ICollection<User>> GetAllUsers()
        {
            var user = await _context.Users.ToListAsync();
            return user;
        }

        public async Task<User> RemoveUserAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);

            if (!(user == null))
            {
                _context.Users.Remove(user);
                // delete contact details.
                await _context.SaveChangesAsync();
                return user;
            }
            return null;
        }

        public async Task<User> UpdateUserAsync(int userId, User user)
        {
            var userToUpdate = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (!userToUpdate.Equals(null))
            {
                userToUpdate.Name = user.Name;
                userToUpdate.IdentityNumber = user.IdentityNumber;
                userToUpdate.PassportNumber = user.PassportNumber;

                _context.Users.Update(userToUpdate);
                // update contact details here.
                await _context.SaveChangesAsync();
                return userToUpdate;
            }
            return null;
        }
    }
}