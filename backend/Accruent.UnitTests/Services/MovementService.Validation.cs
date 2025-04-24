using Accruent.Data.Interfaces;
using Accruent.Domain.Interfaces;
using Accruent.Domain.Services;
using Accruent.Models.Dtos;
using Accruent.Models.Entities;
using Accruent.Models.Enums;
using Accruent.Models.Exceptions;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace Accruent.UnitTests.Services;

public class MovementServiceValidationTests
{
    private readonly IMovementService _mockBaseService;
    private readonly IBaseRepository<Movement> _mockMovementRepository;
    private readonly IBaseRepository<Product> _mockProductRepository;
    private readonly ILogger<MovementService> _mockLogger;
    private readonly MovementServiceValidation _service;

    public MovementServiceValidationTests()
    {
        _mockBaseService = Substitute.For<IMovementService>();
        _mockMovementRepository = Substitute.For<IBaseRepository<Movement>>();
        _mockProductRepository = Substitute.For<IBaseRepository<Product>>();
        _mockLogger = Substitute.For<ILogger<MovementService>>();

        _service = new MovementServiceValidation(_mockBaseService, _mockMovementRepository, _mockProductRepository, _mockLogger);
    }

    [Fact]
    public async Task ProcessAsync_ThrowsProductNotFoundException_WhenProductDoesNotExist()
    {
        // Arrange
        var movement = new MovementDto { ProductCode = "P001", Quantity = 10 };
        _mockProductRepository.GetByFilter(Arg.Any<Func<Product, bool>>()).Returns(new List<Product>());

        // Act & Assert
        await Assert.ThrowsAsync<ProductNotFoundException>(() => _service.ProcessAsync(movement, CancellationToken.None));
    }

    [Fact]
    public async Task ProcessAsync_ThrowsInsufficientBalanceException_WhenBalanceIsNegative()
    {
        // Arrange
        var product = new Product { Id = Guid.NewGuid(), Code = "P001" };
        var movements = new List<Movement>
        {
            new Movement { ProductId = product.Id, Quantity = 5, Type = EMovementType.Inbound }
        };

        var movementDto = new MovementDto { ProductCode = "P001", Quantity = -10, Type = EMovementType.Outbound.ToString() };

        _mockProductRepository.GetByFilter(Arg.Any<Func<Product, bool>>()).Returns(new List<Product> { product });
        _mockMovementRepository.GetByFilter(Arg.Any<Func<Movement, bool>>()).Returns(movements);

        // Act & Assert
        await Assert.ThrowsAsync<InsuficientBalanceException>(() => _service.ProcessAsync(movementDto, CancellationToken.None));
    }

    [Fact]
    public async Task ProcessAsync_CallsBaseService_WhenValidationPasses()
    {
        // Arrange
        var product = new Product { Id = Guid.NewGuid(), Code = "P001" };
        var movements = new List<Movement>
        {
            new Movement { ProductId = product.Id, Quantity = 10, Type = EMovementType.Inbound }
        };

        var movementDto = new MovementDto { ProductCode = "P001", Quantity = 5, Type = EMovementType.Outbound.ToString() };

        _mockProductRepository.GetByFilter(Arg.Any<Func<Product, bool>>()).Returns(new List<Product> { product });
        _mockMovementRepository.GetByFilter(Arg.Any<Func<Movement, bool>>()).Returns(movements);

        // Act
        await _service.ProcessAsync(movementDto, CancellationToken.None);

        // Assert
        await _mockBaseService.Received(1).ProcessAsync(movementDto, Arg.Any<CancellationToken>());
    }
}

