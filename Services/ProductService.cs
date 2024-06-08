using System;
using FiorelloProjectFinal.Data;
using FiorelloProjectFinal.Models;
using FiorelloProjectFinal.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FiorelloProjectFinal.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.Where(m => !m.SoftDeleted).Include(m => m.ProductImage).ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Products.Where(m => !m.SoftDeleted)
                                          .Include(m => m.Category)
                                          .Include(m => m.ProductImage)
                                          .FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}

