using Books.Application.DTOs.ReceiveDTOs;
using Books.Application.DTOs.SendDTOs;
using Books.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Books.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookSendDTO>>> Get()
        {
            var books = await _bookService.GetAllAsync();

            if (books == null)
            {
                return NotFound("Books not found");
            }

            return Ok(books);
        }

        [HttpGet("{id}", Name = "GetBook")]
        public async Task<ActionResult<BookSendDTO>> Get(string id)
        {
            var bookSendDTO = await _bookService.GetByIdAsync(id);

            if (bookSendDTO == null)
            {
                return NotFound("Book not found");
            }

            return Ok(bookSendDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] BookReceiveDTO bookReceiveDTO)
        {
            if (bookReceiveDTO == null)
            {
                return BadRequest("Invalid Data");
            }

            var bookSendDTO = await _bookService.CreateAsync(bookReceiveDTO);

            return CreatedAtRoute("GetBook", new { id = bookSendDTO.Id }, bookSendDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] BookSendDTO bookReceiveDTO)
        {
            if (bookReceiveDTO == null) return BadRequest();

            var bookSendDTO = await _bookService.UpdateAsync(bookReceiveDTO);

            if (bookSendDTO == null) return BadRequest();

            return Ok(bookSendDTO);
        }

        [HttpPut("{id}/startReading", Name = "StartReading")]
        public async Task<ActionResult> StartReading(string id)
        {
            var bookSendDTO = await _bookService.StartReadingAsync(id);

            if (!bookSendDTO) return BadRequest();

            return Ok(bookSendDTO);
        }

        [HttpPut("{id}/stopReading", Name = "StopReading")]
        public async Task<ActionResult> StopReading(string id)
        {
            var bookSendDTO = await _bookService.StopReadingAsync(id);

            if (!bookSendDTO) return BadRequest();

            return Ok(bookSendDTO);
        }

        [HttpPut("{id}/partialRestartReading", Name = "PartialRestartReading")]
        public async Task<ActionResult> PartialRestartReading(string id)
        {
            var bookSendDTO = await _bookService.PartialRestartReadingAsync(id);

            if (!bookSendDTO) return BadRequest();

            return Ok(bookSendDTO);
        }

        [HttpPut("{id}/fullRestartReading", Name = "FullRestartReading")]
        public async Task<ActionResult> FullRestartReading(string id)
        {
            var bookSendDTO = await _bookService.FullRestartReadingAsync(id);

            if (!bookSendDTO) return BadRequest();

            return Ok(bookSendDTO);
        }

        [HttpPut("{id}/concludeReading", Name = "ConcludeReading")]
        public async Task<ActionResult> ConcludeReading(string id)
        {
            var bookSendDTO = await _bookService.ConcludeReadingAsync(id);

            if (!bookSendDTO) return BadRequest();

            return Ok(bookSendDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var bookSendDTO = await _bookService.RemoveAsync(id);

            if (bookSendDTO == null) return BadRequest();

            return Ok();
        }
    }
}
