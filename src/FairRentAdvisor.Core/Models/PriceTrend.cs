using System.Text.Json.Serialization;

namespace FairRentAdvisor.Core.Models;

public class PriceTrend
{
    [JsonPropertyName("monthlyGrowthRate")]
    public decimal MonthlyGrowthRate { get; set; }

    [JsonPropertyName("direction")]
    public string Direction { get; set; } = "stable";

    [JsonPropertyName("confidence")]
    public int Confidence { get; set; }

    public bool IsIncreasing => Direction.Equals("increasing", StringComparison.OrdinalIgnoreCase);
    public bool IsDecreasing => Direction.Equals("decreasing", StringComparison.OrdinalIgnoreCase);
    public bool IsStable => Direction.Equals("stable", StringComparison.OrdinalIgnoreCase);
}
