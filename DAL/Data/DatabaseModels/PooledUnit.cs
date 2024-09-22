namespace DAL.Data.DatabaseModels;

[Table(nameof(PooledUnit))]
[PrimaryKey(nameof(ID))]
public class PooledUnit : AuditableEntity
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
    [ForeignKey(nameof(CreatedUnit.ID))]
    public int CreatedUnitID { get; set; }

    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual Unit CreatedUnit { get; set; }
    public int PreviousUnitID { get; set; }
}
