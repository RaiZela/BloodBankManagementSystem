using static General.Enums;

namespace Shared.ViewModels;

public class DestroyedUnitViewModel
{
    public int ID { get; set; }
    public int ComponentID { get; set; }
    public string Barcode { get; set; }
    public DateTime CollectionDate { get; set; }
    public int DestructionReasonID { get; set; }
}
