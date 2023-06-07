using BookStoreAPI.Models;

namespace BookStoreAPI.DAL
{
    public class AuthorRepository : IAuthorRepository
    {
        private BookStoreContext _context;
        
        public AuthorRepository(BookStoreContext context)
        {
            _context = context;
        }

        public void AddAuthor(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public void DeleteAuthor(int id)
        {
            _context.Authors.Remove(GetByAuthorId(id));
            _context.SaveChanges();
        }

        public List<Author> GetAllAuthor()
        {
            return _context.Authors.ToList();
        }

        public Author GetByAuthorId(int authorId)
        {
            return _context.Authors.FirstOrDefault(x => x.AuthorId == authorId);
        }

        public void UpdateAuthor(int authorId, Author author)
        {
            Author a = GetByAuthorId(authorId);
            a.LastName = author.LastName;
            a.FirstName = author.FirstName;
            a.Phone = author.Phone;
            a.Address = author.Address;
            a.City = author.City;
            a.State = author.State;
            a.Zip = author.Zip;
            a.EmailAddress = author.EmailAddress;
            _context.SaveChanges();
        }
    }
}
