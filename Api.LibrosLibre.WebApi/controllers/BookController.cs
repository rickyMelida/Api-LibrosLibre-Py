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
        private readonly IBookImagesService _bookImagesService;

        public BookController(IBookService bookService, IBookImagesService bookImagesService)
        {
            _bookService = bookService;
            _bookImagesService = bookImagesService;
        }
        
        [HttpGet("get-book")]
        public string Get()
        {
            return "Hello World";
        }

        [HttpGet("get-main-books")]
        public  async Task<ActionResult<List<Image>>> GetMainBooks()
        {
            var images = await _bookImagesService.GetRelevantBookImages();
            return Ok(images);
        }


    }
}