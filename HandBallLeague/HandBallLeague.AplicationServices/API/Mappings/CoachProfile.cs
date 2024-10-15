using AutoMapper;
using HandBallLeague.AplicationServices.API.Domain.Coaches;
using HandBallLeague.AplicationServices.API.Domain.Models;
using HandBallLeague.DataAccess.Entities;

namespace HandBallLeague.AplicationServices.API.Mappings
{
    public class CoachProfile : Profile
    {
        public CoachProfile()
        {
            CreateMap<AddCoachRequest, CoachDB>()
                .ForMember(x => x.NameOfCoach, y => y.MapFrom(z => z.CoachName))
                .ForMember(x => x.SurnameOfCoach, y => y.MapFrom(z => z.CoachSurname))
                .ForMember(x => x.AgeOfCoach, y => y.MapFrom(z => z.CoachAge))
                .ForMember(x => x.Salary, y => y.MapFrom(z => z.CoachSalary))
                .ForMember(x => x.TeamDBId, y => y.MapFrom(z => z.CoachTeamDBId));

            CreateMap<CoachDB, Coach>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.NameOfCoach))
                .ForMember(x => x.Age, y => y.MapFrom(z => z.AgeOfCoach));
        }
    }
}
