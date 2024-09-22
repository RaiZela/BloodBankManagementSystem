namespace DAL.Data.DatabaseModels;

[Table(nameof(Question))]
[PrimaryKey(nameof(ID))]
public class Question : AuditableEntity
{
    public string Text { get; set; }
    public QuestionType Type { get; set; }
    public QuestionCategory Category { get; set; }
    public List<Answer> Answers { get; set; }
}
