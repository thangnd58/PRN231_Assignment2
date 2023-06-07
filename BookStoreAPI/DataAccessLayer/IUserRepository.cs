using BookStoreAPI.Models;

namespace BookStoreAPI.DAL
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User GetUserById(int userId);
        void AddUser(User user);
        void UpdateUser(int userId, User user);
        void DeleteUser(int userId);
        User GetUserByEmailAndPassword(string userName, string password);
    }
}
