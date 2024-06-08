using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FiorelloProjectFinal.Models;
using FiorelloProjectFinal.Data;
using Microsoft.EntityFrameworkCore;
using FiorelloProjectFinal.ViewModels;
using FiorelloProjectFinal.Services.Interfaces;

namespace FiorelloProjectFinal.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;

    public HomeController(AppDbContext context,
                          IProductService productService,
                          ICategoryService categoryService)
    {
        _context = context;
        _productService = productService;
        _categoryService = categoryService;
    }

    public async  Task<IActionResult> Index()
    {
        List<Slider> sliders = await _context.Sliders.Where(m => !m.SoftDeleted).ToListAsync();
        SliderInfo sliderInfo = await _context.SliderInfos.Where(m => !m.SoftDeleted).FirstOrDefaultAsync();
        List<Category> categories = await _categoryService.GetAllAsync();
        List<Product> products = await _productService.GetAllAsync();
        List<Blog> blogs = await _context.Blogs.Take(3).ToListAsync();


        HomeVM model = new()
        {
            Sliders = sliders,
            SliderInfo = sliderInfo,
            Categories = categories,
            Products = products,
            Blogs = blogs
        };

        return View(model);
    }
}

