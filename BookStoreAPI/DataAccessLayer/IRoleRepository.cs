using BookStoreAPI.Models;

namespace BookStoreAPI.DAL
{
    public interface IRoleRepository
    {
        Role GetRoleById(int roleId);
        void AddRole(Role role);
        void UpdateRole(int roleId, Role role);
        void DeleteRoleById(int roleId);
        List<Role> GetRoles();
    }
}
