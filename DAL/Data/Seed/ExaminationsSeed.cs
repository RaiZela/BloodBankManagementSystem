using BloodBankManagementSystem.DAL;

namespace DAL.Data.Seed;

public static class ExaminationsSeed
{
    public static void SeedExaminations(ApplicationDbContext dbContext)
    {
        try
        {
            var units = dbContext.UnitsOfMeasurements.ToList();
            var examinations = new List<Examination>()
            {
                new Examination
                {
                    Code = "E1",
                    Description = "Pesha",
                    IsEnabled = true,
                    ReferenceValues = new List<ReferenceValue>()
                    {
                        new ReferenceValue
                        {
                            MinValue=50,
                            MaxValue=150,
                            IsEnabled = true,
                            UnitOfMeasurementID=units.Where(x=>x.Code=="kg").FirstOrDefault()?.ID ?? 1
                        },
                    },
                },
                new Examination
                {
                    Code = "E2",
                    Description = "Pulsi",
                    IsEnabled = true,
                    ReferenceValues = new List<ReferenceValue>()
                    {
                        new ReferenceValue
                        {
                            MinValue=50,
                            MaxValue=100,
                            IsEnabled = true,
                            UnitOfMeasurementID= units.Where(x=>x.Code=="bpm").FirstOrDefault()?.ID ?? 1
                        },
                    },
                },
                new Examination
                {
                    Code = "E3",
                    Description = "Presioni Sistolik",
                    IsEnabled = true,
                    ReferenceValues = new List<ReferenceValue>()
                    {
                        new ReferenceValue
                        {
                            MinValue=110,
                            MaxValue=180,
                             UnitOfMeasurementID=units.Where(x=>x.Code=="mmHg").FirstOrDefault()?.ID ?? 1,
                            IsEnabled = true,
                        },
                    },
                },
                new Examination
                {
                    Code = "E4",
                    Description = "Presioni Diastolik",
                    IsEnabled = true,
                    ReferenceValues = new List<ReferenceValue>()
                    {
                        new ReferenceValue
                        {
                            MinValue=60,
                            MaxValue=100,
                             UnitOfMeasurementID=units.Where(x=>x.Code=="mmHg").FirstOrDefault()?.ID ?? 1,
                            IsEnabled = true,
                        },
                    },
                },
                new Examination
                {
                    Code = "E5",
                    Description = "Temperatura",
                    IsEnabled = true,
                    ReferenceValues = new List<ReferenceValue>()
                    {
                        new ReferenceValue
                        {
                            MinValue=36,
                            MaxValue=37,
                              UnitOfMeasurementID=units.Where(x=>x.Code=="C").FirstOrDefault()?.ID ?? 1,
                            IsEnabled = true,
                        },
                    },
                }, new Examination
                {
                    Code = "E6",
                    Description = "Hemoglobina",
                    IsEnabled = true,
                    ReferenceValues = new List<ReferenceValue>()
                    {
                        new ReferenceValue
                        {
                            MinValue=13.5,
                            MaxValue=17,
                            UnitOfMeasurementID=units.Where(x=>x.Code=="g/dl").FirstOrDefault()?.ID ?? 1,
                            IsEnabled = true,
                        },
                    },
                }, new Examination
                {
                    Code = "E7",
                    Description = "Gjatesia",
                    IsEnabled = true,
                    ReferenceValues = new List<ReferenceValue>()
                    {
                        new ReferenceValue
                        {
                            IsEnabled = true,
                            UnitOfMeasurementID=units.Where(x=>x.Code=="cm").FirstOrDefault()?.ID ?? 1
                        },
                    },
                },
            };
            dbContext.AddRange(examinations);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
