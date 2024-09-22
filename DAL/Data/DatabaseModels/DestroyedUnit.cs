namespace DAL.Data.DatabaseModels;

[Table(nameof(DestroyedUnit))]
[PrimaryKey(nameof(ID))]
public class DestroyedUnit : AuditableEntity
{
    [ForeignKey(nameof(Component.ID))]
    public int ComponentID { get; set; }

    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual Component Component { get; set; }

    [ForeignKey(nameof(Donation.ID))]
    public int DonationID { get; set; }

    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual Donation Donation { get; set; }

    public string Barcode { get; set; }
    public DateTime CollectionDate { get; set; }
    public BloodUnitStatus Status { get; set; }

    [ForeignKey(nameof(DestructionReason.ID))]
    public int DestructionReasonID { get; set; }

    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual DestructionReason Reason { get; set; }
}
