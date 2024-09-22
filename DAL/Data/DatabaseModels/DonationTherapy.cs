namespace DAL.Data.DatabaseModels;

[Table(nameof(DonationTherapy))]
[PrimaryKey(nameof(ID))]
[Index(nameof(Code))]
public class DonationTherapy : BasicParameters
{
    public List<Donation> Donations { get; set; }
}
