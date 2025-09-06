using FairRentAdvisor.Core.Models.ValueObjects;

namespace FairRentAdvisor.Tests.Unit.Models.ValueObjects;

public class PropertyTypeTests
{
    [Theory]
    [InlineData("flat", "flat")]
    [InlineData("apartment", "flat")]
    [InlineData("house", "house")]
    [InlineData("terraced", "house")]
    [InlineData("studio", "studio")]
    [InlineData("room", "room")]
    public void FromString_ValidType_ReturnsCorrectPropertyType(string input, string expected)
    {
        // Act
        var propertyType = PropertyType.FromString(input);
        
        // Assert
        propertyType.Value.Should().Be(expected);
    }

    [Theory]
    [InlineData("invalid")]
    public void FromString_InvalidType_ThrowsArgumentException(string input)
    {
        // Act & Assert
        var action = () => PropertyType.FromString(input);
        action.Should().Throw<ArgumentException>()
            .WithMessage("*Unknown property type*");
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void FromString_EmptyOrWhitespaceType_ThrowsArgumentException(string input)
    {
        // Act & Assert
        var action = () => PropertyType.FromString(input);
        action.Should().Throw<ArgumentException>()
            .WithMessage("*Property type cannot be empty*");
    }

    [Fact]
    public void FromString_NullType_ThrowsArgumentException()
    {
        // Act & Assert
        var action = () => PropertyType.FromString(null!);
        action.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void StaticInstances_HaveCorrectValues()
    {
        // Assert
        PropertyType.Flat.Value.Should().Be("flat");
        PropertyType.House.Value.Should().Be("house");
        PropertyType.Studio.Value.Should().Be("studio");
        PropertyType.Room.Value.Should().Be("room");
    }

    [Fact]
    public void ImplicitStringConversion_ValidPropertyType_ReturnsValue()
    {
        // Arrange
        var propertyType = PropertyType.Flat;
        
        // Act
        string result = propertyType;
        
        // Assert
        result.Should().Be("flat");
    }
}
