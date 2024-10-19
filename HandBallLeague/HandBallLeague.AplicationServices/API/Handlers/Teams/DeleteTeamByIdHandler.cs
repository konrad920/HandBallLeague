using AutoMapper;
using HandBallLeague.AplicationServices.API.Domain.Models;
using HandBallLeague.AplicationServices.API.Domain.Teams;
using HandBallLeague.DataAccess;
using HandBallLeague.DataAccess.CQRS.Commands.DELETE;
using HandBallLeague.DataAccess.CQRS.Queries.BYID;
using HandBallLeague.DataAccess.Entities;
using MediatR;

namespace HandBallLeague.AplicationServices.API.Handlers.Teams
{
    public class DeleteTeamByIdHandler : IRequestHandler<DeleteTeamByIdRequest, DeleteTeamByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public DeleteTeamByIdHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }
        public async Task<DeleteTeamByIdResponse> Handle(DeleteTeamByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetTeamByIdQuery()
            {
                TeamId = request.Id
            };
            var teamToDelete = await this.queryExecutor.Execute(query);
            var command = new DeleteTeamByIdCommand()
            {
                Parameter = this.mapper.Map<TeamDB>(teamToDelete)
            };
            var teamDeleted = await this.commandExecutor.Execute(command);
            return new DeleteTeamByIdResponse()
            {
                Data = this.mapper.Map<Team>(teamDeleted)
            };
        }
    }
}
