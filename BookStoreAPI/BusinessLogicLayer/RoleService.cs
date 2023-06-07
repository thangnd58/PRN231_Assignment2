using BookStoreAPI.DAL;
using BookStoreAPI.Models;

namespace BookStoreAPI.BLL
{
	public class RoleService : IRoleService
	{

		private readonly IRoleRepository _roleRepository;


		public RoleService(IRoleRepository roleRepository)
		{
			_roleRepository = roleRepository;
		}

		public void AddRole(Role role)
		{
			_roleRepository.AddRole(role);
		}

		public void DeleteRoleById(int roleId)
		{
			_roleRepository.DeleteRoleById(roleId);
		}

		public Role GetRoleById(int roleId)
		{
			return _roleRepository.GetRoleById(roleId);
		}

		public void UpdateRole(int roleId, Role role)
		{
			_roleRepository.UpdateRole(roleId, role);
		}

		public List<Role> GetAllRoles() {
			return _roleRepository.GetRoles();
		}
	}
}
