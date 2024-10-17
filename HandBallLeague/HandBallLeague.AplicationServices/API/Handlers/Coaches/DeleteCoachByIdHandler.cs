using AutoMapper;
using HandBallLeague.AplicationServices.API.Domain.Coaches;
using HandBallLeague.AplicationServices.API.Domain.Models;
using HandBallLeague.DataAccess;
using HandBallLeague.DataAccess.CQRS.Commands.DELETE;
using HandBallLeague.DataAccess.CQRS.Queries.BYID;
using HandBallLeague.DataAccess.Entities;
using MediatR;

namespace HandBallLeague.AplicationServices.API.Handlers.Coaches
{
    public class DeleteCoachByIdHandler : IRequestHandler<DeleteCoachByIdRequest, DeleteCoachByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public DeleteCoachByIdHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }
        public async Task<DeleteCoachByIdResponse> Handle(DeleteCoachByIdRequest request, CancellationToken cancellationToken)
        {
            var coachToDelete = new GetCoachByIdQuery()
            {
                CoachId = request.Id
            };
            var query = await this.queryExecutor.Execute(coachToDelete);
            var coachDeleted = new DeleteCoachByIdCommand()
            {
                Parameter = this.mapper.Map<CoachDB>(query)
            };
            var command = await this.commandExecutor.Execute(coachDeleted);
            return new DeleteCoachByIdResponse()
            {
                Data = this.mapper.Map<Coach>(command)
            };
        }
    }
}
