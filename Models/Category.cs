using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FiorelloProjectFinal.Models
{
	public class Category : BaseEntity
	{
		public string Name { get; set; }
        public ICollection<Product> Products { get; set; }

    }

}

