using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.ViewModels;

public class ProcessDetailViewModel
{
    public int ProcessID { get; set; }
    public double Volume { get; set; }
    public double Duration { get; set; }
    public double Temperature { get; set; }
    public int TempUomID { get; set; }
    public int DurationUomID { get; set; }
    public int VolumeUomId { get; set; }

}
