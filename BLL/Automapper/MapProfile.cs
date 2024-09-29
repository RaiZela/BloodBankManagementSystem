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
        CreateMap<Donation, DonationViewModel>().ReverseMap();


        CreateMap<Question, QuestionViewModel>()
            .ReverseMap()
            .ForMember(src => src.Answers, dest => dest.Ignore());

        CreateMap<Question, QuestionaireViewModel>()
        .ReverseMap();

        CreateMap<Answer, AnswerViewModel>().ReverseMap();

        CreateMap<Response, ResponseViewModel>()
            .ReverseMap()
            .ForMember(src => src.Question, dest=>dest.Ignore())
            .ForMember(src => src.Donor, dest=>dest.Ignore())
            .ForMember(src => src.AnswerID, dest=>dest.MapFrom(obj => obj.AnswerID == 0 ? null : obj.AnswerID))
            .ForMember(src => src.Answer, dest=>dest.Ignore());

        CreateMap<ApplicationUser, ApplicationUserViewModel>()
            .ReverseMap();


        CreateMap<Examination, ExaminationViewModel>()
            .ReverseMap();
            //.ForMember(src => src.ReferenceValues, dest => dest.Ignore());


        CreateMap<ReferenceValue, ReferenceValueViewModel>().ReverseMap();
    }
}
