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
            var matchToDelete = new GetMatchByIdQuery()
            {
                MatchId = request.Id
            };
            var query = await this.queryExecutor.Execute(matchToDelete);
            var matchDeleted = new DeleteMatchByIdCommand()
            {
                Parameter = this.mapper.Map<MatchDB>(query)
            };
            var command = await this.commandExecutor.Execute(matchDeleted);
            return new DeleteMatchByIdResponse()
            {
                Data = this.mapper.Map<Match>(command)
            };
        }
    }
}
