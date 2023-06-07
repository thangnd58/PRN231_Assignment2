using BookStoreAPI.Models;

namespace BookStoreAPI.DAL
{
    public class UserRepository : IUserRepository
    {
        private BookStoreContext _context;

        public UserRepository(BookStoreContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            _context.Remove(GetUserById(userId));
            _context.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int userId)
        {
            return _context.Users.FirstOrDefault(x => x.UserId == userId);
        }

        public User GetUserByEmailAndPassword(string userName, string password)
        {
            return _context.Users.FirstOrDefault(x => x.EmailAddress.Equals(userName) && x.Password.Equals(password));
        }

        public void UpdateUser(int userId, User user)
        {
            User u = GetUserById(userId);
            u.EmailAddress = user.EmailAddress;
            u.Password = user.Password;
            u.Source = user.Source;
            u.FirstName= user.FirstName;
            u.MiddleName = user.MiddleName;
            u.LastName = user.LastName;
            u.RoleId = user.RoleId;
            u.PubId = user.PubId;
            u.HireDate = user.HireDate;
            _context.SaveChanges();
        }
    }
}
