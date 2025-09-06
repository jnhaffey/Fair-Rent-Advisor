using FairRentAdvisor.Core.Models.ValueObjects;

namespace FairRentAdvisor.Tests.Unit.Models.ValueObjects;

public class MonthlyRentTests
{
    [Theory]
    [InlineData(500)]
    [InlineData(1000.50)]
    [InlineData(5000)]
    public void Constructor_ValidAmount_CreatesInstance(decimal amount)
    {
        // Act
        var rent = new MonthlyRent(amount);
        
        // Assert
        rent.Amount.Should().Be(amount);
        rent.Currency.Should().Be("GBP");
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-100)]
    public void Constructor_NegativeAmount_ThrowsArgumentException(decimal amount)
    {
        // Act & Assert
        var action = () => new MonthlyRent(amount);
        action.Should().Throw<ArgumentException>()
            .WithMessage("*Rent amount cannot be negative*");
    }

    [Fact]
    public void Constructor_UnrealisticAmount_ThrowsArgumentException()
    {
        // Act & Assert
        var action = () => new MonthlyRent(100000);
        action.Should().Throw<ArgumentException>()
            .WithMessage("*Rent amount seems unrealistic*");
    }

    [Fact]
    public void Constructor_WithCurrency_SetsCorrectCurrency()
    {
        // Act
        var rent = new MonthlyRent(1000, "EUR");
        
        // Assert
        rent.Amount.Should().Be(1000);
        rent.Currency.Should().Be("EUR");
    }

    [Fact]
    public void ImplicitDecimalConversion_ValidRent_ReturnsAmount()
    {
        // Arrange
        var rent = new MonthlyRent(1500);
        
        // Act
        decimal amount = rent;
        
        // Assert
        amount.Should().Be(1500);
    }

    [Fact]
    public void ImplicitRentConversion_ValidDecimal_CreatesRent()
    {
        // Act
        MonthlyRent rent = 2000m;
        
        // Assert
        rent.Amount.Should().Be(2000);
        rent.Currency.Should().Be("GBP");
    }
}
