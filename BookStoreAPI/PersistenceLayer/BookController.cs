using AutoMapper;
using BookStoreAPI.BLL;
using BookStoreAPI.DTO;
using BookStoreAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace BookStoreAPI.PL
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookService _bookService;
        private IMapper _mapper;

        public BookController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet]
        [EnableQuery]
        public IActionResult Get()
        {
            try
            {
                var books = _bookService.GetAllBooks();
                if (books == null) return NotFound();
                return Ok(_mapper.Map<List<BookDTO>>(books));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{bookId}")]
        public IActionResult Get(int bookId)
        {
            try
            {
                var book = _bookService.GetBookById(bookId);
                if (book == null) return NotFound();
                return Ok(_mapper.Map<BookDTO>(book));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult PostBook(BookDTO bookDTO)
        {
            try
            {
                _bookService.AddBook(_mapper.Map<Book>(bookDTO));
                return Ok("Add ok!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{bookId}")]
        public IActionResult PutBook(int bookId, BookDTO bookDTO)
        {
            try
            {
                _bookService.UpdateBook(bookId, _mapper.Map<Book>(bookDTO));
                return Ok("Update ok!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{bookId}")]
        public IActionResult DeleteBook(int bookId)
        {
            try
            {
                _bookService.DeleteBook(bookId);
                return Ok("Delete ok!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
