using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace General;

public class Enums
{
    public enum Gender
    {
        Male = 1,
        Female = 2
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
        [Display(Name = "Checkbox")]
        Checkbox,
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
        Permanent = 1,
        Temporary = 2
    }

    public enum ComponentStatus
    {
        Gained=1,
        Discarded =2
    }

    public enum UserStatus
    {
        Disabled=0,
        Enabled=1
    }
}
