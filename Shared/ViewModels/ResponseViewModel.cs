using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ViewModels;

public class ResponseViewModel
{
    public int DonorID { get; set; }

    public int QuestionID { get; set; }

    public int AnswerID { get; set; }

}
