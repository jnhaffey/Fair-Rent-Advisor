using FluentAssertions;
using FairRentAdvisor.Core.Models.Entities;
using FairRentAdvisor.Core.Models.ValueObjects;
using FairRentAdvisor.Core.Models;
using FairRentAdvisor.Tests.Unit.TestUtilities;

namespace FairRentAdvisor.Tests.Unit.Models.Entities;

public class PropertyBusinessLogicTests
{
    [Fact]
    public void IsAvailableNow_NoAvailableDate_ReturnsTrue()
    {
        // Arrange
        var property = new Property { AvailableDate = null };
        
        // Act
        var result = property.IsAvailableNow();
        
        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void IsAvailableNow_PastDate_ReturnsTrue()
    {
        // Arrange
        var property = new Property { AvailableDate = DateTime.UtcNow.AddDays(-1) };
        
        // Act
        var result = property.IsAvailableNow();
        
        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void IsAvailableNow_FutureDate_ReturnsFalse()
    {
        // Arrange
        var property = new Property { AvailableDate = DateTime.UtcNow.AddDays(1) };
        
        // Act
        var result = property.IsAvailableNow();
        
        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void IsAvailableWithin_WithinTimespan_ReturnsTrue()
    {
        // Arrange
        var property = new Property { AvailableDate = DateTime.UtcNow.AddDays(10) };
        
        // Act
        var result = property.IsAvailableWithin(TimeSpan.FromDays(14));
        
        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void IsAvailableWithin_OutsideTimespan_ReturnsFalse()
    {
        // Arrange
        var property = new Property { AvailableDate = DateTime.UtcNow.AddDays(20) };
        
        // Act
        var result = property.IsAvailableWithin(TimeSpan.FromDays(14));
        
        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void HasNearbyTransport_WithNearbyStation_ReturnsTrue()
    {
        // Arrange
        var property = new Property();
        property.TransportLinks.Add(new TransportLink { WalkTimeMinutes = 5 });
        
        // Act
        var result = property.HasNearbyTransport();
        
        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void HasNearbyTransport_WithoutNearbyStation_ReturnsFalse()
    {
        // Arrange
        var property = new Property();
        property.TransportLinks.Add(new TransportLink { WalkTimeMinutes = 15 });
        
        // Act
        var result = property.HasNearbyTransport();
        
        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void GetUndergroundStations_FiltersTubeStations()
    {
        // Arrange
        var property = new Property();
        property.TransportLinks.Add(new TransportLink { StationType = "tube", StationName = "Victoria" });
        property.TransportLinks.Add(new TransportLink { StationType = "bus", StationName = "Bus Stop" });
        property.TransportLinks.Add(new TransportLink { StationType = "rail", StationName = "Train Station" });
        
        // Act
        var result = property.GetUndergroundStations().ToList();
        
        // Assert
        result.Should().HaveCount(1);
        result.First().StationName.Should().Be("Victoria");
    }

    [Fact]
    public void MarkAsInactive_UpdatesStatusAndTimestamp()
    {
        // Arrange
        var property = new Property { IsActive = true };
        var originalUpdatedAt = property.UpdatedAt;
        
        // Act
        Thread.Sleep(10);
        property.MarkAsInactive();
        
        // Assert
        property.IsActive.Should().BeFalse();
        property.UpdatedAt.Should().BeAfter(originalUpdatedAt);
    }

    [Fact]
    public void UpdateDetails_UpdatesPropertiesAndTimestamp()
    {
        // Arrange
        var property = new Property 
        { 
            MonthlyRent = new MonthlyRent(2000),
            Furnished = false,
            HasGarden = false
        };
        var originalUpdatedAt = property.UpdatedAt;
        var newRent = new MonthlyRent(2500);
        
        // Act
        Thread.Sleep(10);
        property.UpdateDetails(newRent, true, true);
        
        // Assert
        property.MonthlyRent.Should().Be(newRent);
        property.Furnished.Should().BeTrue();
        property.HasGarden.Should().BeTrue();
        property.UpdatedAt.Should().BeAfter(originalUpdatedAt);
    }
}
