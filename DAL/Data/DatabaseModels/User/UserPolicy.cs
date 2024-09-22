using BloodBankManagementSystem.DAL;

namespace DAL.Data.DatabaseModels.User;

public class UserPolicy : AuditableEntity
{
    public int ID { get; set; }
    public string UserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
    public string PolicyId { get; set; }
    public Policy Policy { get; set; }
}
