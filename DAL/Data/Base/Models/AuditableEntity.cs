namespace DAL.Data.Base.Models;

public abstract class AuditableEntity : BaseAuditableEntity
{
    public DateTime? DeletedDate { get; set; }
    public string? DeletedBy { get; set; }
    public bool IsDeleted { get; set; }

}

