using BloodBankManagementSystem.DAL;

namespace DAL.Data.Seed;

public static class QuestionsSeed
{
    public static void SeedQuestions(ApplicationDbContext dbContext)
    {
        try
        {
            var questions = new List<Question>()
        {
            new Question
            {
                Text = "A ndiheni mirë me shëndet?",
                Type = QuestionType.Check,
                Category = QuestionCategory.One,
            },
            new Question
            {
                Text = "Keni patur infeksione (përfshirë dhe ftohje) ndryshime në lëkurë, plagë apo gjëndra të fryra të dukshme?",
                Type = QuestionType.Check,
                Category = QuestionCategory.Two,
            },
            new Question
            {
                Text = "A keni kryer trajtim tek dentisti?",
                Type = QuestionType.Check,
                Category = QuestionCategory.Two,
            },
            new Question
            {
                Text = "Jeni trajtuar me medikamente?",
                Type = QuestionType.Check,
                Category = QuestionCategory.Three,
            },
            new Question
            {
                Text = "",
                Type = QuestionType.Check,
                Category = QuestionCategory.Three,
            },     new Question
            {
                Text = "Cilat medikamente?",
                Type = QuestionType.Text,
                Category = QuestionCategory.Three,
            },
            new Question
            {
                Text = "Keni bërë trajtime mjekësore për ndonjë sëmundje? A vazhdoni ta keni këtë sëmundje?",
                Type = QuestionType.Check,
                Category = QuestionCategory.Three,
            },
            new Question
            {
                Text = "Keni patur temperaturë apo sëmundje infektive (duke përjashtuar të ftohtin)?\r\n",
                Type = QuestionType.Check,
                Category = QuestionCategory.Four,
            },
                new Question
            {
                Text = "Keni bërë ndonjë vaksinë?",
                Type = QuestionType.Check,
                Category = QuestionCategory.Four,
            },
            new Question
            {
                Text = "Cilën vaksinë?",
                Type = QuestionType.Text,
                Category = QuestionCategory.Four,
            },
            new Question
            {
                Text = "Keni patur diarre?",
                Type = QuestionType.Check,
                Category = QuestionCategory.Four,
            },
            new Question
            {
                Text = "Keni kryer ndonjë operacion, endoskopi apo keni patur ndonjë shtatzani?",
                Type = QuestionType.Check,
                Category = QuestionCategory.Five,
            },
            new Question
            {
                Text = "Jeni trajtuar me gjak, plazmë ose produkte të tjera të gjakut?",
                Type = QuestionType.Check,
                Category = QuestionCategory.Five,
            },     new Question
            {
                Text = "Keni kryer akupunturë, tatuazhe, piercing, apo shpime të veshëve?",
                Type = QuestionType.Check,
                Category = QuestionCategory.Five,
            },
            new Question
            {
                Text = "A keni bërë ndonjë imunizim pasiv?",
                Type = QuestionType.Check,
                Category = QuestionCategory.Six,
            },
            new Question
            {
                Text = "Çfarë imunizimi?",
                Type = QuestionType.Text,
                Category = QuestionCategory.Six,
            },
            new Question
            {
                Text = "A keni qëndruar në zona me rrezik ndaj Malaries?",
                Type = QuestionType.Check,
                Category = QuestionCategory.Six,
            },
            new Question
            {
                Text = "A keni pasur probleme ose ethe gjatë/pas qëndrimit tuaj atje?",
                Type = QuestionType.Text,
                Category = QuestionCategory.Six,
            },
            new Question
            {
                Text = "A keni patur kontakte intime me persona me risk të lartë ndaj Hepatit ose HIV-it? (shiko fletën informative për SIDA-n)",
                Type = QuestionType.Check,
                Category = QuestionCategory.Six,
            },
            new Question
            {
                Text = "A jeni shpuar me materiale të infektuara?",
                Type = QuestionType.Check,
                Category = QuestionCategory.Six,
            },
            new Question
            {
                Text = "A keni marrë barna të tipit Roaccutan, Neotigason, Propecia për sëmundje të lëkurës apo rënie flokësh?",
                Type = QuestionType.Check,
                Category = QuestionCategory.Six,
            },
            new Question
            {
                Text = "A keni patur varësi nga alkooli apo medikamente? Keni marrë gjatë kësaj periudhe droga të ndryshme (hashash etj)?",
                Type = QuestionType.Check,
                Category = QuestionCategory.Six,
            },
            new Question
            {
                Text = "A keni patur sëmundje të zemrës, diabetit, sëmundje të gjakut, apo turbekulozit?",
                Type = QuestionType.Check,
                Category = QuestionCategory.Seven,
            },
            new Question
            {
                Text = "A keni patur tumore malinje apo Osteomielite?\r\n",
                Type = QuestionType.Check,
                Category = QuestionCategory.Eight
            },
             new Question
            {
                Text = "A keni patur sëmundje shumë të rënda (të cilat nuk janë shënuara këtu)?",
                Type = QuestionType.Check,
                Category = QuestionCategory.Eight
            },
             new Question
            {
                Text = "Nëse po, cilat sëmundje?",
                Type = QuestionType.Text,
                Category = QuestionCategory.Eight
            },
             new Question
            {
                Text = "A keni patur Malarie, Sifiliz apo sëmundje shumë të rralla si Babesioza, Bruceloza, Lepra, Tularemia?",
                Type = QuestionType.Check,
                Category = QuestionCategory.Eight
            },
             new Question
            {
                Text = "A keni kryer transplant të dura mater, cornese apo ndonjë lloj tjetër?",
                Type = QuestionType.Check,
                Category = QuestionCategory.Eight
            },
             new Question
            {
                Text = "A jeni trajtuar me hormone të hypofizës apo hormone të tjera?",
                Type = QuestionType.Check,
                Category = QuestionCategory.Eight
            },
             new Question
            {
                Text = "Keni patur histori familjare të sëmundjes Creutzfeldt Jakob?",
                Type = QuestionType.Check,
                Category = QuestionCategory.Eight
            },
             new Question
            {
                Text = "A keni patur infeksion HIV (SIDA) ose Hepatit?",
                Type = QuestionType.Check,
                Category = QuestionCategory.Eight
            },
             new Question
            {
                Text = "Jeni i sigurtë që nuk bëni pjesë në personat me risk për infeksion HIV (shiko informacionin për SIDA-n)",
                Type = QuestionType.Check,
                Category = QuestionCategory.Eight
            },

        };
            dbContext.AddRange(questions);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
