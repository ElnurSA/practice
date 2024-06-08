using System;
using FiorelloProjectFinal.Models;

namespace FiorelloProjectFinal.ViewModels
{
	public class HomeVM
	{
        public List<Category> Categories { get; set; }
        public List<Slider> Sliders { get; set; }
		public SliderInfo SliderInfo { get; set; }
		public List<Product> Products { get; set; }
		public List<Blog> Blogs { get; set; }
		
	}
}

