using FluentAssertions;
using FairRentAdvisor.Core.Models.Entities;
using FairRentAdvisor.Core.Models.ValueObjects;
using FairRentAdvisor.Core.Models;
using FairRentAdvisor.Tests.Unit.TestUtilities;
using System.Text.Json;

namespace FairRentAdvisor.Tests.Unit.Models.Entities;

public class PropertyTests
{
    [Fact]
    public void Constructor_DefaultValues_SetsCorrectDefaults()
    {
        // Act
        var property = new Property();
        
        // Assert
        property.Id.Should().NotBeNullOrEmpty();
        property.IsActive.Should().BeTrue();
        property.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(5));
        property.UpdatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(5));
        property.Features.Should().BeEmpty();
        property.TransportLinks.Should().BeEmpty();
    }

    [Fact]
    public void PartitionKey_ValidPostcode_ReturnsOutwardCode()
    {
        // Arrange
        var property = new Property
        {
            Postcode = new Postcode("SW1A 1AA")
        };
        
        // Act
        var partitionKey = property.PartitionKey;
        
        // Assert
        partitionKey.Should().Be("SW1A");
    }

    [Fact]
    public void SetBasicDetails_ValidInputs_SetsPropertiesCorrectly()
    {
        // Arrange
        var property = new Property();
        var postcode = new Postcode("SW1A 1AA");
        var rent = new MonthlyRent(2500);
        var propertyType = PropertyType.Flat;
        
        // Act
        property.Postcode = postcode;
        property.Bedrooms = 2;
        property.PropertyType = propertyType;
        property.MonthlyRent = rent;
        property.Furnished = true;
        property.HasGarden = false;
        
        // Assert
        property.Postcode.Should().Be(postcode);
        property.Bedrooms.Should().Be(2);
        property.PropertyType.Should().Be(propertyType);
        property.MonthlyRent.Should().Be(rent);
        property.Furnished.Should().BeTrue();
        property.HasGarden.Should().BeFalse();
    }

    [Fact]
    public void AddTransportLink_ValidLink_AddsToCollection()
    {
        // Arrange
        var property = new Property();
        var transportLink = new TransportLink
        {
            StationName = "Victoria",
            StationType = "tube",
            WalkTimeMinutes = 5,
            Lines = new List<string> { "Victoria", "District" },
            Zone = "1"
        };
        
        // Act
        property.TransportLinks.Add(transportLink);
        
        // Assert
        property.TransportLinks.Should().ContainSingle();
        property.TransportLinks.First().StationName.Should().Be("Victoria");
        property.TransportLinks.First().WalkTimeMinutes.Should().Be(5);
    }

    [Fact]
    public void AddFeature_ValidFeature_AddsToFeaturesList()
    {
        // Arrange
        var property = new Property();
        
        // Act
        property.Features.Add("Balcony");
        property.Features.Add("Parking");
        
        // Assert
        property.Features.Should().HaveCount(2);
        property.Features.Should().Contain("Balcony");
        property.Features.Should().Contain("Parking");
    }

    [Fact]
    public void JsonSerialization_CompleteProperty_SerializesAndDeserializesCorrectly()
    {
        // Arrange
        var property = new Property
        {
            Id = "test-id",
            Postcode = new Postcode("SW1A 1AA"),
            Bedrooms = 2,
            PropertyType = PropertyType.Flat,
            MonthlyRent = new MonthlyRent(2500),
            Furnished = true,
            HasGarden = false,
            Description = "Modern 2-bed flat",
            ListingUrl = "https://example.com/listing/123",
            AvailableDate = DateTime.UtcNow.AddDays(30),
            Coordinates = new Coordinates(51.5074, -0.1278),
            IsActive = true,
            Source = "TestSource",
            CreatedAt = DateTime.UtcNow.AddDays(-1),
            UpdatedAt = DateTime.UtcNow
        };
        
        property.Features.AddRange(new[] { "Balcony", "Modern Kitchen" });
        property.TransportLinks.Add(new TransportLink
        {
            StationName = "Victoria",
            StationType = "tube",
            WalkTimeMinutes = 5,
            Lines = new List<string> { "Victoria" },
            Zone = "1"
        });

        // Act
        var json = JsonSerializer.Serialize(property);
        var deserializedProperty = JsonSerializer.Deserialize<Property>(json);

        // Assert
        deserializedProperty.Should().NotBeNull();
        deserializedProperty!.Id.Should().Be(property.Id);
        deserializedProperty.Postcode.Value.Should().Be(property.Postcode.Value);
        deserializedProperty.MonthlyRent.Amount.Should().Be(property.MonthlyRent.Amount);
        deserializedProperty.PropertyType.Value.Should().Be(property.PropertyType.Value);
        deserializedProperty.Features.Should().BeEquivalentTo(property.Features);
        deserializedProperty.TransportLinks.Should().HaveCount(1);
    }

    [Fact]
    public void UpdateTimestamp_WhenCalled_UpdatesUpdatedAtProperty()
    {
        // Arrange
        var property = new Property();
        var originalUpdatedAt = property.UpdatedAt;
        
        // Act
        Thread.Sleep(10); // Ensure time difference
        property.UpdatedAt = DateTime.UtcNow;
        
        // Assert
        property.UpdatedAt.Should().BeAfter(originalUpdatedAt);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(10)]
    public void Bedrooms_ValidValues_AcceptsValue(int bedrooms)
    {
        // Arrange
        var property = new Property();
        
        // Act
        property.Bedrooms = bedrooms;
        
        // Assert
        property.Bedrooms.Should().Be(bedrooms);
    }

    [Fact]
    public void ToString_PropertyWithBasicInfo_ReturnsDescriptiveString()
    {
        // Arrange
        var property = new Property
        {
            Bedrooms = 2,
            PropertyType = PropertyType.Flat,
            Postcode = new Postcode("SW1A 1AA"),
            MonthlyRent = new MonthlyRent(2500)
        };
        
        // Act
        var result = property.ToString();
        
        // Assert
        result.Should().Contain("2");
        result.Should().Contain("flat");
        result.Should().Contain("SW1A 1AA");
    }
}
