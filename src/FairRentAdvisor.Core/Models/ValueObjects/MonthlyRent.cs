using System.Text.Json.Serialization;

namespace FairRentAdvisor.Core.Models.ValueObjects;

public record MonthlyRent
{
    public decimal Amount { get; init; }
    public string Currency { get; init; } = "GBP";

    [JsonConstructor]
    public MonthlyRent(decimal amount, string currency = "GBP")
    {
        if (amount < 0)
            throw new ArgumentException("Rent amount cannot be negative", nameof(amount));
        
        if (amount > 50000)
            throw new ArgumentException("Rent amount seems unrealistic", nameof(amount));

        Amount = amount;
        Currency = currency;
    }

    public static implicit operator decimal(MonthlyRent rent) => rent.Amount;
    public static implicit operator MonthlyRent(decimal amount) => new(amount);
}
