using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace General;

public class Enums
{
    public enum Gender
    {
        Male,
        Female
    }

    public enum DocumentType
    {
        Id,
        DriversLicense,
        Passport
    }

    public enum QuestionType
    {
        [Display(Name = "Text")]
        Text,
        [Display(Name = "Radiobutton")]
        Radio,
        [Display(Name = "SelectBox")]
        SelectBox,
        [Display(Name = "Date")]
        Date,
        [Display(Name = "Number")]
        Number
    }

    public enum QuestionCategory
    {
        [Display(Name = "Currently")]
        One,
        [Display(Name = "In the last week")]
        Two,
        [Display(Name = "In the last 2 weeks")]
        Three,
        [Display(Name = "In the last 4 weeks")]
        Four,
        [Display(Name = "In the last 6 months")]
        Five,
        [Display(Name = "In the last 12 months")]
        Six,
        [Display(Name = "In the last 2 years")]
        Seven,
        [Display(Name = "During entire life")]
        Eight
    }

    public enum SymptomSeverity
    {
        Mild,
        Moderate,
        Severe
    }

    public enum BloodUnitStatus
    {

    }

    public enum DonationStatus
    {
        Completed,
        InProcess,
        Interrupted
    }

    public enum BankType
    {

    }

    public enum SuspensionType
    {
        Permanent,
        Temporary
    }

    public enum ComponentStatus
    {
        Gained,
        Discarded
    }

    public enum UserStatus
    {
        Disabled,
        Enabled
    }
}
