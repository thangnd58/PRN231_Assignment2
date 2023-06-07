using AutoMapper;
using BookStoreAPI.BLL;
using BookStoreAPI.DTO;
using BookStoreAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.PL
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private IAuthorService _authorService;
        private IMapper _mapper;

        public AuthorController(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var authors = _authorService.GetAllAuthors();
                if (authors == null) return NotFound();
                return Ok(_mapper.Map<List<AuthorDTO>>(authors));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{authorId}")]
        public IActionResult GetAuthorById(int authorId)
        {
            try
            {
                var author = _authorService.GetAuthorById(authorId);
                if (author == null) return NotFound();
                return Ok(_mapper.Map<AuthorDTO>(author));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult PostAuthor([FromBody] AuthorDTO authorDTO)
        {
            try
            {
                _authorService.AddAuthors(_mapper.Map<Author>(authorDTO));
                return Ok("Add ok!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{authorId}")]
        public IActionResult PutAuthor(int authorId, [FromBody] AuthorDTO authorDTO)
        {
            try
            {
                _authorService.UpdateAuthor(authorId, _mapper.Map<Author>(authorDTO));
                return Ok("Update ok!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{authorId}")]
        public IActionResult DeleteAuthor(int authorId)
        {
            try
            {
                _authorService.RemoveAuthors(authorId);
                return Ok("Delete ok!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
