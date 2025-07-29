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

        if (!dbContext.Clinics.Any())
            ClinicsSeed.SeedClinics(dbContext);

        if (!dbContext.DonationSymptoms.Any())
            SymptomsSeed.SeedSymptoms(dbContext);

        if (!dbContext.DonationTherapies.Any())
            DonationTherapySeed.SeedDonationTherapies(dbContext);

        if (!dbContext.SuspensionReasons.Any())
            SuspensionReasonSeed.SeedSuspensionReasons(dbContext);

        if (!dbContext.Cities.Any())
            CitySeed.SeedCities(dbContext);

        dbContext.SaveChanges();
    }
}
