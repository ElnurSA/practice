using System;
using FiorelloProjectFinal.Models;
using FiorelloProjectFinal.ViewModels.Categories;

namespace FiorelloProjectFinal.Services.Interfaces
{
	public interface ICategoryService
	{
		Task<List<Category>> GetAllAsync();
		Task<Category> GetWithProductAsync(int id);
        Task<List<CategoryVM>> GetAllOrderByDescAsync();
        Task<bool> ExistAsync(string name);
        Task CreateAsync(CategoryCreateVM category);
		Task DeleteAsync(Category category);
        Task<Category> GetByIdAsync(int id);
		Task EditAsync(Category category, CategoryEditVM categoryEdit);
		
		




    }
}

