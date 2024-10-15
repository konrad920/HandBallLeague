using AutoMapper;
using HandBallLeague.AplicationServices.API.Domain.Matches;
using HandBallLeague.AplicationServices.API.Domain.Models;
using HandBallLeague.DataAccess;
using HandBallLeague.DataAccess.CQRS.Commands.ADD;
using HandBallLeague.DataAccess.Entities;
using MediatR;

namespace HandBallLeague.AplicationServices.API.Handlers.Matches
{
    public class AddMatchHandler : IRequestHandler<AddMatchRequest, AddMatchResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddMatchHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }
        public async Task<AddMatchResponse> Handle(AddMatchRequest request, CancellationToken cancellationToken)
        {
            var matchFromDB = new AddMatchCommand()
            {
                Parametr = this.mapper.Map<MatchDB>(request)
            };
            var command = await commandExecutor.Execute(matchFromDB);
            return new AddMatchResponse()
            {
                Data = this.mapper.Map<Match>(command)
            };
        }
    }
}
