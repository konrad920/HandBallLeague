using AutoMapper;
using HandBallLeague.AplicationServices.API.Domain.Models;
using HandBallLeague.AplicationServices.API.Domain.Teams;
using HandBallLeague.DataAccess.Entities;

namespace HandBallLeague.AplicationServices.API.Mappings
{
    public class TeamProfile : Profile
    {
        public TeamProfile()
        {
            this.CreateMap<AddTeamRequest, TeamDB>()
                .ForMember(x => x.NameOfTeam, y => y.MapFrom(z => z.TeamName))
                .ForMember(x => x.CityOfTeam, y => y.MapFrom(z => z.TeamCity))
                .ForMember(x => x.FoundingYear, y => y.MapFrom(z => z.TeamFoundingYear));

            this.CreateMap<TeamDB, Team>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.NameOfTeam, y => y.MapFrom(z => z.NameOfTeam))
                .ForMember(x => x.CityOfTeam, y => y.MapFrom(z => z.CityOfTeam))
                .ForMember(x => x.CoachIdOfTeam, y => y.MapFrom(z => z.CoachDB.Id));
        }
    }
}
