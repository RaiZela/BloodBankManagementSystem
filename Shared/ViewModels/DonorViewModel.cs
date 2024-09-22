using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static General.Enums;

namespace Shared.ViewModels;

public class DonorViewModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Gender Gender { get; set; }
    public DateTime? Birthday { get; set; }
    public int CityID { get; set; }
    public string IdNumber { get; set; }
    public DocumentType DocumentType { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public bool IsSuspended { get; set; }
}
