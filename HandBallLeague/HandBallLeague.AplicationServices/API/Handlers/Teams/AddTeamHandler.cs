using AutoMapper;
using HandBallLeague.AplicationServices.API.Domain.Models;
using HandBallLeague.AplicationServices.API.Domain.Teams;
using HandBallLeague.DataAccess;
using HandBallLeague.DataAccess.CQRS.Commands.ADD;
using HandBallLeague.DataAccess.Entities;
using MediatR;

namespace HandBallLeague.AplicationServices.API.Handlers.Teams
{
    public class AddTeamHandler : IRequestHandler<AddTeamRequest, AddTeamResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddTeamHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }
        public async Task<AddTeamResponse> Handle(AddTeamRequest request, CancellationToken cancellationToken)
        {
            var teamToDB = new AddTeamCommand()
            {
                Parameter = this.mapper.Map<TeamDB>(request)
            };
            var command = await this.commandExecutor.Execute(teamToDB);
            return new AddTeamResponse()
            {
                Data = this.mapper.Map<Team>(command)
            };
        }
    }
}
