namespace Shared.ViewModels;

public class ExaminationViewModel : BaseViewModel
{
    public virtual List<ReferenceValueViewModel> ReferenceValues { get; set; }
}

public class DonationExaminationViewModel : ExaminationViewModel
{
    public DateTime CreatedDate { get; set; }
    public virtual ExaminationResultViewModel ExaminationResult { get; set; } = new ExaminationResultViewModel();
}