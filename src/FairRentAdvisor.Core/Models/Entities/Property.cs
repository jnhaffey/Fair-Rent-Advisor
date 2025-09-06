using System.Text.Json.Serialization;
using FairRentAdvisor.Core.Models.ValueObjects;
using FairRentAdvisor.Core.Models;

namespace FairRentAdvisor.Core.Models.Entities;

public class Property
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [JsonPropertyName("postcode")]
    public Postcode Postcode { get; set; } = null!;

    [JsonPropertyName("bedrooms")]
    public int Bedrooms { get; set; }

    [JsonPropertyName("propertyType")]
    public PropertyType PropertyType { get; set; } = null!;

    [JsonPropertyName("monthlyRent")]
    public MonthlyRent MonthlyRent { get; set; } = null!;

    [JsonPropertyName("furnished")]
    public bool Furnished { get; set; }

    [JsonPropertyName("hasGarden")]
    public bool HasGarden { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("listingUrl")]
    public string? ListingUrl { get; set; }

    [JsonPropertyName("availableDate")]
    public DateTime? AvailableDate { get; set; }

    [JsonPropertyName("coordinates")]
    public Coordinates? Coordinates { get; set; }

    [JsonPropertyName("transportLinks")]
    public List<TransportLink> TransportLinks { get; set; } = new();

    [JsonPropertyName("features")]
    public List<string> Features { get; set; } = new();

    [JsonPropertyName("isActive")]
    public bool IsActive { get; set; } = true;

    [JsonPropertyName("source")]
    public string? Source { get; set; }

    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [JsonPropertyName("updatedAt")]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Cosmos DB partition key
    [JsonIgnore]
    public string PartitionKey => Postcode?.OutwardCode ?? string.Empty;

    // Business logic methods
    public bool IsAvailableNow() => AvailableDate == null || AvailableDate <= DateTime.UtcNow;

    public bool IsAvailableWithin(TimeSpan timespan) => 
        AvailableDate == null || AvailableDate <= DateTime.UtcNow.Add(timespan);

    public bool HasNearbyTransport() => TransportLinks.Any(tl => tl.WalkTimeMinutes <= 10);

    public IEnumerable<TransportLink> GetUndergroundStations() => 
        TransportLinks.Where(tl => tl.IsUndergroundStation);

    public void MarkAsInactive()
    {
        IsActive = false;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateDetails(MonthlyRent newRent, bool furnished, bool hasGarden)
    {
        MonthlyRent = newRent;
        Furnished = furnished;
        HasGarden = hasGarden;
        UpdatedAt = DateTime.UtcNow;
    }

    public override string ToString()
    {
        return $"{Bedrooms} bed {PropertyType?.Value} in {Postcode?.Value} - £{MonthlyRent?.Amount:N0}/month";
    }
}
