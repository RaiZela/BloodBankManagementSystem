namespace DAL.Data.DatabaseModels;

[Table(nameof(SuspendedDonors))]
[PrimaryKey(nameof(ID))]

public class SuspendedDonors : AuditableEntity
{
    [ForeignKey(nameof(Donor.ID))]
    public int DonorID { get; set; }

    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual Donor Donor { get; set; }

    [ForeignKey(nameof(Reason.ID))]
    public int ReasonID { get; set; }

    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual SuspensionReason Reason{ get; set; }
}
