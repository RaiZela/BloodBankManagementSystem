using static General.Enums;

namespace Shared.ViewModels;

public class DonationViewModel
{
    public int ID { get; set; }
    public int DonorID { get; set; }
    public int TypeID { get; set; }
    public int BloodUnitsCollected { get; set; }
    public DonationStatus DonationStatus { get; set; }
    public int BagLotID { get; set; }
    public double Volume { get; set; }
    public int VolumeUomID { get; set; }
    public int ProblemID { get; set; }
    public int ReactionID { get; set; }
}
