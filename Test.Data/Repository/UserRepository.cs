using System;
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

        Task<int> GetCountUsersWhoRegisteredEarlierThan(DateTime date);
        Task<int> GetCountActiveUsersAfter(ushort days);
    }
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddRangeAsync(IEnumerable<User> users)
        {
            await _context.Users.AddRangeAsync(users);
            await _context.SaveChangesAsync();
        }

        public Task<List<User>> GetAllAsync()
        {
            return _context.Users.ToListAsync();
        }

        public Task<int> GetCountUsersWhoRegisteredEarlierThan(DateTime date)
        {
            return _context.Users.CountAsync(x => x.RegistrationDate <= date);
        }

        public Task<int> GetCountActiveUsersAfter(ushort days)
        {
            return _context.Users.CountAsync(x =>  x.LifeSpanDays >= days);
        }
    }
}