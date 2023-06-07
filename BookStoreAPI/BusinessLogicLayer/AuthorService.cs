using BookStoreAPI.DAL;
using BookStoreAPI.Models;

namespace BookStoreAPI.BLL
{
    public class AuthorService : IAuthorService
    {
        private IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public void AddAuthors(Author author)
        {
            _authorRepository.AddAuthor(author);
        }

        public List<Author> GetAllAuthors()
        {
            return _authorRepository.GetAllAuthor();
        }

        public Author GetAuthorById(int id)
        {
            return _authorRepository.GetByAuthorId(id);
        }

        public void RemoveAuthors(int authorId)
        {
            _authorRepository.DeleteAuthor(authorId);
        }

        public void UpdateAuthor(int authorId, Author author)
        {
            _authorRepository.UpdateAuthor(authorId, author);
        }
    }
}
