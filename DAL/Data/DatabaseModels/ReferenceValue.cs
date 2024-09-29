namespace DAL.Data.DatabaseModels;

[Table(nameof(ReferenceValue))]
[PrimaryKey(nameof(ID))]
public class ReferenceValue : AuditableEntity
{
    public double MinValue { get; set; }
    public double MaxValue { get; set; }

    [ForeignKey(nameof(Examination.ID))]
    public int ExaminationID { get; set; }

    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual Examination Examination { get; set; }
}
