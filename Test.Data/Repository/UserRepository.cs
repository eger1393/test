using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Test.Data.Models;

namespace Test.Data.Repository
{
    public interface IUserRepository
    {
        Task AddRangeAsync(IEnumerable<User> users);
        Task<List<User>> GetAllAsync();
    }
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public Task AddRangeAsync(IEnumerable<User> users)
        {
            return _context.Users.AddRangeAsync(users);
        }

        public Task<List<User>> GetAllAsync()
        {
            return _context.Users.ToListAsync();
        }
    }
}