using System;
using System.Collections.Generic;
using FiorelloProjectFinal.Data;
using FiorelloProjectFinal.Models;
using FiorelloProjectFinal.Services.Interfaces;
using FiorelloProjectFinal.ViewModels.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FiorelloProjectFinal.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CategoryController : Controller
	{
		private readonly AppDbContext _context;
        private readonly ICategoryService _categoryService;

        public CategoryController(AppDbContext context, ICategoryService categoryService)
		{
			_context = context;
            _categoryService = categoryService;

        }


		[HttpGet]
        [Authorize(Roles ="SuperAdmin,Admin")]
		public async Task<IActionResult> Index()
		{

            return View(await _categoryService.GetAllOrderByDescAsync());
		}

        [HttpGet]
        [Authorize(Roles ="SuperAdmin")]
        public IActionResult Create()
        {
			return View();
           
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(CategoryCreateVM category)
        {
            if (!ModelState.IsValid) return View();
            bool existCategory = await _categoryService.ExistAsync(category.Name);
            if (existCategory) { ModelState.AddModelError("Name", "This category already exist"); return View(); }
            await _categoryService.CreateAsync(category);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            Category category = await _categoryService.GetWithProductAsync((int)id);
            if (category is null) return NotFound();
            CategoryDetailVM model = new CategoryDetailVM()
            {
                Name = category.Name,
                Count = category.Products.Count()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();
            Category category = await _categoryService.GetWithProductAsync((int)id);
            if (category is null) return NotFound();

            await _categoryService.DeleteAsync(category);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();
            Category category = await _categoryService.GetByIdAsync((int)id);
            if (category is null) return NotFound();



            return View(new CategoryEditVM { Id = category.Id, Name = category.Name});

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, CategoryEditVM category)
        {
            if (id is null) return BadRequest();

            Category existCategory = await _categoryService.GetByIdAsync((int)id);

            if (existCategory is null) return NotFound();

            await _categoryService.EditAsync(existCategory, category);

            return RedirectToAction (nameof(Index));

        }
    }
}

