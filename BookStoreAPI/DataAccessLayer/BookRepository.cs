using BookStoreAPI.Models;

namespace BookStoreAPI.DAL
{
    public class BookRepository : IBookRepository
    {
        private BookStoreContext _context;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }

        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void DeleteBook(int bookId)
        {
            _context.Remove(GetBookById(bookId));
            _context.SaveChanges();
        }

        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public Book GetBookById(int bookId)
        {
            return _context.Books.FirstOrDefault(x => x.BookId == bookId);
        }

        public void UpdateBook(int bookId, Book book)
        {
            Book b = GetBookById(bookId);
            b.Title = book.Title;
            b.Type = book.Type;
            b.PubId = book.PubId;
            b.Price = book.Price;
            b.Advance = book.Advance;
            b.Royalty = book.Royalty;
            b.YtdSales = book.YtdSales;
            b.Notes = book.Notes;
            b.PublishedDate = book.PublishedDate;
            _context.SaveChanges();
        }
    }
}
