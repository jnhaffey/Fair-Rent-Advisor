using System.Text.Json.Serialization;

namespace FairRentAdvisor.Core.Models.ValueObjects;

public record PropertyType
{
    public static readonly PropertyType Flat = new("flat");
    public static readonly PropertyType House = new("house");
    public static readonly PropertyType Studio = new("studio");
    public static readonly PropertyType Room = new("room");

    public string Value { get; init; }

    [JsonConstructor]
    private PropertyType(string value)
    {
        Value = value;
    }

    public static PropertyType FromString(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Property type cannot be empty", nameof(value));

        return value.ToLowerInvariant() switch
        {
            "flat" or "apartment" => Flat,
            "house" or "terraced" or "detached" or "semi-detached" => House,
            "studio" => Studio,
            "room" or "shared" => Room,
            _ => throw new ArgumentException($"Unknown property type: {value}")
        };
    }

    public static implicit operator string(PropertyType propertyType) => propertyType.Value;
}
