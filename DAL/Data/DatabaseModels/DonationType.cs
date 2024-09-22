namespace DAL.Data.DatabaseModels;

[Table(nameof(DonationType))]
[PrimaryKey(nameof(ID))]
[Index(nameof(Code))]
public class DonationType : BasicParameters
{
    public virtual List<Donation> Donations { get; set; }
}
