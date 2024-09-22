namespace DAL.Data.DatabaseModels;

[Table(nameof(Bank))]
[PrimaryKey(nameof(ID))]
[Index(nameof(Code))]
[Index(nameof(Type))]
public class Bank : BasicParameters
{
    public BankType Type { get; set; }
}
