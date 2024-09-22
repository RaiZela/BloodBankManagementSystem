namespace DAL.Data.DatabaseModels;

[Table(nameof(BagManufacturer))]
[PrimaryKey(nameof(ID))]

public class BagManufacturer : AuditableEntity
{
    public string Name { get; set; }
}
