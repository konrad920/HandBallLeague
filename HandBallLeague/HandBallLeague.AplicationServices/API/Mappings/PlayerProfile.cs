using AutoMapper;
using HandBallLeague.AplicationServices.API.Domain.Models;
using HandBallLeague.AplicationServices.API.Domain.Players;
using HandBallLeague.DataAccess.Entities;

namespace HandBallLeague.AplicationServices.API.Mappings
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile() 
        {
            this.CreateMap<AddPLayerRequest, PlayerDB>()
                .ForMember(x => x.NameOfPlayer, y => y.MapFrom(z => z.PlayerName))
                .ForMember(x => x.SurnameOfPlayer, y => y.MapFrom(z => z.PlayerSurname))
                .ForMember(x => x.Position, y => y.MapFrom(z => z.PlayerPosition))
                .ForMember(x => x.AgeOfPlayer, y => y.MapFrom(z => z.PlayerAge))
                .ForMember(x => x.Salary, y => y.MapFrom(z => z.PlayerSalary))
                .ForMember(x => x.TeamDBId, y => y.MapFrom(z => z.PlayerTeamId));

            this.CreateMap<PlayerDB, Player>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.NameOfPlayer))
                .ForMember(x => x.Position, y => y.MapFrom(z => z.Position))
                .ForMember(x => x.Age, y => y.MapFrom(z => z.AgeOfPlayer));
        }
    }
}
