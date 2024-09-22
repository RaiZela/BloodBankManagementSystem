namespace DAL.Data.DatabaseModels;
[Table(nameof(SuspensionReason))]
[PrimaryKey(nameof(ID))]
[Index(nameof(Code))]
public class SuspensionReason : BasicParameters
{
    public SuspensionType Type { get; set; }
    public double Duration { get; set; }

    [ForeignKey(nameof(DurationUom.ID))]
    public int DurationUomID { get; set; }

    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual UnitOfMeasurement DurationUom { get; set; }
}
