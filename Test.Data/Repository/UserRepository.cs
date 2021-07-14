using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Test.Data.Models;

namespace Test.Data.Repository
{
    public interface IUserRepository
    {
        /// <summary>
        /// Добавление списка пользователей в БД
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        Task AddRangeAsync(IEnumerable<User> users);
        
        /// <summary>
        /// Получение всех пользователей из БД
        /// </summary>
        /// <returns></returns>
        Task<List<User>> GetAllAsync();

        /// <summary>
        /// Кол-во пользователей зарегестрированных ранее чем date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        Task<int> GetCountUsersWhoRegisteredEarlierThanAsync(DateTime date);

        /// <summary>
        /// Кол-во пользователей время жизни (RegistrationDate - LastActivityDate) которых больше чем days
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        Task<int> GetCountActiveUsersAfterAsync(ushort days);

        /// <summary>
        /// Удаление всех пользователей
        /// </summary>
        /// <returns></returns>
        Task DeleteAllAsync();
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
            // возвращаем List для того что-бы не давать возможность выносить логику работы с БД из репозитория
            // если бы мы вернули IQueriable то был бы шанс на не добросовестное исспользование (построение запроса к бд например из контроллера)
            return _context.Users.ToListAsync();
        }

        public async Task<int> GetCountUsersWhoRegisteredEarlierThanAsync(DateTime date)
        {
            return _context.Users.CountAsync(x => x.RegistrationDate <= date);
        }

        public Task<int> GetCountActiveUsersAfterAsync(ushort days)
        {
            return _context.Users.CountAsync(x => x.LifeSpanDays >= days);
        }

        public async Task DeleteAllAsync()
        {
            var users = await _context.Users.ToListAsync();
            _context.Users.RemoveRange(users);
            await _context.SaveChangesAsync();
        }
    }
}