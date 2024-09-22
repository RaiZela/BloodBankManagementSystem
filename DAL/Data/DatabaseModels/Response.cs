namespace DAL.Data.DatabaseModels;

[Table(nameof(Response))]
[PrimaryKey(nameof(ID))]

public class Response : AuditableEntity
{
    [ForeignKey(nameof(Donor.ID))]
    public int DonorID { get; set; }

    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual Donor Donor { get; set; }

    [ForeignKey(nameof(Question.ID))]
    public int QuestionID { get; set; }

    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual Question Question { get; set; }

    [ForeignKey(nameof(Answer.ID))]
    public int AnswerID { get; set; }

    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual Answer Answer { get; set; }
}
