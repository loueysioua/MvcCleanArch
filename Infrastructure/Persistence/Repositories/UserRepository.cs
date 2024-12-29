using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MvcCleanArch.Domain.Interfaces;
using MvcCleanArch.Domain.Models;
using MvcCleanArch.Infrastructure.Persistence.DbContext;

namespace MvcCleanArch.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IGenericRepository<AppUser> _genericRepository;

        public UserRepository(IGenericRepository<AppUser> genericRepository, ApplicationDbContext dbContext)
        {
            _genericRepository = genericRepository;
            _dbContext = dbContext;
        }

        public async Task AddAsync(AppUser user)
        {
            await _genericRepository.AddAsync(user);
        }

        public async Task DeleteAsync(string id)
        {
            var user = await _genericRepository.GetByIdAsync(id);
            if (user != null)
            {
                await _genericRepository.DeleteAsync(user);
            }
        }

        public async Task<IEnumerable<AppUser>> GetAllAsync()
        {
            return await _genericRepository.GetAllAsync();
        }

        public async Task<AppUser> GetByIdAsync(string id)
        {
            return await _genericRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(AppUser user)
        {
            await _genericRepository.UpdateAsync(user);
        }
    }
}