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
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var users = _userService.GetAllUsers();
                if (users == null) return NotFound();
                return Ok(_mapper.Map<List<UserDTO>>(users));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Verify")]
        public IActionResult GetByEmailAndPassword(string email, string password)
        {
            try
            {
                var user = _userService.GetUserByEmailAndPassword(email, password);
                if (user == null) return NotFound();
                return Ok(_mapper.Map<UserDTO>(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{userId}")]
        public IActionResult Get(int userId)
        {
            try
            {
                var user = _userService.GetUserById(userId);
                if (user == null) return NotFound();
                return Ok(_mapper.Map<UserDTO>(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult PostUser([FromBody] UserDTO userDTO)
        {
            try
            {
                _userService.AddUser(_mapper.Map<User>(userDTO));
                return Ok("Add ok!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult PutUser(int userId, [FromBody] UserDTO userDTO)
        {
            try
            {
                _userService.UpdateUser(userId, _mapper.Map<User>(userDTO));
                return Ok("Update ok!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteUser(int userId)
        {
            try
            {
                _userService.DeleteUser(userId);
                return Ok("Delete ok!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
