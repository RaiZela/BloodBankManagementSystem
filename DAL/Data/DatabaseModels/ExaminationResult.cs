namespace DAL.Data.DatabaseModels;

[Table(nameof(ExaminationResult))]
[PrimaryKey(nameof(ID))]
public class ExaminationResult : AuditableEntity
{

    [ForeignKey(nameof(Examination.ID))]
    public int ExaminationID { get; set; }

    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual Examination Examination { get; set; }
    public double ResultValue { get; set; }

    [ForeignKey(nameof(Donation.ID))]
    public int? DonationID { get; set; }

    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual Donation? Donation { get; set; }

    [ForeignKey(nameof(Donor.ID))]
    public int DonorID { get; set; }
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual Donor Donor { get; set; }
}
