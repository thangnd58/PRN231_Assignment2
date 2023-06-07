using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.DTO
{
	public class RoleDTO
	{
		public int RoleId { get; set; }
		public string? RoleDesc { get; set; }
	}
}
