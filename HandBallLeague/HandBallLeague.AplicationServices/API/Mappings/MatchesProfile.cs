using AutoMapper;
using HandBallLeague.AplicationServices.API.Domain.Models;
using HandBallLeague.DataAccess.Entities;

namespace HandBallLeague.AplicationServices.API.Mappings
{
    public class MatchesProfile : Profile
    {
        public MatchesProfile()
        {
            this.CreateMap<MatchDB, Match>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.HostsScore, y => y.MapFrom(z => z.HostsScore))
                .ForMember(x => x.GuestsScore, y => y.MapFrom(z => z.GuestsScore))
                .ForMember(x => x.HostsTeamId, y => y.MapFrom(z => z.HostsTeamId))
                .ForMember(x => x.GuestsTeamId, y => y.MapFrom(z => z.GuestsTeamId));
        }
    }
}
