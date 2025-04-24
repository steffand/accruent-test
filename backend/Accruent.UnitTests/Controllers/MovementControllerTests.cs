using Accruent.Api.Controllers;
using Accruent.Data.Interfaces;
using Accruent.Domain.Interfaces;
using Accruent.Models.Dtos;
using Accruent.Models.Entities;
using Accruent.Models.Exceptions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace Accruent.UnitTests.Controllers;

public class MovementControllerTests
{
    private readonly IBaseRepository<Movement> _mockMovementRepository;
    private readonly IMovementService _mockMovementService;
    private readonly MovementController _controller;

    public MovementControllerTests()
    {
        _mockMovementRepository = Substitute.For<IBaseRepository<Movement>>();
        _mockMovementService = Substitute.For<IMovementService>();
        _controller = new MovementController(_mockMovementRepository, _mockMovementService);
    }

    [Fact]
    public async Task Get_ReturnsMovements()
    {
        // Arrange
        var movements = new List<Movement>
        {
            new Movement { Id = Guid.NewGuid(), ProductId = Guid.NewGuid(), Quantity = 10 },
            new Movement { Id = Guid.NewGuid(), ProductId = Guid.NewGuid(), Quantity = 20 }
        };
        _mockMovementRepository.GetAllAsync(Arg.Any<int>(), Arg.Any<CancellationToken>())
            .Returns(movements);

        // Act
        var result = await _controller.Get(0, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Data.Count());
    }

    [Fact]
    public async Task CreateAsync_ReturnsOk_WhenSuccessful()
    {
        // Arrange
        var movementDto = new MovementDto { ProductCode = "A", Quantity = 10 };

        _mockMovementService.ProcessAsync(movementDto, Arg.Any<CancellationToken>())
            .Returns(Task.CompletedTask);

        // Act
        var result = await _controller.CreateAsync(movementDto, CancellationToken.None);

        // Assert
        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public async Task CreateAsync_ReturnsBadRequest_WhenInsufficientBalance()
    {
        // Arrange
        var movementDto = new MovementDto { ProductCode = "A", Quantity = 10 };

        _mockMovementService.ProcessAsync(movementDto, Arg.Any<CancellationToken>())
            .Throws(new InsuficientBalanceException("Insufficient balance"));

        // Act
        var result = await _controller.CreateAsync(movementDto, CancellationToken.None);

        // Assert
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("Insufficient balance", badRequestResult.Value);
    }

    [Fact]
    public async Task CreateAsync_ReturnsNotFound_WhenProductNotFound()
    {
        // Arrange
        var movementDto = new MovementDto { ProductCode = "A", Quantity = 10 };

        _mockMovementService.ProcessAsync(movementDto, Arg.Any<CancellationToken>())
            .Throws(new ProductNotFoundException("Product not found"));

        // Act
        var result = await _controller.CreateAsync(movementDto, CancellationToken.None);

        // Assert
        var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
        Assert.Equal("Product not found", notFoundResult.Value);
    }
}
