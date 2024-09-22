namespace DAL.Data.DatabaseModels;

[Table(nameof(Examination))]
[PrimaryKey(nameof(ID))]
[Index(nameof(Code))]
public class Examination : BasicParameters
{
    public virtual List<ReferenceValue> ReferenceValues { get; set; }
}
