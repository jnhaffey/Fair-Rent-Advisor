using System.Text.Json.Serialization;

namespace FairRentAdvisor.Core.Models;

public class Coordinates
{
    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }

    public Coordinates() { }

    public Coordinates(double latitude, double longitude)
    {
        if (latitude < -90 || latitude > 90)
            throw new ArgumentException("Invalid latitude", nameof(latitude));
        
        if (longitude < -180 || longitude > 180)
            throw new ArgumentException("Invalid longitude", nameof(longitude));

        Latitude = latitude;
        Longitude = longitude;
    }

    public double DistanceTo(Coordinates other)
    {
        // Simplified distance calculation (Haversine formula would be used in production)
        var latDiff = Math.Abs(Latitude - other.Latitude);
        var lonDiff = Math.Abs(Longitude - other.Longitude);
        return Math.Sqrt(latDiff * latDiff + lonDiff * lonDiff) * 111; // Rough km conversion
    }
}
