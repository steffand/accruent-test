using Accruent.Data.Interface;
using Accruent.Domain.Services;
using Accruent.Models.Entity;
using Accruent.Models.Enums;
using NSubstitute;

namespace Accruent.UnitTests.Services;

public class ReportServiceTests
{
    private readonly IBaseRepository<Movement> _mockMovementRepository;
    private readonly IBaseRepository<Product> _mockProductRepository;
    private readonly ReportService _reportService;

    public ReportServiceTests()
    {
        _mockMovementRepository = Substitute.For<IBaseRepository<Movement>>();
        _mockProductRepository = Substitute.For<IBaseRepository<Product>>();
        _reportService = new ReportService(_mockMovementRepository, _mockProductRepository);
    }

    [Fact]
    public void GetReportData_ReturnsCorrectReport_WhenProductCodeIsProvided()
    {
        // Arrange
        var product = new Product { Id = Guid.NewGuid(), Code = "P001", Name = "Product 1" };
        var movements = new List<Movement>
        {
            new Movement { ProductId = product.Id, Quantity = 10, Type = EMovementType.Inbound, CreatedOn = DateTime.Now, Product = product },
            new Movement { ProductId = product.Id, Quantity = -5, Type = EMovementType.Outbound, CreatedOn = DateTime.Now, Product = product }
        };

        _mockProductRepository.GetByFilter(Arg.Any<Func<Product, bool>>())
            .Returns(new List<Product> { product });
        _mockMovementRepository.GetByFilter(Arg.Any<Func<Movement, bool>>())
            .Returns(movements);

        // Act
        var result = _reportService.GetReportData(DateTime.Now.Date, "P001");

        // Assert
        Assert.Single(result);
        Assert.Equal("P001", result[0].ProductCode);
        Assert.Equal("Product 1", result[0].ProductName);
        Assert.Equal(10, result[0].Inbounds);
        Assert.Equal(-5, result[0].Outbounds);
        Assert.Equal(5, result[0].Balance);
    }

    [Fact]
    public void GetReportData_ReturnsEmptyReport_WhenNoMovementsExist()
    {
        // Arrange
        _mockProductRepository.GetByFilter(Arg.Any<Func<Product, bool>>())
            .Returns(new List<Product>());
        _mockMovementRepository.GetByFilter(Arg.Any<Func<Movement, bool>>())
            .Returns(new List<Movement>());

        // Act
        var result = _reportService.GetReportData(DateTime.Now.Date, "P001");

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GetReportData_ReturnsReportForAllProducts_WhenProductCodeIsNull()
    {
        // Arrange
        var product = new Product { Id = Guid.NewGuid(), Code = "P001", Name = "Product 1" };
        var movements = new List<Movement>
        {
            new Movement { ProductId = product.Id, Quantity = 10, Type = EMovementType.Inbound, CreatedOn = DateTime.Now, Product = product },
            new Movement { ProductId = product.Id, Quantity = -5, Type = EMovementType.Outbound, CreatedOn = DateTime.Now, Product = product }
        };

        _mockProductRepository.GetByFilter(Arg.Any<Func<Product, bool>>())
            .Returns(new List<Product> { product });
        _mockMovementRepository.GetByFilter(Arg.Any<Func<Movement, bool>>())
            .Returns(movements);

        // Act
        var result = _reportService.GetReportData(DateTime.Now.Date, null);

        // Assert
        Assert.Single(result);
        Assert.Equal("P001", result[0].ProductCode);
        Assert.Equal("Product 1", result[0].ProductName);
        Assert.Equal(10, result[0].Inbounds);
        Assert.Equal(-5, result[0].Outbounds);
        Assert.Equal(5, result[0].Balance);
    }
}
