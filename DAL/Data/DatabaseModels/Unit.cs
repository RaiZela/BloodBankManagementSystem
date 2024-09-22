namespace DAL.Data.DatabaseModels;

[Table(nameof(Unit))]
[PrimaryKey(nameof(ID))]

public class Unit : AuditableEntity
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

    [ForeignKey(nameof(FractionedUnit.ID))]
    public int FractionedUnitID { get; set; }
    [DeleteBehavior(DeleteBehavior.NoAction)]

    public virtual FractionedUnit FractionedUnit { get; set; }

    public virtual List<PooledUnit> PooledUnits { get; set; }
}
