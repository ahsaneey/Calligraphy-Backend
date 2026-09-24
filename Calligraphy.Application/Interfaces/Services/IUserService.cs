using Calligraphy.Domain.Entities;

namespace Calligraphy.Application.Interfaces.Services;

public interface IUserService
{
    Task<User?> GetByIdAsync(int id);

    Task<User?> GetByEmailAsync(string email);

    Task<User> CreateAsync(User user);
}