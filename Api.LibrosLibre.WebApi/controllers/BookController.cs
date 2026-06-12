using Api.LibrosLibre.Application.Commands;
using Api.LibrosLibre.Application.DTOs;
using Api.LibrosLibre.Application.Queries;
using Api.LibrosLibre.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.LibrosLibre.WebApi
{
    [ApiController]
    [Route("api/books")]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;
		private readonly ILogger<BookController> _logger;

        public BookController(IMediator mediator, ILogger<BookController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }


        [HttpGet("get-book-details")]
        public async Task<ActionResult<ApiResponse<BookDTOResponse>>> GetBookDetail([FromQuery] int id)
        {
			_logger.LogInformation("Retrieved details for book with ID {Id}", id);
            var book = await _mediator.Send(new GetBookDetailsQuery(id));
            return Ok(book);
        }

        [HttpGet("get-main-books")]
        public async Task<ActionResult<ApiResponse<List<ImageDTO>>>> GetMainBooks()
        {
            var images = await _mediator.Send(new GetMainBooksQuery());
            return Ok(images);
        }

        [HttpGet("get-featured-books")]
        public async Task<ActionResult<ApiResponse<List<BookDTOResponse>>>> GetFeaturedBooks([FromQuery] int amount)
        {
            var books = await _mediator.Send(new GetFeaturedBooksQuery(amount));
            return Ok(books);
        }

        [HttpGet("get-recent-books")]
        public async Task<ActionResult<ApiResponse<List<BookDTOResponse>>>> GetRecentBooks([FromQuery] int amount)
        {
            var books = await _mediator.Send(new GetRecentBooksQuery(amount));
            return Ok(books);
        }

        [HttpGet("get-other-books")]
        public async Task<ActionResult<ApiResponse<List<BookDTOResponse>>>> GetOtherBooks([FromQuery] int amount)
        {
            var books = await _mediator.Send(new GetOtherBooksQuery(amount));
            return Ok(books);
        }

        [HttpPost("set-book")]
        public async Task<ActionResult<ApiResponse<BookDTOResponse>>> SetBook([FromForm] CreateBookCommand command)
        {
			_logger.LogInformation("Creating a new book with title {Title}", command.bookRequest);
            var createdBook = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetBookDetail), createdBook);
        }

        [HttpGet("search-books")]
        public async Task<ActionResult<ApiResponse<List<BookDTOResponse>>>> SearchBook([FromQuery] string keyword)
        {
            var result = await _mediator.Send(new SearchBookQuery(keyword));
            return Ok(result);
        }

        [HttpGet("get-books-by-user")]
        public async Task<ActionResult<ApiResponse<List<BookDTOResponse>>>> GetBooksByUser([FromQuery] int userId)
        {
            var result = await _mediator.Send(new GetBookByUserQuery(userId));
            return Ok(result);
        }

        [HttpGet("get-favorites-books")]
        public async Task<ActionResult<ApiResponse<List<BookDTOResponse>>>> GetFavoritesBooks([FromQuery] int userId)
        {
            var result = await _mediator.Send(new GetFavoriteBookQuery(userId));
            return Ok(result);
        }

        [HttpPost("set-favorite-book")]
        public async Task<ActionResult<ApiResponse<int>>> SetFavoriteBook([FromQuery] int userId, [FromQuery] int bookId)
        {
            var result = await _mediator.Send(new SetFavoriteBookCommand(userId, bookId));
            return Ok(result);
        }

    }
}