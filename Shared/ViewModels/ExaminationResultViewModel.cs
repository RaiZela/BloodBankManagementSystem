using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.ViewModels;

public class ExaminationResultViewModel
{
    public int ExaminationID { get; set; }
    public virtual ExaminationViewModel Examination { get; set; }
    public double ResultValue { get; set; }
    public int DonationID { get; set; }
    public virtual DonationViewModel Donation { get; set; }
}
