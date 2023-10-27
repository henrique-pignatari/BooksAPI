using Books.Application.DTOs.ReceiveDTOs;
using Books.Application.DTOs.SendDTOs;
using Books.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Books.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreSendDTO>>> Get()
        {
            var genres = await _genreService.GetAllAsync();

            if (genres == null)
            {
                return NotFound("Genres not found");
            }

            return Ok(genres);
        }

        [HttpGet("{id}", Name = "GetGenre")]
        public async Task<ActionResult<GenreSendDTO>> Get(string id)
        {
            var genreSendDTO = await _genreService.GetByIdAsync(id);

            if (genreSendDTO == null)
            {
                return NotFound("Genre not found");
            }

            return Ok(genreSendDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GenreReceiveDTO genreReceiveDTO)
        {
            if (genreReceiveDTO == null)
            {
                return BadRequest("Invalid Data");
            }

            var genreSendDTO = await _genreService.CreateAsync(genreReceiveDTO);

            return CreatedAtRoute("GetGenre", new { id = genreSendDTO.Id }, genreSendDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] GenreSendDTO genreReceiveDTO)
        {
            if (genreReceiveDTO == null) return BadRequest();

            var genreSendDTO = await _genreService.UpdateAsync(genreReceiveDTO);

            if (genreSendDTO == null) return BadRequest();

            return Ok(genreSendDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var genreSendDTO = await _genreService.RemoveAsync(id);

            if (genreSendDTO == null) return BadRequest();

            return Ok();
        }
    }
}
