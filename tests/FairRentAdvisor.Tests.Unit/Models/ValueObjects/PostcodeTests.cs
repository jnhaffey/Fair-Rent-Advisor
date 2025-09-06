using FairRentAdvisor.Core.Models.ValueObjects;

namespace FairRentAdvisor.Tests.Unit.Models.ValueObjects;

public class PostcodeTests
{
    [Theory]
    [InlineData("SW1A 1AA")]
    [InlineData("SW1A1AA")]
    [InlineData("sw1a 1aa")]
    [InlineData("sw1a1aa")]
    public void Constructor_ValidPostcode_CreatesInstanceWithCorrectFormat(string input)
    {
        // Act
        var postcode = new Postcode(input);
        
        // Assert
        postcode.Value.Should().Be("SW1A 1AA");
        postcode.OutwardCode.Should().Be("SW1A");
        postcode.InwardCode.Should().Be("1AA");
    }

    [Theory]
    [InlineData("INVALID")]
    [InlineData("123456")]
    [InlineData("SW1A")]
    [InlineData("SW1A 1AAA")]
    public void Constructor_InvalidPostcode_ThrowsArgumentException(string input)
    {
        // Act & Assert
        var action = () => new Postcode(input);
        action.Should().Throw<ArgumentException>()
            .WithMessage("*Invalid UK postcode format*");
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void Constructor_EmptyOrWhitespacePostcode_ThrowsArgumentException(string input)
    {
        // Act & Assert
        var action = () => new Postcode(input);
        action.Should().Throw<ArgumentException>()
            .WithMessage("*Postcode cannot be empty*");
    }

    [Fact]
    public void Constructor_NullPostcode_ThrowsArgumentException()
    {
        // Act & Assert
        var action = () => new Postcode(null!);
        action.Should().Throw<ArgumentException>()
            .WithMessage("*Postcode cannot be empty*");
    }

    [Fact]
    public void ImplicitStringConversion_ValidPostcode_ReturnsCorrectString()
    {
        // Arrange
        var postcode = new Postcode("SW1A 1AA");
        
        // Act
        string result = postcode;
        
        // Assert
        result.Should().Be("SW1A 1AA");
    }

    [Fact]
    public void ImplicitPostcodeConversion_ValidString_CreatesCorrectPostcode()
    {
        // Act
        Postcode postcode = "SW1A 1AA";
        
        // Assert
        postcode.Value.Should().Be("SW1A 1AA");
    }

    [Fact]
    public void Equals_SamePostcode_ReturnsTrue()
    {
        // Arrange
        var postcode1 = new Postcode("SW1A 1AA");
        var postcode2 = new Postcode("sw1a1aa");
        
        // Act & Assert
        postcode1.Should().Be(postcode2);
        (postcode1 == postcode2).Should().BeTrue();
    }
}
