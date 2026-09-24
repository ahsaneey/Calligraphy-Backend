using System;
using System.Collections.Generic;
using System.Text;
using Calligraphy.Application.Interfaces.Repositories;
using Calligraphy.Domain.Entities;
using Calligraphy.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace Calligraphy.Infrastructure.Repositories;

    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users
           .FirstOrDefaultAsync(u => u.Email == email);
        }
        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users
            .FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
     

