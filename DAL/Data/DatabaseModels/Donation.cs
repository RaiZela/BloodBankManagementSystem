namespace DAL.Data.DatabaseModels;

[Table(nameof(Donation))]
[PrimaryKey(nameof(ID))]
public class Donation : AuditableEntity
{

    [ForeignKey(nameof(Donor.ID))]
    public int DonorID { get; set; }
    public Donor Donor { get; set; }


    [ForeignKey(nameof(Type.ID))]
    public int TypeID { get; set; }
    public DonationType Type { get; set; }

    public int BloodUnitsCollected { get; set; }
    public DonationStatus DonationStatus { get; set; }


    [ForeignKey(nameof(BagLot.ID))]
    public int BagLotID { get; set; }
    public BagLot BagLot { get; set; }
    public double Volume { get; set; }

    [ForeignKey(nameof(VolumeUom.ID))]
    public int VolumeUomID { get; set; }

    [DeleteBehavior(DeleteBehavior.NoAction)]
    public UnitOfMeasurement VolumeUom { get; set; }

    [ForeignKey(nameof(Problem.ID))]
    public int ProblemID { get; set; }

    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual Problem Problem { get; set; }    
    
    [ForeignKey(nameof(Reaction.ID))]
    public int ReactionID { get; set; }

    [DeleteBehavior(DeleteBehavior.NoAction)]
    public virtual Reaction Reaction { get; set; }

    public virtual List<DonationTherapy> Therapies { get; set; }
    public virtual List<DonationSymptom> Symptoms { get; set; }
    public virtual List<ExaminationResult> ExaminationResults { get; set; }
}
