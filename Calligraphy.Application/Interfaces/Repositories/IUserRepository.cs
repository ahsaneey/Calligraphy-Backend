using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Calligraphy.Domain.Entities;

namespace Calligraphy.Application.Interfaces.Repositories;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email);

    Task<User?> GetByIdAsync(int id);

    Task AddAsync(User user);

    Task SaveChangesAsync();
}
