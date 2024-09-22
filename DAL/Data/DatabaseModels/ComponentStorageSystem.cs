namespace DAL.Data.DatabaseModels;

[Table(nameof(ComponentStorageSystem))]
[PrimaryKey(nameof(ID))]

public class ComponentStorageSystem : AuditableEntity
{
    [ForeignKey(nameof(Component.ID))]
    public int ComponentID { get; set; }
    public virtual Component Component { get; set; }

    public double MinStorageTemp { get; set; }
    public double MaxStorageTemp { get; set; }
    public double IdealStorageTemp { get; set; }

    [ForeignKey(nameof(TempUom.ID))]
    public int TempUomID { get; set; }

    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual UnitOfMeasurement TempUom { get; set; }

    [ForeignKey(nameof(StorageSystem.ID))]
    public int StorageSystemID { get; set; }

    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual StorageSystem StorageSystem { get; set; }
    public double ExpirationTime { get; set; }

    [ForeignKey(nameof(UnitsOfMeasurement.ID))]
    public int ExpirationUom {  get; set; }

    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual UnitOfMeasurement UnitsOfMeasurement { get; set; }
}
