using Calligraphy.Application.Interfaces.Repositories;
using Calligraphy.Application.Interfaces.Services;
using Calligraphy.Domain.Entities;

namespace Calligraphy.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _userRepository.GetByIdAsync(id);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _userRepository.GetByEmailAsync(email);
    }

    public async Task<User> CreateAsync(User user)
    {
        await _userRepository.AddAsync(user);
        await _userRepository.SaveChangesAsync();

        return user;
    }
    public async Task<List<User>> GetAllAsync()
    {
        return await _userRepository.GetAllAsync();
    }
    public async Task<bool> BlockAsync(int id)
    {
        var blocked = await _userRepository.BlockAsync(id);

        if (!blocked)
            return false;

        await _userRepository.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UnblockAsync(int id)
    {
        var unblocked = await _userRepository.UnblockAsync(id);

        if (!unblocked)
            return false;

        await _userRepository.SaveChangesAsync();

        return true;
    }

}
