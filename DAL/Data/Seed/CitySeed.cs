using BloodBankManagementSystem.DAL;

namespace DAL.Data.Seed;

public static class CitySeed
{
    public static void SeedCities(ApplicationDbContext dbContext)
    {
        var cities = new List<City>
{
    new City
    {
        Code = "TIR",
        Description = "Tirana"
    },
    new City
    {
        Code = "DUR",
        Description = "Durrës"
    },
    new City
    {
        Code = "SHK",
        Description = "Shkodër"
    },
    new City
    {
        Code = "ELB",
        Description = "Elbasan"
    },
    new City
    {
        Code = "VL",
        Description = "Vlorë"
    },
    new City
    {
        Code = "GJI",
        Description = "Gjirokastër"
    },
    new City
    {
        Code = "KOR",
        Description = "Korçë"
    },
    new City
    {
        Code = "BER",
        Description = "Berat"
    },
    new City
    {
        Code = "KUK",
        Description = "Kukës"
    },
    new City
    {
        Code = "LEZ",
        Description = "Lezhë"
    },
};


        dbContext.Cities.AddRange(cities);
    }
}
