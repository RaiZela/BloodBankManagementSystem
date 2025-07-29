using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using static General.Enums;

namespace Shared.ViewModels;

public class DonorViewModel
{
    public int ID { get; set; }
    [Required]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please enter only letters.")]
    public string FirstName { get; set; }

    [Required]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please enter only letters.")]
    public string LastName { get; set; }

    [Required]
    public Gender Gender { get; set; }

    [Required]
    [BirthdayValidation]
    public DateTime? Birthday { get; set; }

    [Required]
    public int CityID { get; set; }

    [Required]
    [AlphanumericString(ErrorMessage = "Please enter a valid ID Number!")]
    public string IdNumber { get; set; }

    [Required]
    public DocumentType DocumentType { get; set; }

    [Required]
    [RegularExpression(@"^\d+$", ErrorMessage = "Please enter only numbers!")]
    public string PhoneNumber { get; set; }

    [Required]
    [EmailAddress(ErrorMessage = "Please enter a valid email address!")]
    public string Email { get; set; }
    public bool IsSuspended { get; set; } = false;
}

public class FullDonorViewModel : DonorViewModel
{
    public List<DonationViewModel> Donations { get; set; }
    public CityViewModel City { get; set; }
    public List<ResponseViewModel> QuestionaireResponses { get; set; }
    public List<SuspendedDonorsViewModel> SuspendedDonors { get; set; }
    public List<ExaminationResultViewModel> ExaminationResults { get; set; }
}


public class AlphanumericStringAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var stringValue = value as string;

        if (stringValue == null || stringValue.Length != 10)
        {
            return new ValidationResult("The string must be exactly 10 characters long.");
        }

        var regex = new Regex(@"^[A-Za-z]\d{8}[A-Za-z]$");

        if (!regex.IsMatch(stringValue))
        {
            return new ValidationResult("The string must start and end with a letter and have 8 digits in between.");
        }

        return ValidationResult.Success;
    }
}

public class BirthdayValidation : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is DateTime date && date.Year < DateTime.Today.Year - 17)
            return new ValidationResult("Age should be at least 17.");

        return ValidationResult.Success;
    }
}