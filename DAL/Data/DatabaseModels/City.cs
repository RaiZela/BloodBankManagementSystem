namespace DAL.Data.DatabaseModels;

[Table(nameof(City))]
[PrimaryKey(nameof(ID))]
[Index(nameof(Code))]
public class City : BasicParameters
{
    public virtual List<Donor> Donors { get; set; }
}
