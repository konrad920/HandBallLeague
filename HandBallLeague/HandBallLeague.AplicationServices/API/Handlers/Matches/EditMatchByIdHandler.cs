using AutoMapper;
using HandBallLeague.AplicationServices.API.Domain.Matches;
using HandBallLeague.AplicationServices.API.Domain.Models;
using HandBallLeague.DataAccess;
using HandBallLeague.DataAccess.CQRS.Commands.PUT;
using HandBallLeague.DataAccess.CQRS.Queries.BYID;
using MediatR;

namespace HandBallLeague.AplicationServices.API.Handlers.Matches
{
    public class EditMatchByIdHandler : IRequestHandler<EditMatchByIdRequest, EditMatchByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public EditMatchByIdHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }
        public async Task<EditMatchByIdResponse> Handle(EditMatchByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetMatchByIdQuery()
            {
                MatchId = request.Id
            };
            var matchToEdit = await this.queryExecutor.Execute(query);
            var command = new EditMatchByIdCommand()
            {
                Parameter = matchToEdit,
                MatchAudience = matchToEdit.Audience,
                MatchGuestsScore = matchToEdit.GuestsScore,
                MatchHostsScore = matchToEdit.HostsScore,
                MatchGuestsTeamId = matchToEdit.GuestsTeamId,
                MatchHostsTeamId = matchToEdit.HostsTeamId
            };
            var matchEdited = await this.commandExecutor.Execute(command);
            return new EditMatchByIdResponse()
            {
                Data = this.mapper.Map<Match>(matchEdited)
            };
        }
    }
}
