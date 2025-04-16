using Accruent.Data.Context;
using Accruent.Data.Repository;
using Accruent.Models.Entity;
using Accruent.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace Accruent.UnitTests.Repositories;

public class MovementRepositoryTests
{
    private readonly AccruentDbContext _dbContext;
    private readonly MovementRepository _movementRepository;

    public MovementRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<AccruentDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
        _dbContext = new AccruentDbContext(options);

        _movementRepository = new MovementRepository(_dbContext);
    }

    [Fact]
    public async Task InsertAsync_AddsMovementToDbSet()
    {
        // Arrange
        var movement = new Movement
        {
            Id = Guid.NewGuid(),
            ProductId = Guid.NewGuid(),
            Type = EMovementType.Inbound,
            CreatedOn = DateTime.Now,
            Quantity = 10
        };

        // Act
        await _movementRepository.InsertAsync(movement, CancellationToken.None);

        // Assert
        Assert.NotNull(_dbContext.Movements.FirstOrDefault(x => x.Id == movement.Id));
    }

    [Fact]
    public void GetByFilter_ReturnsFilteredMovements()
    {
        // Arrange
        var movements = new List<Movement>
        {
            new Movement { Id = Guid.NewGuid(), ProductId = Guid.NewGuid(), Type = EMovementType.Inbound, CreatedOn = DateTime.Now, Quantity = 10 },
            new Movement { Id = Guid.NewGuid(), ProductId = Guid.NewGuid(), Type = EMovementType.Outbound, CreatedOn = DateTime.Now, Quantity = 5 }
        }.AsQueryable();

        _dbContext.Movements.AddRange(movements);
        _dbContext.SaveChanges();

        // Act
        var result = _movementRepository.GetByFilter(x => x.Type == EMovementType.Inbound);

        // Assert
        Assert.Single(result);
        Assert.Equal(10, result.First().Quantity);
    }

    [Fact]
    public async Task GetAllAsync_ReturnsAllMovements()
    {
        // Arrange
        var movements = new List<Movement>
        {
            new Movement { Id = Guid.NewGuid(), ProductId = Guid.NewGuid(), Type = EMovementType.Inbound, CreatedOn = DateTime.Now, Quantity = 10 },
            new Movement { Id = Guid.NewGuid(), ProductId = Guid.NewGuid(), Type = EMovementType.Outbound, CreatedOn = DateTime.Now, Quantity = 5 }
        }.AsQueryable();

        _dbContext.Movements.AddRange(movements);
        _dbContext.SaveChanges();

        // Act
        var result = await _movementRepository.GetAllAsync(0, CancellationToken.None);

        // Assert
        Assert.Equal(2, result.Count);
    }
}
