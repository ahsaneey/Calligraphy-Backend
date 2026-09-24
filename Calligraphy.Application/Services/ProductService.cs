using Calligraphy.Application.DTOs.Product;
using Calligraphy.Application.Interfaces.Repositories;
using Calligraphy.Application.Interfaces.Services;
using Calligraphy.Domain.Entities;

namespace Calligraphy.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _productRepository.GetByIdAsync(id);
    }

    public async Task<List<Product>> GetAllAsync()
    {
        return await _productRepository.GetAllAsync();
    }

    public async Task<Product> CreateAsync(Product product)
    {
        await _productRepository.AddAsync(product);
        await _productRepository.SaveChangesAsync();

        return product;
    }

    public async Task<Product?> UpdateAsync(int id,ProductUpdateDto dto)
    {
        var existingProduct = await _productRepository.GetByIdAsync(id);

        if (existingProduct == null)
            return null;

        existingProduct.Name = dto.Name;
        existingProduct.Description = dto.Description;
        existingProduct.Price = dto.Price;
        existingProduct.ImageUrl = dto.ImageUrl;
        existingProduct.StockQuantity = dto.StockQuantity;

        await _productRepository.UpdateAsync(existingProduct);
        await _productRepository.SaveChangesAsync();

        return existingProduct;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);

        if (product == null)
            return false;

        await _productRepository.DeleteAsync(product);
        await _productRepository.SaveChangesAsync();

        return true;
    }
}