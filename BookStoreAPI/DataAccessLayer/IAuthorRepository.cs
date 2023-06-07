using BookStoreAPI.Models;

namespace BookStoreAPI.DAL
{
    public interface IAuthorRepository
    {
        List<Author> GetAllAuthor();
        Author GetByAuthorId(int authorId);
        void AddAuthor(Author author);
        void UpdateAuthor(int authorId, Author author);
        void DeleteAuthor(int id);
    }
}
