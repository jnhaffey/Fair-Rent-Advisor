using FluentAssertions;
using FairRentAdvisor.Core.Models.Entities;
using FairRentAdvisor.Tests.Unit.TestUtilities;
using System.Text.Json;

namespace FairRentAdvisor.Tests.Unit.Models.Entities;

public class JsonSerializationTests
{
    [Fact]
    public void AllEntities_JsonSerialization_RoundTripSuccessful()
    {
        // Arrange
        var property = TestDataBuilder.CreateSampleProperty();
        var marketData = TestDataBuilder.CreateSampleMarketData();
        
        // Act
        var propertyJson = JsonSerializer.Serialize(property);
        var marketDataJson = JsonSerializer.Serialize(marketData);
        
        var deserializedProperty = JsonSerializer.Deserialize<Property>(propertyJson);
        var deserializedMarketData = JsonSerializer.Deserialize<MarketData>(marketDataJson);
        
        // Assert - Property
        deserializedProperty.Should().NotBeNull();
        deserializedProperty!.Id.Should().Be(property.Id);
        deserializedProperty.Postcode.Value.Should().Be(property.Postcode.Value);
        deserializedProperty.MonthlyRent.Amount.Should().Be(property.MonthlyRent.Amount);
        deserializedProperty.PropertyType.Value.Should().Be(property.PropertyType.Value);
        deserializedProperty.Bedrooms.Should().Be(property.Bedrooms);
        deserializedProperty.Furnished.Should().Be(property.Furnished);
        deserializedProperty.HasGarden.Should().Be(property.HasGarden);
        deserializedProperty.Description.Should().Be(property.Description);
        deserializedProperty.IsActive.Should().Be(property.IsActive);
        deserializedProperty.Source.Should().Be(property.Source);
        
        // Assert - MarketData
        deserializedMarketData.Should().NotBeNull();
        deserializedMarketData!.Id.Should().Be(marketData.Id);
        deserializedMarketData.Postcode.Should().Be(marketData.Postcode);
        deserializedMarketData.PropertyType.Value.Should().Be(marketData.PropertyType.Value);
        deserializedMarketData.Bedrooms.Should().Be(marketData.Bedrooms);
        deserializedMarketData.AverageRent.Should().Be(marketData.AverageRent);
        deserializedMarketData.MedianRent.Should().Be(marketData.MedianRent);
        deserializedMarketData.SampleSize.Should().Be(marketData.SampleSize);
        deserializedMarketData.Trend.MonthlyGrowthRate.Should().Be(marketData.Trend.MonthlyGrowthRate);
        deserializedMarketData.Trend.Direction.Should().Be(marketData.Trend.Direction);
        deserializedMarketData.Trend.Confidence.Should().Be(marketData.Trend.Confidence);
    }

    [Fact]
    public void Property_JsonSerialization_PreservesCoordinates()
    {
        // Arrange
        var property = TestDataBuilder.CreateSampleProperty();
        
        // Act
        var json = JsonSerializer.Serialize(property);
        var deserialized = JsonSerializer.Deserialize<Property>(json);
        
        // Assert
        deserialized!.Coordinates.Should().NotBeNull();
        deserialized.Coordinates!.Latitude.Should().Be(property.Coordinates!.Latitude);
        deserialized.Coordinates.Longitude.Should().Be(property.Coordinates.Longitude);
    }

    [Fact]
    public void Property_JsonSerialization_PreservesCollections()
    {
        // Arrange
        var property = TestDataBuilder.CreateSampleProperty();
        property.Features.AddRange(new[] { "Balcony", "Parking", "Gym" });
        property.TransportLinks.Add(new() 
        { 
            StationName = "Victoria", 
            StationType = "tube", 
            WalkTimeMinutes = 5,
            Lines = new List<string> { "Victoria", "District" },
            Zone = "1"
        });
        
        // Act
        var json = JsonSerializer.Serialize(property);
        var deserialized = JsonSerializer.Deserialize<Property>(json);
        
        // Assert
        deserialized!.Features.Should().HaveCount(3);
        deserialized.Features.Should().Contain("Balcony");
        deserialized.Features.Should().Contain("Parking");
        deserialized.Features.Should().Contain("Gym");
        
        deserialized.TransportLinks.Should().HaveCount(1);
        deserialized.TransportLinks.First().StationName.Should().Be("Victoria");
        deserialized.TransportLinks.First().Lines.Should().HaveCount(2);
    }

    [Fact]
    public void MarketData_JsonSerialization_PreservesPriceTrend()
    {
        // Arrange
        var marketData = TestDataBuilder.CreateSampleMarketData();
        
        // Act
        var json = JsonSerializer.Serialize(marketData);
        var deserialized = JsonSerializer.Deserialize<MarketData>(json);
        
        // Assert
        deserialized!.Trend.Should().NotBeNull();
        deserialized.Trend.MonthlyGrowthRate.Should().Be(marketData.Trend.MonthlyGrowthRate);
        deserialized.Trend.Direction.Should().Be(marketData.Trend.Direction);
        deserialized.Trend.Confidence.Should().Be(marketData.Trend.Confidence);
        deserialized.Trend.IsIncreasing.Should().BeTrue();
    }

    [Fact]
    public void Entities_JsonSerialization_IgnoresPartitionKey()
    {
        // Arrange
        var property = TestDataBuilder.CreateSampleProperty();
        var marketData = TestDataBuilder.CreateSampleMarketData();
        
        // Act
        var propertyJson = JsonSerializer.Serialize(property);
        var marketDataJson = JsonSerializer.Serialize(marketData);
        
        // Assert - Partition keys should not appear in JSON
        propertyJson.Should().NotContain("partitionKey");
        propertyJson.Should().NotContain("PartitionKey");
        marketDataJson.Should().NotContain("partitionKey");
        marketDataJson.Should().NotContain("PartitionKey");
    }
}
