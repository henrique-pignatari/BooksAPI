using Books.Application.DTOs.ReceiveDTOs;
using Books.Application.DTOs.SendDTOs;
using Books.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace Books.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorSendDTO>>> Get()
        {
            var authors = await _authorService.GetAllAsync();

            if(authors == null)
            {
                return NotFound("Authors not found");
            }

            return Ok(authors);
        }

        [HttpGet("{id}", Name = "GetAuthor")]
        public async Task<ActionResult<AuthorSendDTO>> Get(string id)
        {
            var authorSendDTO = await _authorService.GetByIdAsync(id);

            if(authorSendDTO == null)
            {
                return NotFound("Author not found");
            }

            return Ok(authorSendDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AuthorReceiveDTO authorReceiveDTO)
        {
            if(authorReceiveDTO == null)
            {
                return BadRequest("Invalid Data");
            }

            var authorSendDTO = await _authorService.CreateAsync(authorReceiveDTO);

            return CreatedAtRoute("GetAuthor", new { id = authorSendDTO.Id }, authorSendDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] AuthorReceiveDTO authorReceiveDTO)
        {
            if (authorReceiveDTO == null) return BadRequest();

            var authorSendDTO = await _authorService.UpdateAsync(authorReceiveDTO);

            if (authorSendDTO == null) return BadRequest();

            return Ok(authorSendDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var authorSendDTO = await _authorService.RemoveAsync(id);

            if (authorSendDTO == null) return BadRequest();

            return Ok();
        }
    }
}
