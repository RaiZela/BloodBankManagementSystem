using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.ViewModels;

public class ComponentViewModel : BaseViewModel
{
    public double ShelfLife { get; set; }
    public int UnitsOfMeasurementID { get; set; }
}
