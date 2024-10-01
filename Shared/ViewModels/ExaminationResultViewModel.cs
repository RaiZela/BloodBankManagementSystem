using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.ViewModels;

public class ExaminationResultViewModel
{
    public int ExaminationID { get; set; }
    public double ResultValue { get; set; }
    public int DonationID { get; set; }
}
