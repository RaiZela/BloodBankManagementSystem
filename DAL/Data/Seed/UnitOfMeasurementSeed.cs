using BloodBankManagementSystem.DAL;

namespace DAL.Data.Seed;

public static class UnitOfMeasurementSeed
{
    public static void Seed(ApplicationDbContext dbcontext)
    {
        try
        {

            var unitOfMeasurements = new List<UnitOfMeasurement>()
                {
                    new UnitOfMeasurement
                    {
                        Code = "kg",
                        Description = "Kilogram",
                        IsEnabled = true,
                    },
                    new UnitOfMeasurement
                    {
                        Code = "bpm",
                        Description = "BPM",
                        IsEnabled = true,
                    },
                    new UnitOfMeasurement
                    {
                        Code = "mmHg",
                        Description = "mmHg",
                        IsEnabled = true,
                    },
                new UnitOfMeasurement
                    {
                        Code = "C",
                        Description = "Celsius",
                        IsEnabled = true,
                    },
                new UnitOfMeasurement
                    {
                        Code = "g/dl",
                        Description = "g/dl",
                        IsEnabled = true,
                    },
                new UnitOfMeasurement
                    {
                        Code = "cm",
                        Description = "Centimeter",
                        IsEnabled = true,
                    },
                };
            dbcontext.UnitsOfMeasurements.AddRange(unitOfMeasurements);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
