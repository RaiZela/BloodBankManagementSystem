namespace DAL.Data.DatabaseModels;

[Table(nameof(ProcessDetail))]
[PrimaryKey(nameof(ID))]
public class ProcessDetail : AuditableEntity
{
    [ForeignKey(nameof(Process.ID))]
    public int ProcessID { get; set; }
    public virtual Process Process { get; set; }
    public double Volume { get; set; }
    public double Duration { get; set; }
    public double Temperature { get; set; }


    [ForeignKey(nameof(TempUom.ID))]
    public int TempUomID { get; set; }

    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual UnitOfMeasurement TempUom { get; set; }

    [ForeignKey(nameof(DurationUom.ID))]
    public int DurationUomID { get; set; }

    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual UnitOfMeasurement DurationUom { get; set; }

    [ForeignKey(nameof(VolumeUom.ID))]
    public int VolumeUomId { get; set; }

    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual UnitOfMeasurement VolumeUom { get; set; }
}
