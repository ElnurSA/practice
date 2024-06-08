﻿using System;
using FiorelloProjectFinal.Data;
using FiorelloProjectFinal.Models;
using FiorelloProjectFinal.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FiorelloProjectFinal.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductService _productService;

		public ProductController(IProductService productService)
		{
            _productService = productService;
		}

		public async Task<IActionResult> Index(int? id)
		{
			if (id is null) return BadRequest();
			Product product = await _productService.GetById((int)id);

			if (product is null) return NotFound();
			return View(product);
		}
	}
}

