using FluentAssertions;
using FairRentAdvisor.Core.Models.Entities;
using FairRentAdvisor.Core.Models.ValueObjects;

namespace FairRentAdvisor.Tests.Unit.Models.Entities;

public class MarketDataBusinessLogicTests
{
    [Fact]
    public void IsValidSample_ValidData_ReturnsTrue()
    {
        // Arrange
        var marketData = new MarketData
        {
            SampleSize = 5,
            MinRent = 2000,
            MaxRent = 3000
        };
        
        // Act
        var result = marketData.IsValidSample();
        
        // Assert
        result.Should().BeTrue();
    }

    [Theory]
    [InlineData(2, 2000, 3000)] // Too few samples
    [InlineData(5, 0, 3000)]    // Invalid min rent
    [InlineData(5, 3000, 2000)] // Max less than min
    public void IsValidSample_InvalidData_ReturnsFalse(int sampleSize, decimal minRent, decimal maxRent)
    {
        // Arrange
        var marketData = new MarketData
        {
            SampleSize = sampleSize,
            MinRent = minRent,
            MaxRent = maxRent
        };
        
        // Act
        var result = marketData.IsValidSample();
        
        // Assert
        result.Should().BeFalse();
    }

    [Theory]
    [InlineData(25, 90)]
    [InlineData(15, 75)]
    [InlineData(8, 60)]
    [InlineData(4, 45)]
    [InlineData(2, 30)]
    public void GetConfidenceScore_DifferentSampleSizes_ReturnsExpectedScore(int sampleSize, int expectedScore)
    {
        // Arrange
        var marketData = new MarketData { SampleSize = sampleSize };
        
        // Act
        var result = marketData.GetConfidenceScore();
        
        // Assert
        result.Should().Be(expectedScore);
    }

    [Fact]
    public void UpdateStatistics_ValidRents_CalculatesCorrectly()
    {
        // Arrange
        var marketData = new MarketData();
        var rents = new List<decimal> { 2000, 2200, 2500, 2800, 3000 };
        var originalLastUpdated = marketData.LastUpdated;
        
        // Act
        Thread.Sleep(10);
        marketData.UpdateStatistics(rents);
        
        // Assert
        marketData.AverageRent.Should().Be(2500);
        marketData.MedianRent.Should().Be(2500);
        marketData.MinRent.Should().Be(2000);
        marketData.MaxRent.Should().Be(3000);
        marketData.SampleSize.Should().Be(5);
        marketData.LastUpdated.Should().BeAfter(originalLastUpdated);
    }

    [Fact]
    public void UpdateStatistics_EvenNumberOfRents_CalculatesMedianCorrectly()
    {
        // Arrange
        var marketData = new MarketData();
        var rents = new List<decimal> { 2000, 2400, 2600, 3000 };
        
        // Act
        marketData.UpdateStatistics(rents);
        
        // Assert
        marketData.MedianRent.Should().Be(2500); // (2400 + 2600) / 2
    }

    [Fact]
    public void UpdateStatistics_OddNumberOfRents_CalculatesMedianCorrectly()
    {
        // Arrange
        var marketData = new MarketData();
        var rents = new List<decimal> { 2000, 2400, 2500, 2600, 3000 };
        
        // Act
        marketData.UpdateStatistics(rents);
        
        // Assert
        marketData.MedianRent.Should().Be(2500); // Middle value
    }

    [Fact]
    public void UpdateStatistics_EmptyRents_DoesNotUpdate()
    {
        // Arrange
        var marketData = new MarketData 
        { 
            AverageRent = 1000,
            SampleSize = 5
        };
        var originalAverage = marketData.AverageRent;
        var originalSampleSize = marketData.SampleSize;
        
        // Act
        marketData.UpdateStatistics(new List<decimal>());
        
        // Assert
        marketData.AverageRent.Should().Be(originalAverage);
        marketData.SampleSize.Should().Be(originalSampleSize);
    }

    [Fact]
    public void IsDataFresh_RecentData_ReturnsTrue()
    {
        // Arrange
        var marketData = new MarketData 
        { 
            LastUpdated = DateTime.UtcNow.AddHours(-1) 
        };
        
        // Act
        var result = marketData.IsDataFresh(TimeSpan.FromDays(1));
        
        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void IsDataFresh_OldData_ReturnsFalse()
    {
        // Arrange
        var marketData = new MarketData 
        { 
            LastUpdated = DateTime.UtcNow.AddDays(-2) 
        };
        
        // Act
        var result = marketData.IsDataFresh(TimeSpan.FromDays(1));
        
        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void CalculateVarianceCoefficient_ValidData_ReturnsCorrectValue()
    {
        // Arrange
        var marketData = new MarketData
        {
            MinRent = 2000,
            MaxRent = 3000,
            MedianRent = 2500
        };
        
        // Act
        var result = marketData.CalculateVarianceCoefficient();
        
        // Assert
        result.Should().Be(0.4m); // (3000-2000)/2500 = 0.4
    }

    [Fact]
    public void CalculateVarianceCoefficient_ZeroMedian_ReturnsZero()
    {
        // Arrange
        var marketData = new MarketData
        {
            MinRent = 2000,
            MaxRent = 3000,
            MedianRent = 0
        };
        
        // Act
        var result = marketData.CalculateVarianceCoefficient();
        
        // Assert
        result.Should().Be(0);
    }
}
