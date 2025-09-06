using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace FairRentAdvisor.Core.Models.ValueObjects;

public record Postcode
{
    private static readonly Regex UkPostcodeRegex = new(
        @"^[A-Z]{1,2}[0-9R][0-9A-Z]?\s?[0-9][A-Z]{2}$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public string Value { get; init; }

    [JsonConstructor]
    public Postcode(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Postcode cannot be empty", nameof(value));

        var normalizedValue = value.Trim().ToUpperInvariant().Replace(" ", "");
        
        if (!UkPostcodeRegex.IsMatch(normalizedValue))
            throw new ArgumentException($"Invalid UK postcode format: {value}", nameof(value));

        // Format with space: SW1A1AA -> SW1A 1AA
        if (normalizedValue.Length >= 6)
        {
            Value = normalizedValue.Insert(normalizedValue.Length - 3, " ");
        }
        else
        {
            Value = normalizedValue;
        }
    }

    public string OutwardCode => Value.Split(' ')[0];
    public string InwardCode => Value.Split(' ')[1];
    
    public static implicit operator string(Postcode postcode) => postcode.Value;
    public static implicit operator Postcode(string value) => new(value);
}
