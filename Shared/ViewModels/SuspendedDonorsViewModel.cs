using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ViewModels;

public class SuspendedDonorsViewModel
{
    public int DonorID { get; set; }

    public int ReasonID { get; set; }

    public virtual SuspensionReasonShowViewModel Reason { get; set; }
}
