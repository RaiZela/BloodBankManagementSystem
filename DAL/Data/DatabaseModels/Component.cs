namespace DAL.Data.DatabaseModels;

[Table(nameof(Component))]
[PrimaryKey(nameof(ID))]
[Index(nameof(Code))]
public class Component : BasicParameters
{
    public double ShelfLife { get; set; }

    [ForeignKey(nameof(UnitsOfMeasurement.ID))]
    public int UnitsOfMeasurementID { get; set; }

    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual UnitOfMeasurement UnitsOfMeasurement { get; set; }
}
