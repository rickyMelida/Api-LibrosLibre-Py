using Api.LibrosLibre.Application.Commands;
using Api.LibrosLibre.Application.DTOs;
using Api.LibrosLibre.Application.Queries;
using Api.LibrosLibre.Domain.Common;
using Api.LibrosLibre.WebApi;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Api.LibrosLibre.Test.Controller
{
	public class BookControllerTest
	{
		private Mock<IMediator> _mediatorMock;
		private BookController _controller;

		[SetUp]
		public void Setup()
		{
			_mediatorMock = new Mock<IMediator>();
			_controller = new BookController(_mediatorMock.Object);
		}

		[Test]
		public async Task Should_Add_New_Book_And_Return_Success()
		{
			var bookRequest = new BookDTORequest { Title = "Test Book" };
			var command = new CreateBookCommand(bookRequest);
			var expectedBook = new BookDTOResponse { Id = 1, Title = "Test Book" };
			var apiResponse = new ApiResponse<int> { Data = expectedBook.Id, Message = "Libro agregado exitosamente", StatusCode = 201 };
			_mediatorMock.Setup(m => m.Send(It.IsAny<IRequest<ApiResponse<int>>>(), default)).ReturnsAsync(apiResponse);

			var result = await _controller.SetBook(command);

			var createdResult = result.Result as CreatedAtActionResult;
			Assert.That(createdResult, Is.Not.Null);
			Assert.That(createdResult.ActionName, Is.EqualTo(nameof(BookController.GetBookDetail)));
		}

		[Test]
		public async Task Should_Get_Book_Details_By_Id()
		{
			var bookId = 1;
			var expectedBook = new BookDTOResponse { Id = bookId, Title = "Test Book" };
			var apiResponse = new ApiResponse<BookDTOResponse> { Data = expectedBook, Message = "Book details retrieved successfully", StatusCode = 200 };
			_mediatorMock.Setup(m => m.Send(It.IsAny<GetBookDetailsQuery>(), default)).ReturnsAsync(apiResponse);

			var result = await _controller.GetBookDetail(bookId);

			var okResult = result.Result as OkObjectResult;
			Assert.That(okResult, Is.Not.Null);
			Assert.That(okResult.Value, Is.EqualTo(apiResponse));
		}

		[Test]
		public async Task Should_Get_Featured_Books()
		{
			var amount = 5;
			var expectedBooks = new List<BookDTOResponse> { new() { Id = 1, Title = "Book 1" } };
			var apiResponse = new ApiResponse<List<BookDTOResponse>> { Data = expectedBooks, Message = "Featured books retrieved successfully", StatusCode = 200 };
			_mediatorMock.Setup(m => m.Send(It.IsAny<GetFeaturedBooksQuery>(), default)).ReturnsAsync(apiResponse);

			var result = await _controller.GetFeaturedBooks(amount);

			var okResult = result.Result as OkObjectResult;
			Assert.That(okResult, Is.Not.Null);
			Assert.That(okResult.Value, Is.EqualTo(apiResponse));
		}

		[Test]
		public async Task Should_Search_Books_By_Keyword()
		{
			var keyword = "fiction";
			var expectedBooks = new List<BookDTOResponse> { new() { Id = 1, Title = "Fiction Book" } };
			var apiResponse = new ApiResponse<List<BookDTOResponse>> { Data = expectedBooks, Message = "Books found successfully", StatusCode = 200 };
			_mediatorMock.Setup(m => m.Send(It.IsAny<SearchBookQuery>(), default)).ReturnsAsync(apiResponse);

			var result = await _controller.SearchBook(keyword);

			var okResult = result.Result as OkObjectResult;
			Assert.That(okResult, Is.Not.Null);
			Assert.That(okResult.Value, Is.EqualTo(apiResponse));
		}

		[Test]
		public async Task Should_Get_Books_By_User()
		{
			var userId = 1;
			var expectedBooks = new List<BookDTOResponse> { new() { Id = 1, Title = "User Book" } };
			var apiResponse = new ApiResponse<List<BookDTOResponse>> { Data = expectedBooks, Message = "Books retrieved successfully", StatusCode = 200 };
			_mediatorMock.Setup(m => m.Send(It.IsAny<GetBookByUserQuery>(), default)).ReturnsAsync(apiResponse);

			var result = await _controller.GetBooksByUser(userId);

			var okResult = result.Result as OkObjectResult;
			Assert.That(okResult, Is.Not.Null);
			Assert.That(okResult.Value, Is.EqualTo(apiResponse));
		}

		[Test]
		public async Task Should_Set_Favorite_Book()
		{
			var userId = 1;
			var bookId = 1;
			var apiResponse = new ApiResponse<int> { Data = 1, Message = "Book marked as favorite successfully", StatusCode = 200 };
			_mediatorMock.Setup(m => m.Send(It.IsAny<SetFavoriteBookCommand>(), default)).ReturnsAsync(apiResponse);

			var result = await _controller.SetFavoriteBook(userId, bookId);

			var okResult = result.Result as OkObjectResult;
			Assert.That(okResult, Is.Not.Null);
			Assert.That(okResult.Value, Is.EqualTo(apiResponse));
		}
	}
}
