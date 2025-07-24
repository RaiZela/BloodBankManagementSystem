using BloodBankManagementSystem.DAL;

namespace DAL.Data.Seed;

public static class SymptomsSeed
{
    public static void SeedSymptoms(ApplicationDbContext dbcontext)
    {
        var symptoms = new List<DonationSymptom>
        {
                new DonationSymptom
                {
                    Code="01",
                    Description="Parestesi/Mpirje nga citrati"
                },
                new DonationSymptom
                {
                    Code="02",
                    Description="Tromboflebit"
                },
                new DonationSymptom
                {
                    Code="03",
                    Description="Dëmtim i një nervi"
                },
                new DonationSymptom
                {
                    Code="04",
                    Description="Reaksion alergjik lokal"
                },
                new DonationSymptom
                {
                    Code="05",
                    Description="Reaksion vagal i vonuar"
                },
                new DonationSymptom
                {
                    Code="06",
                    Description="Takikardi (rrahje të shpejta të zemrës)"
                },
                new DonationSymptom
                {
                    Code="07",
                    Description="Inkontinencë"
                },
                new DonationSymptom
                {
                    Code="08",
                    Description="Konvulsione"
                },
                new DonationSymptom
                {
                    Code="09",
                    Description="Të vjella"
                },
                new DonationSymptom
                {
                    Code="10",
                    Description="Humbje e vetëdijes"
                },
                new DonationSymptom
                {
                    Code="11",
                    Description="Dhimbje në kraharorin e sipërm (parazemëror)"
                },
                new DonationSymptom
                {
                    Code="12",
                    Description="Reaksion vagal i menjëhershëm"
                },
                new DonationSymptom
                {
                    Code="13",
                    Description="Hematomë"
                },
                new DonationSymptom
                {
                    Code="14",
                    Description="Shpim i arteries\r\n\r\n"
                },

        };

        dbcontext.AddRange(symptoms);
    }
}
