using AutoMapper;
using HandBallLeague.AplicationServices.API.Domain.Models;
using HandBallLeague.DataAccess.Entities;

namespace HandBallLeague.AplicationServices.API.Mappings
{
    public class CoachesProfile : Profile
    {
        public CoachesProfile()
        {
            this.CreateMap<CoachDB, Coach>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.NameOfCoach))
                .ForMember(x => x.Age, y => y.MapFrom(z => z.AgeOfCoach));
        }
    }
}
