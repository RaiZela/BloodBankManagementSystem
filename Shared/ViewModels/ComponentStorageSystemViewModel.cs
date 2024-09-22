using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.ViewModels;

public class ComponentStorageSystemViewModel
{
    public int ID { get; set; }
    public int ComponentID { get; set; }
    public double MinStorageTemp { get; set; }
    public double MaxStorageTemp { get; set; }
    public double IdealStorageTemp { get; set; }
    public int TempUomID { get; set; }
    public int StorageSystemID { get; set; }
    public double ExpirationTime { get; set; }
    public int ExpirationUom { get; set; }
}
