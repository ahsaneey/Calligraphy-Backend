using Calligraphy.Domain.Entities;

namespace Calligraphy.Application.Interfaces.Repositories;

public interface IOrderRepository
{
    Task AddOrderAsync(Order order);

    Task<Order?> GetOrderByIdAsync(int id);

    Task<List<Order>> GetOrdersByUserIdAsync(int userId);

    Task SaveChangesAsync();
}