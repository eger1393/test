using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data.Repository;
using Test.Services.Models;

namespace Test.Services.Services
{
    public interface IAnalyticService
    {
        /// <summary>
        /// Вычисление повторяющеегося удержания
        /// Расчитывается по формуле Количество пользователей, зашедших в день N или позже / Количество пользователей, установивших приложение N дней назад * 100%
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        public Task<double> CalculateRollingRetentionAsync(ushort days);

        /// <summary>
        /// Вычисление распределения времени жизни пользователей
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<LifeSpan>> GetLifeSpanDistribution();
    }

    public class AnalyticService : IAnalyticService
    {
        private readonly IUserRepository _userRepository;

        public AnalyticService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<double> CalculateRollingRetentionAsync(ushort days)
        {
            var activeUsersCount = _userRepository.GetCountActiveUsersAfter(days);
            var registeredUsersCount = _userRepository.GetCountUsersWhoRegisteredEarlierThan(DateTime.Today.AddDays(-days));
            await Task.WhenAll(activeUsersCount, registeredUsersCount);
            var rollingRetention = (double)activeUsersCount.Result / registeredUsersCount.Result * 100;
            return rollingRetention;
        }

        public async Task<IEnumerable<LifeSpan>> GetLifeSpanDistribution()
        {
            var users = await _userRepository.GetAllAsync();
            var lifeSpanDays = users.Select(x => x.LifeSpanDays).ToList();
            var result = lifeSpanDays.Distinct()
                .OrderBy(x => x)
                .Select(x => new LifeSpan()
                {
                    LifeSpanDays = x,
                    Count = lifeSpanDays.Count(lifeSpan => lifeSpan == x)
                });
            return result;
        }
    }
}