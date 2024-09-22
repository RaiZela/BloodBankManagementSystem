namespace DAL.Data.DatabaseModels;

[Table(nameof(BagType))]
[PrimaryKey(nameof(ID))]

public class BagType : AuditableEntity
{
    public string Name { get; set; }
}
