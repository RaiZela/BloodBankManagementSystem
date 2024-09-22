namespace DAL.Data.DatabaseModels;

[Table(nameof(Problem))]
[PrimaryKey(nameof(ID))]
[Index(nameof(Code))]
public class Problem : BasicParameters
{
    public virtual List<Donation> Donations { get; set; }
}
