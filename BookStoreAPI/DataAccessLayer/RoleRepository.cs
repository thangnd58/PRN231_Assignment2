using BookStoreAPI.Models;

namespace BookStoreAPI.DAL
{
    public class RoleRepository : IRoleRepository
    {
        private readonly BookStoreContext _context;

        public RoleRepository(BookStoreContext context)
        {
            _context = context;
        }

        public void AddRole(Role role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
        }

        public void DeleteRoleById(int roleId)
        {
            _context.Roles.Remove(GetRoleById(roleId));
            _context.SaveChanges();
        }

        public Role GetRoleById(int roleId)
        {
            return _context.Roles.FirstOrDefault(r => r.RoleId == roleId);
        }

        public void UpdateRole(int roleId, Role role)
        {
            Role r = _context.Roles.FirstOrDefault(r => r.RoleId == roleId);
            r.RoleDesc = role.RoleDesc;
            _context.SaveChanges();
        }

        public List<Role> GetRoles()
        {
            return _context.Roles.ToList();
        }
    }
}
