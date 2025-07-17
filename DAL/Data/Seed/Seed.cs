using BloodBankManagementSystem.DAL;

namespace DAL.Data.Seed;

public static class Seed
{
    public static void SeedData(ApplicationDbContext dbContext)
    {
        if (!dbContext.Questions.Any())
            QuestionsSeed.SeedQuestions(dbContext);

        if (!dbContext.UnitsOfMeasurements.Any())
            UnitOfMeasurementSeed.Seed(dbContext);

        if (!dbContext.Examinations.Any())
            ExaminationsSeed.SeedExaminations(dbContext);
    }
}
