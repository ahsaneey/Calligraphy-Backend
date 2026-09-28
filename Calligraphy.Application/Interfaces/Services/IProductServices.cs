using Calligraphy.Application.DTOs.Product;
using Calligraphy.Domain.Entities;

namespace Calligraphy.Application.Interfaces.Services;

public interface IProductService
{
    Task<Product?> GetByIdAsync(int id);

    Task<List<Product>> GetAllAsync();

    Task<List<Product>> GetAllForAdminAsync();

    Task<Product> CreateAsync(Product product);

    Task<Product?> UpdateAsync(int id, ProductUpdateDto dto);

    Task<bool> DeleteAsync(int id);

    Task<bool> HardDeleteAsync(int id);

    Task<bool> RestoreAsync(int id);
}