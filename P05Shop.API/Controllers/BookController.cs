using Microsoft.AspNetCore.Mvc;
using P04WeatherForecastAPI.Client.Models;
using P06Shop.Shared;
using P06Shop.Shared.Services.BookService;
using P06Shop.Shared.Shop;

namespace P05Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        //CRUD
        [HttpPost("AddBook")]
        public async Task<IActionResult> AddNewBook([FromBody] Book book)
        {
            var res = await _bookService.AddBook(book);
            if (res.Success)
                return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
            else
                return StatusCode(500, $"Internal server error: {res.Message}");
        }

        [HttpGet("GetBook/{id}")]
        public async Task<ActionResult<ServiceResponse<Book>>> GetBook([FromRoute] int id)
        {
            var result = await _bookService.GetBookByID(id);
            if (result.Success)
                return Ok(result);
            else
                return StatusCode(500, $"Internal server error: {result.Message}");
        }

        [HttpDelete("DeleteBook/{id}")]
        public async Task<ActionResult<ServiceResponse<Book>>> DeleteBook([FromRoute] int id)
        {
            var result = await _bookService.DeleteBook(id);
            if (result.Success)
                return Ok(result);
            else
                return StatusCode(500, $"Internal server error: {result.Message}");
        }

        [HttpPut("PutBook/{id}")]
        public async Task<ActionResult<ServiceResponse<Book>>> ModificateBook([FromRoute] int id, Book book)
        {
            book.Id = id;
            var result = await _bookService.UpdateBook(book);
            if (result.Success)
                return Ok(result);
            else
                return StatusCode(500, $"Internal server error: {result.Message}");
        }
    }
}
