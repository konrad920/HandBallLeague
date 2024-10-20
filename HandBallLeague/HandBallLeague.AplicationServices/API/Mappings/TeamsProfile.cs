﻿using AutoMapper;
using HandBallLeague.AplicationServices.API.Domain.Models;
using HandBallLeague.DataAccess.Entities;

namespace HandBallLeague.AplicationServices.API.Mappings
{
    public class TeamsProfile : Profile
    {
        public TeamsProfile()
        {
            this.CreateMap<TeamDB, Team>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.NameOfTeam, y => y.MapFrom(z => z.NameOfTeam))
                .ForMember(x => x.CityOfTeam, y => y.MapFrom(z => z.CityOfTeam))
                .ForMember(x => x.CoachIdOfTeam, y => y.MapFrom(z => z.CoachDB.Id));
        }
    }
}
