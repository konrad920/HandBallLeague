﻿using HandBallLeague.DataAccess.Entities;

namespace HandBallLeague.DataAccess.CQRS.Commands.ADD
{
    public class AddPlayerCommand : CommandBase<PlayerDB, PlayerDB>
    {
        public override async Task<PlayerDB> Execute(HandBallLeagueContext context)
        {
            await context.Players.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
