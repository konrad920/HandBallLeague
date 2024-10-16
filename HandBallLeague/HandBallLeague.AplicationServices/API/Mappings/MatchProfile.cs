using AutoMapper;
using HandBallLeague.AplicationServices.API.Domain.Matches;
using HandBallLeague.AplicationServices.API.Domain.Models;
using HandBallLeague.DataAccess.Entities;

namespace HandBallLeague.AplicationServices.API.Mappings
{
    public class MatchProfile : Profile
    {
        public MatchProfile()
        {
            this.CreateMap<AddMatchRequest, MatchDB>()
                .ForMember(x => x.HostsScore, y => y.MapFrom(z => z.MatchHostsScore))
                .ForMember(x => x.GuestsScore, y => y.MapFrom(z => z.MatchQuestScore))
                .ForMember(x => x.Audience, y => y.MapFrom(z => z.MatchAudience));

            this.CreateMap<MatchDB, Match>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.HostsScore, y => y.MapFrom(z => z.HostsScore))
                .ForMember(x => x.GuestsScore, y => y.MapFrom(z => z.GuestsScore));
        }
    }
}
