using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.ViewModels;

public class ReferenceValueViewModel
{
    public int ID { get; set; }
    public double MinValue { get; set; }
    public double MaxValue { get; set; }
    public bool IsEnabled { get; set; }
    public int ExaminationID { get; set; }
    public int UnitOfMeasurementID { get; set; }
}
