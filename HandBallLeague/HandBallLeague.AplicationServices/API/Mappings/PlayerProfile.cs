using AutoMapper;
using HandBallLeague.AplicationServices.API.Domain.Models;
using HandBallLeague.DataAccess.Entities;

namespace HandBallLeague.AplicationServices.API.Mappings
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile() 
        {
            this.CreateMap<PlayerDB, Player>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.NameOfPlayer))
                .ForMember(x => x.Position, y => y.MapFrom(z => z.Position))
                .ForMember(x => x.Age, y => y.MapFrom(z => z.AgeOfPlayer));
        }
    }
}
