using static General.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.ViewModels;

public class SuspensionReasonViewModel : BaseViewModel
{
    public SuspensionType Type { get; set; }
    public double? Duration { get; set; }
    public int? DurationUomID { get; set; }
}

public class SuspensionReasonShowViewModel : BaseViewModel
{
    public SuspensionType Type { get; set; }
    public string? Duration { get; set; }
}
