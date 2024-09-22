using Microsoft.AspNetCore.Components.Rendering;

namespace DAL.Data.DatabaseModels;

[Table(nameof(ComponentPreparation))]
[PrimaryKey(nameof(ID))]

public class ComponentPreparation : AuditableEntity
{
    [ForeignKey(nameof(ComponentPreparationMethod.ID))]
    public int ComponentPreparationMethodID { get; set; }

    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual ComponentPreparationMethod ComponentPreparationMethods { get; set; }

    [ForeignKey(nameof(Component.ID))]
    public int ComponentID { get; set; }

    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual Component Component { get; set; }

    [ForeignKey(nameof(Process.ID))]
    public int ProcessID { get; set; }

    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual Process Process { get; set; }

    public int ParentComponentPreparationID { get; set; }

    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual ComponentPreparation ParentComponentPreparation { get; set; }
    public ComponentStatus Status { get; set; } 
}
