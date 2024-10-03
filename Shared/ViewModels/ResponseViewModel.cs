using General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static General.Enums;

namespace Shared.ViewModels;

public class ResponseViewModel
{
    public int DonorID { get; set; }
    public int QuestionID { get; set; }
    public QuestionViewModel? Question { get; set; }
    public int? AnswerID { get; set; }
    public AnswerViewModel? Answer { get; set; }
    public string? Value { get; set; }
    public QuestionType QuestionType { get; set; }
    public DateTime CreatedDate { get; set; }

}
