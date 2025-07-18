﻿namespace DAL.Data.DatabaseModels;

[Table(nameof(DeletedDonors))]
[PrimaryKey(nameof(ID))]
public class DeletedDonors : AuditableEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Gender Gender { get; set; }
    public DateTime Birthday { get; set; }

    [ForeignKey(nameof(City.ID))]
    public int CityID { get; set; }

    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual City City { get; set; }
    public string IdNumber { get; set; }
    public DocumentType DocumentType { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public bool IsSuspended { get; set; }
    public virtual List<Donation> Donations { get; set; }
    public virtual List<SuspensionReason> SuspensionReasons { get; set; }
    public int DonorID { get; set; }
}
