namespace DAL.Data.DatabaseModels;

[Table(nameof(Clinic))]
[PrimaryKey(nameof(ID))]
[Index(nameof(Code))]
public class Clinic : BasicParameters
{
}
