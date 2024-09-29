using static General.Enums;

namespace Shared.ViewModels;

public class QuestionBase
{
    public int ID { get; set; }
    public string Text { get; set; }
    public QuestionType Type { get; set; }
    public List<AnswerViewModel>? Answers { get; set; }
    public QuestionCategory Category { get; set; }
}
public class QuestionViewModel : QuestionBase
{

}

public class QuestionaireViewModel : QuestionBase
{

    public ResponseViewModel Response { get; set; }

    public bool SelectedBoolean
    {
        get
        {
            if (!string.IsNullOrEmpty(Response.Value))
            {
                return bool.TryParse(Response.Value, out var result) && result;
            }
            else
            {
                Response.Value = "false";
                return false;
            }
        }
        set
        {
            Response.Value = value.ToString(); // Set the Response.Value as "true" or "false"
        }
    }

    public DateTime? DateResponse
    {
        //check for null value
        get
        {
            return DateTime.TryParse(Response.Value, out var date) ? date : (DateTime?)null;
        }
        set
        {
            // Convert the DateTime? back to a string when setting
            Response.Value = value?.ToString("yyyy-MM-dd");
        }
    }
    public int NumericResponse
    {
        get
        {
            return int.TryParse(Response.Value, out var result) ? result : 0; // or handle it differently
        }
        set
        {
            Response.Value = value.ToString(); // Convert back to string when setting
        }
    }
}

