using System;
using FiorelloProjectFinal.Models;

namespace FiorelloProjectFinal.Services.Interfaces
{
	public interface IProductService
	{
        Task<List<Product>> GetAllAsync();
        Task<Product> GetById(int id);
    }
}

