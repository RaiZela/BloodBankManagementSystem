using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.ViewModels;

public class BagLotViewModel
{
    public int ID { get; set; }
    public int BagTypeId { get; set; }
    public virtual BagTypeViewModel BagType { get; set; }
    public int BagManufacturerID { get; set; }
    public virtual BagManufacturerViewModel BagManufacturer { get; set; }
    public string LotNumber { get; set; }
    public int QuantityReceived { get; set; }
    public int QuantityUsed { get; set; }
    public int QuantityInStock { get; set; }
    public DateTime ReceivedDate { get; set; }
    public DateTime ExpirationDate { get; set; }
}
