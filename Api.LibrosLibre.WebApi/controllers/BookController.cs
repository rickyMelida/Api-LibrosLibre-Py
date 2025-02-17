using Api.LibrosLibre.Application;
using Api.LibrosLibre.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Api.LibrosLibre.WebApi
{
    [ApiController]
    [Route("api/books")]
    public class BookController: ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IImagesService _bookImagesService;

        public BookController(IBookService bookService, IImagesService bookImagesService)
        {
            _bookService = bookService;
            _bookImagesService = bookImagesService;
        }
        
        [HttpGet("get-main-books")]
        public  async Task<ActionResult<List<Image>>> GetMainBooks()
        {
            var images = await _bookImagesService.GetRelevantBookImages();
            return Ok(images);
        }

        [HttpGet("get-featured-books")]
        public async Task<ActionResult<List<BookDTOResponse>>> GetFeaturedBooks([FromQuery] int amount)
        {
            var books = await _bookService.GetFeaturedBooks(amount);
            return Ok(books);
        }

        [HttpGet("get-recent-books")]
        public  async Task<ActionResult<List<BookDTOResponse>>> GetRecentBooks([FromQuery] int amount)
        {
            var books = await _bookService.GetRecentsBooks(amount);
            return Ok(books);
        }

        [HttpGet("get-other-books")]
        public  async Task<ActionResult<List<BookDTOResponse>>> GetOtherBooks([FromQuery] int amount)
        {
            var books = await _bookService.GetOthersBooks(amount);
            return Ok(books);
        }

        [HttpPost]
        public async Task<ActionResult<BookDTOResponse>> SetBook(BookDTORequest book)
        {
            var createdBook = await _bookService.SetNewBook(book);
            
            if (createdBook == null)
                return BadRequest();
            
            return Ok(createdBook);
        }

    


    }
}