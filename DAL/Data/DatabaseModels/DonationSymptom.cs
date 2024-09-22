namespace DAL.Data.DatabaseModels;

[Table(nameof(DonationSymptom))]
[PrimaryKey(nameof(ID))]
[Index(nameof(Code))]
public class DonationSymptom : BasicParameters
{
    public virtual List<Donation> Donations { get; set; }
}
