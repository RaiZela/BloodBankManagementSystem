using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.ViewModels;

public class ReferenceValueViewModel
{
    public int ID { get; set; }
    public decimal MinValue { get; set; }
    public decimal MaxValue { get; set; }
    public int ExaminationID { get; set; }
}
