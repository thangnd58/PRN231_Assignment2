using AutoMapper;
using BookStoreAPI.BLL;
using BookStoreAPI.DTO;
using BookStoreAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.PL
{
	[Route("api/[controller]")]
	[ApiController]
	public class RoleController : ControllerBase
	{
		private readonly IRoleService _roleService;
		private readonly IMapper _mapper;

		public RoleController(IRoleService roleService, IMapper mapper)
		{
			_roleService = roleService;
			_mapper = mapper;
		}


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var roles = _roleService.GetAllRoles();
				if (roles == null) return NotFound();
                return Ok(_mapper.Map<List<RoleDTO>>(roles));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{roleId}")]
		public IActionResult GetById(int roleId)
		{
			try
			{
				var role = _roleService.GetRoleById(roleId);
                if (role == null) return NotFound();
                return Ok(_mapper.Map<RoleDTO>(role));
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost]
		public IActionResult Post([FromBody] RoleDTO role)
		{
			try
			{
				_roleService.AddRole(_mapper.Map<Role>(role));
				return Ok("Add ok!");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("{roleId}")]
		public IActionResult Put(int roleId, [FromBody] RoleDTO role)
		{
			try
			{
				_roleService.UpdateRole(roleId, _mapper.Map<Role>(role));
				return Ok("Update ok!");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete("{roleId}")]
		public IActionResult Delete(int roleId)
		{
			try
			{
				_roleService.DeleteRoleById(roleId);
				return Ok("Delete ok!");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

	}
}
