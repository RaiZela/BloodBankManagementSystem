using BloodBankManagementSystem.DAL;

namespace DAL.Data.DatabaseModels.User;

[Table(nameof(Policy))]
[PrimaryKey(nameof(ID))]
public class Policy : AuditableEntity
{
    public string ID { get; set; } 
    public string Name { get; set; }
    public string RequiredClaim {  get; set; }
    public string ClaimValue { get; set; }

    public List<UserPolicy> Users { get; set; }
}
