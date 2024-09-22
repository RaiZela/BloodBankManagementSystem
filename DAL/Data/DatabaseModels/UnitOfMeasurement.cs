namespace DAL.Data.DatabaseModels;

[Table(nameof(UnitOfMeasurement))]
[PrimaryKey(nameof(ID))]
[Index(nameof(Code))]
public class UnitOfMeasurement : BasicParameters
{
}
