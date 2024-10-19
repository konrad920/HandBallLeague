using AutoMapper;
using HandBallLeague.AplicationServices.API.Domain.Matches;
using HandBallLeague.AplicationServices.API.Domain.Models;
using HandBallLeague.DataAccess;
using HandBallLeague.DataAccess.CQRS.Commands.DELETE;
using HandBallLeague.DataAccess.CQRS.Queries.BYID;
using HandBallLeague.DataAccess.Entities;
using MediatR;

namespace HandBallLeague.AplicationServices.API.Handlers.Matches
{
    public class DeleteMatchByIdHandler : IRequestHandler<DeleteMatchByIdRequest, DeleteMatchByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public DeleteMatchByIdHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }
        public async Task<DeleteMatchByIdResponse> Handle(DeleteMatchByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetMatchByIdQuery()
            {
                MatchId = request.Id
            };
            var matchToDelete = await this.queryExecutor.Execute(query);
            var command = new DeleteMatchByIdCommand()
            {
                Parameter = this.mapper.Map<MatchDB>(matchToDelete)
            };
            var matchDeleted = await this.commandExecutor.Execute(command);
            return new DeleteMatchByIdResponse()
            {
                Data = this.mapper.Map<Match>(matchDeleted)
            };
        }
    }
}
