using static General.Enums;

namespace Shared.ViewModels;

public class QuestionViewModel
{
    public int ID { get; set; }
    public string QuestionText { get; set; }
    public QuestionType QuestionType { get; set; }
    public List<AnswerViewModel> Answers { get; set; }
    public QuestionCategory QuestionCategory { get; set; }
}
