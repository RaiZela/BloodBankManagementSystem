namespace DAL.Data.DatabaseModels;

[Table(nameof(Process))]
[PrimaryKey(nameof(ID))]
[Index(nameof(Code))]
public class Process : BasicParameters
{
    public virtual ProcessDetail ProcessDetail { get; set; }
}
