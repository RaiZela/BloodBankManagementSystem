using AutoMapper;
using DAL.Data.DatabaseModels;
using DAL.Data.DatabaseModels.User;
using Shared.ViewModels;

namespace BloodBankManagementSystem.BLL.Automapper;

public class MapProfile : AutoMapper.Profile
{
    public MapProfile()
    {
        CreateMap<Clinic, ClinicsViewModel>().ReverseMap();
        CreateMap<City, CityViewModel>().ReverseMap();
        CreateMap<Antibody, AntibodyViewModel>().ReverseMap();
        CreateMap<Bank, BloodBankViewModel>().ReverseMap();
        CreateMap<DonationSymptom, DonationSymptomViewModel>().ReverseMap();
        CreateMap<DonationTherapy, DonationTherapyViewModel>().ReverseMap();
        CreateMap<DonationType, DonationTypeViewModel>().ReverseMap();
        CreateMap<Problem, ProblemViewModel>().ReverseMap();
        CreateMap<Reaction, ReactionViewModel>().ReverseMap();
        CreateMap<SuspensionReason, SuspensionReasonViewModel>().ReverseMap();

        CreateMap<PolicyViewModel, Policy>().ReverseMap();


        CreateMap<Donor, DonorViewModel>().ReverseMap();


        CreateMap<Question, QuestionViewModel>().ReverseMap();
        CreateMap<Answer, AnswerViewModel>().ReverseMap();
    }
}
