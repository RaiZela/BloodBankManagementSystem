namespace DAL.Data.DatabaseModels;

[Table(nameof(FractionedUnit))]
[PrimaryKey(nameof(ID))]
public class FractionedUnit : AuditableEntity
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
    public int PreviousUnitID { get; set; }
    public virtual List<Unit> CreatedUnits{ get; set; }
}
