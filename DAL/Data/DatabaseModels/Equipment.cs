namespace DAL.Data.DatabaseModels;

[Table(nameof(Equipment))]
[PrimaryKey(nameof(ID))]
[Index(nameof(Code))]
public class Equipment : BasicParameters
{
}
