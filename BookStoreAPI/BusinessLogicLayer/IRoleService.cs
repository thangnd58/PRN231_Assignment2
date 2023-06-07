using BookStoreAPI.Models;

namespace BookStoreAPI.BLL
{
	public interface IRoleService
	{
		Role GetRoleById(int roleId);
		void AddRole(Role role);
		void UpdateRole(int roleId, Role role);
		void DeleteRoleById(int roleId);
		List<Role> GetAllRoles();
	}
}
