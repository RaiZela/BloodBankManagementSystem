namespace DAL.Data.DatabaseModels;

[Table(nameof(Reaction))]
[PrimaryKey(nameof(ID))]
[Index(nameof(Code))]
public class Reaction : BasicParameters
{
    public virtual List<Donation> Donations { get; set; }
}
