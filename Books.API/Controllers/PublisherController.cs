using Books.Application.DTOs.ReceiveDTOs;
using Books.Application.DTOs.SendDTOs;
using Books.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Books.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublisherSendDTO>>> Get()
        {
            var publishers = await _publisherService.GetAllAsync();

            if (publishers == null)
            {
                return NotFound("Publishers not found");
            }

            return Ok(publishers);
        }

        [HttpGet("{id}", Name = "GetPublisher")]
        public async Task<ActionResult<PublisherSendDTO>> Get(string id)
        {
            var publisherSendDTO = await _publisherService.GetByIdAsync(id);

            if (publisherSendDTO == null)
            {
                return NotFound("Publisher not found");
            }

            return Ok(publisherSendDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PublisherReceiveDTO publisherReceiveDTO)
        {
            if (publisherReceiveDTO == null)
            {
                return BadRequest("Invalid Data");
            }

            var publisherSendDTO = await _publisherService.CreateAsync(publisherReceiveDTO);

            return CreatedAtRoute("GetPublisher", new { id = publisherSendDTO.Id }, publisherSendDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] PublisherSendDTO publisherReceiveDTO)
        {
            if (publisherReceiveDTO == null) return BadRequest();

            var publisherSendDTO = await _publisherService.UpdateAsync(publisherReceiveDTO);

            if (publisherSendDTO == null) return BadRequest();

            return Ok(publisherSendDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var publisherSendDTO = await _publisherService.RemoveAsync(id);

            if (publisherSendDTO == null) return BadRequest();

            return Ok();
        }
    }
}
