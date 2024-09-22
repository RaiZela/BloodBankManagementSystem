namespace DAL.Data.DatabaseModels;

[Table(nameof(StorageSystem))]
[PrimaryKey(nameof(ID))]

public class StorageSystem : AuditableEntity
{
    public string Name { get; set; }
}
