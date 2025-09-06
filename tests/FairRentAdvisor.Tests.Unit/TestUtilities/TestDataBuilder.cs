using FairRentAdvisor.Core.Models.ValueObjects;

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
}
