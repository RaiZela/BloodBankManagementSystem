namespace DAL.Data.DatabaseModels;

[Table(nameof(BagLot))]
[PrimaryKey(nameof(ID))]

public class BagLot : AuditableEntity
{
    [ForeignKey(nameof(BagType.ID))]
    public int BagTypeId {  get; set; }

    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual BagType BagType { get; set; }


    [ForeignKey(nameof(BagManufacturer.ID))]
    public int BagManufacturerID { get; set; }

    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual BagManufacturer BagManufacturer { get; set; }

    public string LotNumber { get; set; }
    public int QuantityReceived { get; set; }
    public int QuantityUsed { get; set; }
    public int QuantityInStock { get; set; }
    public DateTime ReceivedDate { get; set; }
    public DateTime ExpirationDate { get; set; }

    public virtual List<Donation> Donations { get; set; }
}
