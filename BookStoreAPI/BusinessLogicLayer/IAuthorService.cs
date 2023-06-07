using BookStoreAPI.Models;

namespace BookStoreAPI.BLL
{
    public interface IAuthorService
    {
        Author GetAuthorById(int id);
        List<Author> GetAllAuthors();
        void AddAuthors(Author author);
        void RemoveAuthors(int authorId);
        void UpdateAuthor(int authorId, Author author);
    }
}
