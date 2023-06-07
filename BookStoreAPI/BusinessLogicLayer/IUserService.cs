using BookStoreAPI.Models;

namespace BookStoreAPI.BLL
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        User GetUserById(int userId);
        void UpdateUser(int userId, User user);
        void DeleteUser(int userId);
        void AddUser(User user);

        User GetUserByEmailAndPassword(string email, string password);
    }
}
