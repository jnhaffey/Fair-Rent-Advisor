using FairRentAdvisor.Core.Models.ValueObjects;
using FairRentAdvisor.Core.Models.Entities;
using FairRentAdvisor.Core.Models;

namespace FairRentAdvisor.Tests.Unit.TestUtilities;

public static class TestDataBuilder
{
    public static class Postcodes
    {
        public static readonly Postcode London = new("SW1A 1AA");
        public static readonly Postcode Manchester = new("M1 1AA");
        public static readonly Postcode Birmingham = new("B1 1AA");
        public static readonly Postcode Edinburgh = new("EH1 1AA");
        public static readonly Postcode Cardiff = new("CF1 1AA");
    }

    public static class Rents
    {
        public static readonly MonthlyRent Low = new(800);
        public static readonly MonthlyRent Medium = new(1500);
        public static readonly MonthlyRent High = new(3000);
        public static readonly MonthlyRent VeryHigh = new(5000);
    }

    public static class PropertyTypes
    {
        public static readonly PropertyType Flat = PropertyType.Flat;
        public static readonly PropertyType House = PropertyType.House;
        public static readonly PropertyType Studio = PropertyType.Studio;
        public static readonly PropertyType Room = PropertyType.Room;
    }

    public static Property CreateSampleProperty()
    {
        return new Property
        {
            Id = "sample-property-1",
            Postcode = Postcodes.London,
            Bedrooms = 2,
            PropertyType = PropertyTypes.Flat,
            MonthlyRent = Rents.High,
            Furnished = true,
            HasGarden = false,
            Description = "Modern 2-bedroom flat in Central London",
            ListingUrl = "https://example.com/listing/sample",
            AvailableDate = DateTime.UtcNow.AddDays(14),
            Coordinates = new Coordinates(51.5074, -0.1278),
            IsActive = true,
            Source = "TestDataBuilder",
            CreatedAt = DateTime.UtcNow.AddDays(-7),
            UpdatedAt = DateTime.UtcNow.AddDays(-1)
        };
    }

    public static MarketData CreateSampleMarketData()
    {
        return new MarketData
        {
            Id = "sample-market-data-1",
            Postcode = "SW1A 1AA",
            PropertyType = PropertyTypes.Flat,
            Bedrooms = 2,
            AverageRent = 2800,
            MedianRent = 2750,
            MinRent = 2200,
            MaxRent = 3500,
            SampleSize = 15,
            PricePerSqFt = 45.50m,
            Trend = new PriceTrend
            {
                MonthlyGrowthRate = 0.025m,
                Direction = "increasing",
                Confidence = 78
            },
            AnalysisDate = DateTime.UtcNow.AddDays(-2),
            LastUpdated = DateTime.UtcNow.AddHours(-6)
        };
    }
}
