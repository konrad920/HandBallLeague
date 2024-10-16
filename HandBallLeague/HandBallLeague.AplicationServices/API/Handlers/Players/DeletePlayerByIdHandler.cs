using AutoMapper;
using HandBallLeague.AplicationServices.API.Domain.Models;
using HandBallLeague.AplicationServices.API.Domain.Players;
using HandBallLeague.DataAccess;
using HandBallLeague.DataAccess.CQRS.Commands.DELETE;
using HandBallLeague.DataAccess.CQRS.Queries.BYID;
using MediatR;

namespace HandBallLeague.AplicationServices.API.Handlers.Players
{
    public class DeletePlayerByIdHandler : IRequestHandler<DeletePlayerByIdRequest, DeletePlayerByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public DeletePlayerByIdHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }
        public async Task<DeletePlayerByIdResponse> Handle(DeletePlayerByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetPlayerByIdQuery()
            {
                PlayerId = request.Id
            };
            var playerToDelete = await this.queryExecutor.Execute(query);
            var command = new DeletePlayerByIdCommand() 
            {
                Parameter = playerToDelete
            };
            var playerDeleted = await this.commandExecutor.Execute(command);
            return new DeletePlayerByIdResponse()
            {
                Data = this.mapper.Map<Player>(playerDeleted)
            };
        }
    }
}
