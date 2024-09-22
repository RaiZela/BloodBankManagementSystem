using System.ComponentModel.DataAnnotations;

namespace Shared.ViewModels;

public abstract class BaseViewModel
{
    public int ID { get; set; }
    public string Code { get; set; }
    [Required]
    public string Description { get; set; }
    public bool IsEnabled { get; set; }
}
