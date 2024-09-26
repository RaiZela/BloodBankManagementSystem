using static General.Enums;

namespace Shared.ViewModels;

public class QuestionViewModel
{
    public int ID { get; set; }
    public string Text { get; set; }
    public QuestionType Type { get; set; }
    public List<AnswerViewModel> Answers { get; set; }
    public QuestionCategory Category { get; set; }
}
