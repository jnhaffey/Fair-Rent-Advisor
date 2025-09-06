using System.Text.Json.Serialization;
using FairRentAdvisor.Core.Models.ValueObjects;
using FairRentAdvisor.Core.Models;

namespace FairRentAdvisor.Core.Models.Entities;

public class MarketData
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [JsonPropertyName("postcode")]
    public string Postcode { get; set; } = null!;

    [JsonPropertyName("propertyType")]
    public PropertyType PropertyType { get; set; } = null!;

    [JsonPropertyName("bedrooms")]
    public int Bedrooms { get; set; }

    [JsonPropertyName("averageRent")]
    public decimal AverageRent { get; set; }

    [JsonPropertyName("medianRent")]
    public decimal MedianRent { get; set; }

    [JsonPropertyName("minRent")]
    public decimal MinRent { get; set; }

    [JsonPropertyName("maxRent")]
    public decimal MaxRent { get; set; }

    [JsonPropertyName("sampleSize")]
    public int SampleSize { get; set; }

    [JsonPropertyName("pricePerSqFt")]
    public decimal? PricePerSqFt { get; set; }

    [JsonPropertyName("trend")]
    public PriceTrend Trend { get; set; } = new();

    [JsonPropertyName("analysisDate")]
    public DateTime AnalysisDate { get; set; } = DateTime.UtcNow;

    [JsonPropertyName("lastUpdated")]
    public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

    // Cosmos DB partition key
    [JsonIgnore]
    public string PartitionKey => Postcode;

    public bool IsDataFresh(TimeSpan maxAge) => DateTime.UtcNow - LastUpdated < maxAge;

    public decimal CalculatePriceRange() => MaxRent - MinRent;

    public decimal CalculateVarianceCoefficient() => 
        MedianRent > 0 ? CalculatePriceRange() / MedianRent : 0;

    // Additional business logic methods
    public bool IsValidSample() => SampleSize >= 3 && MinRent > 0 && MaxRent > MinRent;

    public int GetConfidenceScore() => SampleSize switch
    {
        >= 20 => 90,
        >= 10 => 75,
        >= 5 => 60,
        >= 3 => 45,
        _ => 30
    };

    public void UpdateStatistics(IEnumerable<decimal> rents)
    {
        var rentList = rents.ToList();
        if (!rentList.Any()) return;

        AverageRent = rentList.Average();
        MedianRent = CalculateMedian(rentList);
        MinRent = rentList.Min();
        MaxRent = rentList.Max();
        SampleSize = rentList.Count;
        LastUpdated = DateTime.UtcNow;
    }

    private static decimal CalculateMedian(List<decimal> values)
    {
        var sorted = values.OrderBy(x => x).ToList();
        var count = sorted.Count;
        
        if (count % 2 == 0)
            return (sorted[count / 2 - 1] + sorted[count / 2]) / 2;
        else
            return sorted[count / 2];
    }

    public override string ToString()
    {
        return $"Market data for {Bedrooms} bed {PropertyType?.Value} in {Postcode}: £{MedianRent:N0} median (n={SampleSize})";
    }
}
