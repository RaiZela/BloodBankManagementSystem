[Table(nameof(Answer))]
[PrimaryKey(nameof(ID))]

public class Answer : AuditableEntity
{
    [ForeignKey(nameof(Question.ID))]
    public int QuestionID { get; set; }

    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual Question Question { get; set; }
    public string AnswerText { get; set; }
}
