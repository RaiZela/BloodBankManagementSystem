using BloodBankManagementSystem.DAL;

namespace DAL.Data.Seed;

public static class ClinicsSeed
{
    public static void SeedClinics(ApplicationDbContext dbContext)
    {
        try
        {
            var clinics = new List<Clinic>()
            {
                new Clinic
                {
                    Code="DRM",
                    Description="Dermatologji",
                    IsEnabled=true
                },
               new Clinic
                {
                    Code="END",
                    Description="Endokrinologji",
                    IsEnabled=true
                },
                new Clinic
                {
                    Code="GH",
                    Description="Gastro Hepatologji",
                    IsEnabled=true
                },
                new Clinic
                {
                    Code="HM",
                    Description="Hematologji",
                    IsEnabled=true
                },
                new Clinic
                {
                    Code="HD",
                    Description="HemoDializa",
                    IsEnabled=true
                },
                new Clinic
                {
                    Code="INF",
                    Description="Infektiv",
                    IsEnabled=true
                },
                new Clinic
                {
                    Code="KRD",
                    Description="Kardiologji",
                    IsEnabled=true
                },
                new Clinic
                {
                    Code="KJD_PLT",
                    Description="Kujdesi paliativ",
                    IsEnabled=true
                },
                 new Clinic
                {
                    Code="KRGJ",
                    Description="Kirurgji",
                    IsEnabled=true
                },
                new Clinic
                {
                    Code="NAGJ",
                    Description="Neonatologji",
                    IsEnabled=true
                },
                new Clinic
                {
                    Code="ORT_TRM",
                    Description="Ortopedi Traumatologji",
                    IsEnabled=true
                },
                new Clinic
                {
                    Code="OBS_GJIN",
                    Description="Obsetri Gjinekologji",
                    IsEnabled=true
                },
                new Clinic
                {
                    Code="NEURO",
                    Description="Neurologji",
                    IsEnabled=true
                },
                new Clinic
                {
                    Code="OKUL",
                    Description="Okulistike",
                    IsEnabled=true
                },
                new Clinic
                {
                    Code="ONKGJ",
                    Description="Onkologji",
                    IsEnabled=true
                },
                new Clinic
                {
                    Code="ORL",
                    Description="ORL",
                    IsEnabled=true
                },
                new Clinic
                {
                    Code="PATH",
                    Description="Pathologji",
                    IsEnabled=true
                },
                new Clinic
                {
                    Code="TJT",
                    Description="Tjeter",
                    IsEnabled=true
                },
                new Clinic
                {
                    Code="PED",
                    Description="Pediatri",
                    IsEnabled=true
                },
                new Clinic
                {
                    Code="PNUMZTR",
                    Description="Pneumoftiziatri",
                    IsEnabled=true
                },
                new Clinic
                {
                    Code="PSYCH",
                    Description="Psikiatri",
                    IsEnabled=true
                },
                new Clinic
                {
                    Code="Talasem",
                    Description="Qendra e Talasemise",
                    IsEnabled=true
                },
                new Clinic
                {
                    Code="REANIM",
                    Description="Reanimacion",
                    IsEnabled=true
                },
                new Clinic
                {
                    Code="REUMAT",
                    Description="Reumatologji",
                    IsEnabled=true
                },
                new Clinic
                {
                    Code="URGJ",
                    Description="Urgjenca",
                    IsEnabled=true
                },
                new Clinic
                {
                    Code="KL 1A/1 3B",
                    Description="Klinika 1 A/1 3B Pneumologji",
                    IsEnabled=true
                },
                new Clinic
                {
                    Code="KL 2 B/1 4A",
                    Description="Klinika 2 B/1 4A Pneumologji",
                    IsEnabled=true
                },
                new Clinic
                {
                    Code="KL 1 B/2 1B",
                    Description="Klinika 1 B/2 1B Pneumologji",
                    IsEnabled=true
                },
                new Clinic
                {
                    Code="1",
                    Description="Mjekesi interne (Sanatorium)",
                    IsEnabled=true
                },
                new Clinic
                {
                    Code="2",
                    Description="Kirurgji Abdominale (Sanatorium)",
                    IsEnabled=true
                },
                new Clinic
                {
                    Code="3",
                    Description="Kirurgji Torakale (Sanatorium)",
                    IsEnabled=true
                },
                new Clinic
                {
                    Code="4",
                    Description="Reanimacioni i Kardiokirurgjise (Sanatorium)",
                    IsEnabled=true
                },
                new Clinic
                {
                    Code="5",
                    Description="Urgjenca (Sanatorium)",
                    IsEnabled=true
                },
                new Clinic
                {
                    Code="NEURO_KRGJ",
                    Description="Neurokirurgji",
                    IsEnabled=true
                },
                new Clinic
                {
                    Code="KRGJ_PLAST",
                    Description="Kirurgji Plastike",
                    IsEnabled=true
                },
                new Clinic
                {
                    Code="KRGJ 1",
                    Description="Kirurgji 1",
                    IsEnabled=true
                },
                new Clinic
                {
                    Code="KRGJ 2",
                    Description="Kirurgji 2",
                    IsEnabled=true
                },
                new Clinic
                {
                    Code="KRGJ 3",
                    Description="Kirurgji 3",
                    IsEnabled=true
                },

                new Clinic
                {
                    Code="REANIM_KRGJ",
                    Description="Reanimacioni i Kardiokirurgjise",
                    IsEnabled=true
                },
                new Clinic
                {
                    Code="KARDIO_KRGJ",
                    Description="Kardiokirurgji",
                    IsEnabled=true
                },
               new Clinic
                {
                    Code="ONKO_KIMIO",
                    Description="Onkologji-kimioterapi",
                    IsEnabled=true
                },
                new Clinic
                {
                    Code="ONKO_RADIO",
                    Description="Onkologji-Radioterapi",
                    IsEnabled=true
                },
                new Clinic
                {
                    Code="NEFRO",
                    Description="Nefrologji",
                    IsEnabled=true
                },
                new Clinic
                {
                    Code="INTERN",
                    Description="Mjekesi Interne",
                    IsEnabled=true
                },
                new Clinic
                {
                    Code="DJG_PLAST",
                    Description="Djegie-Plastike",
                    IsEnabled=true
                },
                new Clinic
                {
                    Code="REANIM_QEND",
                    Description="Reanimacioni Qendror",
                    IsEnabled=true
                },
                new Clinic
                {
                    Code="REANIM_KRGJ",
                    Description="Reanimacioni i Kirurgjise",
                    IsEnabled=true
                },
                new Clinic
                {
                    Code="REANIM_PED",
                    Description="Reanimacioni i Pediatrise",
                    IsEnabled=true
                },
                new Clinic
                {
                    Code="KRGJ_INFANT",
                    Description="Kirurgji Infantile",
                    IsEnabled=true
                },
                new Clinic
                {
                    Code="PED_INFEKT",
                    Description="Pediatria Infektive",
                    IsEnabled=true
                },
                new Clinic
                {
                    Code="URG_PED",
                    Description="Urgjenca e pediatrise",
                    IsEnabled=true
                },
                new Clinic
                {
                    Code="TKSGJ",
                    Description="Toksikologji",
                    IsEnabled=true
                },
                new Clinic
                {
                    Code="KRGJ_VAZAL",
                    Description="Kirurgji Vazale",
                    IsEnabled=true
                },
                new Clinic
                {
                    Code="URO",
                    Description="Urologji",
                    IsEnabled=true
                },
                new Clinic
                {
                    Code="HEMAT_PED",
                    Description="Hematologji pediatrike",
                    IsEnabled=true
                },
                new Clinic
                {
                    Code="SPT_BURG",
                    Description="Spitali i burgut",
                    IsEnabled=true
                }
            };

            dbContext.AddRange(clinics);

        }

        catch (Exception ex)
        {
            throw;
        }
    }
}
