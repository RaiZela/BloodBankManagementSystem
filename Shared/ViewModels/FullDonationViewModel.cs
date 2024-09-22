using static General.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.ViewModels;

public class FullDonationViewModel
{
    public int ID { get; set; }
    public int DonorID { get; set; }
    public DonorViewModel Donor { get; set; }
    public int TypeID { get; set; }
    public DonationTypeViewModel Type { get; set; }
    public int BloodUnitsCollected { get; set; }
    public DonationStatus DonationStatus { get; set; }
    public int BagLotID { get; set; }
    public BagLotViewModel BagLot { get; set; }
    public double Volume { get; set; }
    public int VolumeUomID { get; set; }
    public int ProblemID { get; set; }
    public virtual ProblemViewModel Problem { get; set; }
    public int ReactionID { get; set; }
    public virtual ReactionViewModel Reaction { get; set; }

    public virtual List<DonationTherapyViewModel> Therapies { get; set; }
    public virtual List<DonationSymptomViewModel> Symptoms { get; set; }
    public virtual List<ExaminationResultViewModel> ExaminationResults { get; set; }
}
