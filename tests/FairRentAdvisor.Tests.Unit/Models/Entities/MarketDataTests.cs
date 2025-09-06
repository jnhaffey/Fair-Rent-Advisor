using FluentAssertions;
using FairRentAdvisor.Core.Models.Entities;
using FairRentAdvisor.Core.Models.ValueObjects;
using FairRentAdvisor.Core.Models;
using System.Text.Json;

namespace FairRentAdvisor.Tests.Unit.Models.Entities;

public class MarketDataTests
{
    [Fact]
    public void Constructor_DefaultValues_SetsCorrectDefaults()
    {
        // Act
        var marketData = new MarketData();
        
        // Assert
        marketData.Id.Should().NotBeNullOrEmpty();
        marketData.AnalysisDate.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(5));
        marketData.LastUpdated.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(5));
        marketData.Trend.Should().NotBeNull();
    }

    [Fact]
    public void PartitionKey_ValidPostcode_ReturnsPostcodeValue()
    {
        // Arrange
        var marketData = new MarketData
        {
            Postcode = "SW1A 1AA"
        };
        
        // Act
        var partitionKey = marketData.PartitionKey;
        
        // Assert
        partitionKey.Should().Be("SW1A 1AA");
    }

    [Fact]
    public void SetMarketStatistics_ValidData_CalculatesCorrectly()
    {
        // Arrange
        var marketData = new MarketData();
        var rents = new List<decimal> { 2000, 2200, 2500, 2800, 3000 };
        
        // Act
        marketData.Postcode = "SW1A 1AA";
        marketData.PropertyType = PropertyType.Flat;
        marketData.Bedrooms = 2;
        marketData.AverageRent = rents.Average();
        marketData.MedianRent = 2500; // Middle value
        marketData.MinRent = rents.Min();
        marketData.MaxRent = rents.Max();
        marketData.SampleSize = rents.Count;
        
        // Assert
        marketData.AverageRent.Should().Be(2500);
        marketData.MedianRent.Should().Be(2500);
        marketData.MinRent.Should().Be(2000);
        marketData.MaxRent.Should().Be(3000);
        marketData.SampleSize.Should().Be(5);
    }

    [Theory]
    [InlineData(0, 2000, 2500, 1800, 3200, 10)]
    [InlineData(1, 1800, 2200, 1500, 2800, 15)]
    [InlineData(2, 2500, 2800, 2000, 3500, 25)]
    public void SetStatistics_DifferentBedroomCounts_AcceptsValidData(
        int bedrooms, decimal avg, decimal median, decimal min, decimal max, int sampleSize)
    {
        // Arrange
        var marketData = new MarketData();
        
        // Act
        marketData.Bedrooms = bedrooms;
        marketData.AverageRent = avg;
        marketData.MedianRent = median;
        marketData.MinRent = min;
        marketData.MaxRent = max;
        marketData.SampleSize = sampleSize;
        
        // Assert
        marketData.Bedrooms.Should().Be(bedrooms);
        marketData.AverageRent.Should().Be(avg);
        marketData.MedianRent.Should().Be(median);
        marketData.MinRent.Should().Be(min);
        marketData.MaxRent.Should().Be(max);
        marketData.SampleSize.Should().Be(sampleSize);
    }

    [Fact]
    public void PriceTrend_WhenSet_StoresCorrectly()
    {
        // Arrange
        var marketData = new MarketData();
        var trend = new PriceTrend
        {
            MonthlyGrowthRate = 0.05m,
            Direction = "increasing",
            Confidence = 85
        };
        
        // Act
        marketData.Trend = trend;
        
        // Assert
        marketData.Trend.MonthlyGrowthRate.Should().Be(0.05m);
        marketData.Trend.Direction.Should().Be("increasing");
        marketData.Trend.Confidence.Should().Be(85);
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
        var isFresh = marketData.LastUpdated > DateTime.UtcNow.AddHours(-24);
        
        // Assert
        isFresh.Should().BeTrue();
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
        var isFresh = marketData.LastUpdated > DateTime.UtcNow.AddHours(-24);
        
        // Assert
        isFresh.Should().BeFalse();
    }

    [Fact]
    public void JsonSerialization_CompleteMarketData_SerializesCorrectly()
    {
        // Arrange
        var marketData = new MarketData
        {
            Id = "test-market-data",
            Postcode = "SW1A 1AA",
            PropertyType = PropertyType.Flat,
            Bedrooms = 2,
            AverageRent = 2500,
            MedianRent = 2400,
            MinRent = 2000,
            MaxRent = 3200,
            SampleSize = 20,
            PricePerSqFt = 45.50m,
            Trend = new PriceTrend
            {
                MonthlyGrowthRate = 0.03m,
                Direction = "increasing",
                Confidence = 78
            },
            AnalysisDate = DateTime.UtcNow.AddDays(-1),
            LastUpdated = DateTime.UtcNow
        };

        // Act
        var json = JsonSerializer.Serialize(marketData);
        var deserialized = JsonSerializer.Deserialize<MarketData>(json);

        // Assert
        deserialized.Should().NotBeNull();
        deserialized!.Postcode.Should().Be(marketData.Postcode);
        deserialized.PropertyType.Value.Should().Be(marketData.PropertyType.Value);
        deserialized.AverageRent.Should().Be(marketData.AverageRent);
        deserialized.Trend.MonthlyGrowthRate.Should().Be(marketData.Trend.MonthlyGrowthRate);
    }

    [Fact]
    public void CalculateVariance_ValidData_ReturnsCorrectVariance()
    {
        // Arrange
        var marketData = new MarketData
        {
            MinRent = 2000,
            MaxRent = 3000,
            MedianRent = 2500
        };
        
        // Act
        var range = marketData.MaxRent - marketData.MinRent;
        var variance = range / marketData.MedianRent;
        
        // Assert
        variance.Should().Be(0.4m); // (3000-2000)/2500 = 0.4
    }
}
