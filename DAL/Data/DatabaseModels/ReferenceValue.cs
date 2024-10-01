namespace DAL.Data.DatabaseModels;

[Table(nameof(ReferenceValue))]
[PrimaryKey(nameof(ID))]
public class ReferenceValue : AuditableEntity
{
    public double MinValue { get; set; }
    public double MaxValue { get; set; }
    public bool IsEnabled { get; set; }

    [ForeignKey(nameof(Examination.ID))]
    public int ExaminationID { get; set; }

    [DeleteBehavior(DeleteBehavior.Cascade)]
    public virtual Examination Examination { get; set; }

    [ForeignKey(nameof(UnitOfMeasurement.ID))]
    public int UnitOfMeasurementID { get; set; }
    public UnitOfMeasurement UnitOfMeasurement { get; set; }
}
