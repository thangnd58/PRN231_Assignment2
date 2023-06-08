using AutoMapper;
using BookStoreAPI.BLL;
using BookStoreAPI.DTO;
using BookStoreAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace BookStoreAPI.PL
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private IPublisherService _publisherService;
        private IMapper _mapper;

        public PublisherController(IPublisherService publisherService, IMapper mapper)
        {
            _publisherService = publisherService;
            _mapper = mapper;
        }

        [HttpGet]
        [EnableQuery]
        public IActionResult Get()
        {
            try
            {
                var publishers = _publisherService.GetAllPublishers();
                if (publishers == null) return NotFound();
                return Ok(_mapper.Map<List<PublisherDTO>>(publishers));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{publisherId}")]
        public IActionResult Get(int publisherId)
        {
            try
            {
                var publisher = _publisherService.GetPublisherById(publisherId);
                if (publisher == null) return NotFound();
                return Ok(_mapper.Map<PublisherDTO>(publisher));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult PostPublisher([FromBody] PublisherDTO publisherDTO)
        {
            try
            {
                _publisherService.AddPublisher(_mapper.Map<Publisher>(publisherDTO));
                return Ok("Add ok!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{publisherId}")]
        public IActionResult PutPublisher(int publisherId, [FromBody] PublisherDTO publisherDTO)
        {
            try
            {
                _publisherService.UpdatePublisher(publisherId, _mapper.Map<Publisher>(publisherDTO));
                return Ok("Update ok!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{publisherId}")]
        public IActionResult DeletePublisher(int publisherId)
        {
            try
            {
                _publisherService.DeletePublisher(publisherId);
                return Ok("Delete ok!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
