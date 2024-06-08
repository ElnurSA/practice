  using System;
using Microsoft.AspNetCore.Identity;

namespace FiorelloProjectFinal.Models
{
	public class AppUser : IdentityUser
	{
		public string FullName { get; set; }
	}
} 

