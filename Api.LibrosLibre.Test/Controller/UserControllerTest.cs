using Api.LibrosLibre.Application.Commands;
using Api.LibrosLibre.Application.DTOs;
using Api.LibrosLibre.Application.Queries;
using Api.LibrosLibre.Domain.Common;
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
			var resultExpected = new ApiResponse<UserDTO> { Data = expectedUser, Message = "User created successfully", StatusCode = 201 };
			 _mediatorMock.Setup(m => m.Send(It.IsAny<CreateUserCommand>(), default)).ReturnsAsync(resultExpected);
			
			var result = await _controller.SetUser(command);

			var createdResult = result.Result as CreatedResult;
			
			Assert.That(createdResult, Is.Not.Null);
			Assert.That(createdResult.Value, Is.EqualTo(resultExpected));
			Assert.AreEqual(201, createdResult.StatusCode);
		}

		[Test]
		public async Task Should_Get_User_Details_By_Uid()
		{
			string uid = "12s12s5ss";
			var expectedUser = new UserDTO { Id = 1, Name = "Test User", Uid = uid };
			var resultExpected = new ApiResponse<UserDTO> { Data = expectedUser, Message = "User retrieved successfully", StatusCode = 200 };
			
			_mediatorMock.Setup(s => s.Send(It.IsAny<GetUserByUidQuery>(), default)).ReturnsAsync(resultExpected);

			var result = await _controller.GetUser(uid);
			var okResult = result.Result as OkObjectResult;


			Assert.That(okResult, Is.Not.Null);
			Assert.That(okResult.Value, Is.EqualTo(resultExpected));
			Assert.AreEqual(200, okResult.StatusCode);
		}

	}
}