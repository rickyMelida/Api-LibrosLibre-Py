using Api.LibrosLibre.Application.Commands;
using Api.LibrosLibre.Application.DTOs;
using Api.LibrosLibre.Application.Queries;
using Api.LibrosLibre.WebApi;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Api.LibrosLibre.Test.Controller
{
	public class UserControllerTest
	{
		private Mock<IMediator> _mediatorMock;
		private UserController _controller;

		[SetUp]
		public void Setup()
		{
			_mediatorMock = new Mock<IMediator>();
			_controller = new UserController(_mediatorMock.Object);
		}

		[Test]
		public async Task Should_Add_New_User_And_Return_Success()
		{
			var userRequest = new UserDTO { Name = "Test User" };
			var command = new CreateUserCommand(userRequest);
			var expectedUser = new UserDTO { Id = 1, Name = "Test User" };
			_mediatorMock.Setup(m => m.Send(It.IsAny<IRequest<UserDTO>>(), default)).ReturnsAsync(expectedUser);

			var result = await _controller.SetUser(command);

			var createdResult = result.Result as CreatedResult;
			Assert.That(201, Is.EqualTo(createdResult.StatusCode));
			Assert.That(createdResult.Value, Is.EqualTo(expectedUser));
		}

		[Test]
		public async Task Should_Get_User_Details_By_Uid()
		{
			var uid = "test-uid";
			var expectedUser = new UserDTO { Id = 1, Name = "Test User" };
			_mediatorMock.Setup(m => m.Send(It.IsAny<GetUserByUidQuery>(), default)).ReturnsAsync(expectedUser);
		}

	}
}