using Calligraphy.Application.DTOs.Product;
using Calligraphy.Domain.Entities;

namespace Calligraphy.Application.Interfaces.Services;

public interface IProductService
{
    Task<Product?> GetByIdAsync(int id);

    Task<List<Product>> GetAllAsync();

    Task<Product> CreateAsync(Product product);

    Task<Product?> UpdateAsync(int id,ProductUpdateDto dto);

    Task<bool> DeleteAsync(int id);
}