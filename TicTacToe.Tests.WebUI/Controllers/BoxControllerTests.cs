using Moq;
using System;
using NUnit.Framework;
using TicTacToe.Presentation.WebUI.Controllers;
using TicTacToe.Core.Application.Interfaces;
using TicTacToe.Infrastructure.Repository.UnitOfWork;
using TicTacToe.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using TicTacToe.Presentation.WebUI.Models;
using TicTacToe.Infrastructure.Persistence;

namespace TicTacToe.Tests.WebUI.Controllers
{
    [TestFixture]
    public class BoxControllerTests
    {
        private BoxController controller;
        private Mock<IBoxService> boxServiceMock;
        private Mock<IPlayerService> playerServiceMock;
        private Mock<IUnitOfWorkFactory> unitOfWorkFactoryMock;
        private Mock<ITicTacToeContext> ticTacToeContextMock;

        public BoxControllerTests()
        {

        }

        [SetUp]
        public void Setup()
        {
            boxServiceMock = new Mock<IBoxService>();
            playerServiceMock = new Mock<IPlayerService>();
            unitOfWorkFactoryMock = new Mock<IUnitOfWorkFactory>();
            ticTacToeContextMock = new Mock<ITicTacToeContext>();
            controller = new BoxController(boxServiceMock.Object, playerServiceMock.Object, unitOfWorkFactoryMock.Object);
        }

        [Test]
        public void Should_Mark_Box()
        {
            // Arrange
            var playerId = Guid.NewGuid();
            var boxId = Guid.NewGuid();

            boxServiceMock
                .Setup(m => m.Get(It.IsAny<Guid>()))
                .Returns(new Box
                {
                    BoxId = boxId
                });

            playerServiceMock
                .Setup(m => m.Get(It.IsAny<Guid>()))
                .Returns(new Player
                {

                });

            unitOfWorkFactoryMock
                .Setup(m => m.Create())
                .Returns(new UnitOfWork(ticTacToeContextMock.Object)
                {

                });

            // Act
            var response = controller.Mark(playerId, boxId);
            var okResult = response.Result as OkObjectResult;
            var boxViewModel = okResult.Value as BoxViewModel;

            // Assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(okResult.StatusCode, 200);
            Assert.AreEqual(boxViewModel.BoxId, boxId);
        }
    }
}