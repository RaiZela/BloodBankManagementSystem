using static General.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.ViewModels;

public class ComponentPreparationViewModel
{
    public int ID { get; set; }
    public int ComponentPreparationMethodID { get; set; }
    public int ComponentID { get; set; }
    public int ProcessID { get; set; }
    public int ParentComponentPreparationID { get; set; }
    public ComponentStatus Status { get; set; }
}
