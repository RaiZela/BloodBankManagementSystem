namespace DAL.Data.Base.Models;

public class BasicParameters : AuditableEntity
{
    public int ID { get; set; }
    public string Code { get; set; }
    [Required]
    public string Description { get; set; }
    public bool IsEnabled { get; set; }
}
