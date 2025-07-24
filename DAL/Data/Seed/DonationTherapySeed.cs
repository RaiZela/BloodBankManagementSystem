using BloodBankManagementSystem.DAL;

namespace DAL.Data.Seed;

public static class DonationTherapySeed
{
    public static void SeedDonationTherapies(ApplicationDbContext dbContext)
    {
        var donationTherapies = new List<DonationTherapy>
        {
            new DonationTherapy
            {
                Code = "01",
                Description = "Kortizonik"
            },
            new DonationTherapy
            {
                Code = "02",
                Description = "Antiinflamator"
            },
            new DonationTherapy
            {
                Code = "03",
                Description = "Antihistaminik"
            },
            new DonationTherapy
            {
                Code = "04",
                Description = "Adrenalinë"
            },
            new DonationTherapy
            {
                Code = "05",
                Description = "Zgjidhje saline"
            },
            new DonationTherapy
            {
                Code = "06",
                Description = "Zgjidhje glukoze"
            },
            new DonationTherapy
            {
                Code = "07",
                Description = "Kortizonik + Antihistaminik"
            },
            new DonationTherapy
            {
                Code = "08",
                Description = "Diuretikë"
            },
            new DonationTherapy
            {
                Code = "09",
                Description = "Beta2-agonistë"
            },
             new DonationTherapy
            {
                Code = "10",
                Description = "Pa terapi"
            },
            new DonationTherapy
            {
                Code = "11",
                Description = "Tjeter"
            },

        };
        dbContext.DonationTherapies.AddRange(donationTherapies);
    }
}
