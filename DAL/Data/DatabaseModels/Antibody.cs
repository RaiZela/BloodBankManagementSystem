using DAL.Data.Base.Models;

namespace DAL.Data.DatabaseModels;

[Table(nameof(Antibody))]
[PrimaryKey(nameof(ID))]
[Index(nameof(Code))]
public class Antibody : BasicParameters
{
}
