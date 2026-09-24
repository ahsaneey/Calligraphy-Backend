using Calligraphy.Application.Interfaces.Repositories;
using Calligraphy.Domain.Entities;
using Calligraphy.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Calligraphy.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _context.Products
            .FirstOrDefaultAsync(p => p.Id == id);
    }
    public async Task<List<Product>> GetAllAsync()
    {
        return await _context.Products
            .ToListAsync();
    }

    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
    }

    
    public async Task UpdateAsync(Product product)
    {
        _context.Products.Update(product);
    }

    public async Task DeleteAsync(Product product)
    {
        _context.Products.Remove(product);
    }


    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}