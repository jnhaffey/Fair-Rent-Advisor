using System.Text.Json.Serialization;

namespace FairRentAdvisor.Core.Models;

public class TransportLink
{
    [JsonPropertyName("stationName")]
    public string StationName { get; set; } = null!;

    [JsonPropertyName("stationType")]
    public string StationType { get; set; } = null!; // "tube", "bus", "rail"

    [JsonPropertyName("walkTimeMinutes")]
    public int WalkTimeMinutes { get; set; }

    [JsonPropertyName("lines")]
    public List<string> Lines { get; set; } = new();

    [JsonPropertyName("zone")]
    public string? Zone { get; set; }

    public bool IsUndergroundStation => StationType.Equals("tube", StringComparison.OrdinalIgnoreCase);
    
    public bool IsWithinWalkingDistance => WalkTimeMinutes <= 15;
}
