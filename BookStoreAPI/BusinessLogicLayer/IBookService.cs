using BookStoreAPI.Models;

namespace BookStoreAPI.BLL
{
    public interface IBookService
    {
        List<Book> GetAllBooks();
        Book GetBookById(int bookId);
        void AddBook(Book book);
        void UpdateBook(int bookId, Book book);
        void DeleteBook(int bookId);
    }
}
