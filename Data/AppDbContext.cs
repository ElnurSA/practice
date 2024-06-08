using System;
using FiorelloProjectFinal.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FiorelloProjectFinal.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
	{
		public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }

		public DbSet<Slider> Sliders { get; set; }
        public DbSet<SliderInfo> SliderInfos { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Blog> Blogs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Blog>().HasQueryFilter(m => !m.SoftDeleted);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Blog>().HasData(
                new Blog
                {
                    Id = 1,
                    Title = "Blog title 1",
                    Description = "Description1",
                    Date = DateTime.Now,
                    Image = "blog-feature-img-1.jpg"
                },

                new Blog
                {
                    Id = 2,
                    Title = "Blog title 2",
                    Description = "Description2",
                    Date = DateTime.Now,
                    Image = "blog-feature-img-3.jpg"
                },

                 new Blog
                 {
                     Id = 3,
                     Title = "Blog title 3",
                     Description = "Description3",
                     Date = DateTime.Now,
                     Image = "blog-feature-img-4.jpg"
                 }
             );
        }
    }
}

