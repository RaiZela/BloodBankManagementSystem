namespace DAL.Data.Base.Models;
public class BaseAuditableEntity 
{
    public int ID { get; set; }
    public DateTime CreatedDate { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? LastUpdatedDate { get; set; }
    public string LastUpdatedBy { get; set; }

}
