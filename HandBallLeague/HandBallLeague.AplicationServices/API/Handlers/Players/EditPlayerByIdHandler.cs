using AutoMapper;
using HandBallLeague.AplicationServices.API.Domain.Models;
using HandBallLeague.AplicationServices.API.Domain.Players;
using HandBallLeague.DataAccess;
using HandBallLeague.DataAccess.CQRS.Commands.PUT;
using HandBallLeague.DataAccess.CQRS.Queries.BYID;
using MediatR;

namespace HandBallLeague.AplicationServices.API.Handlers.Players
{
    public class EditPlayerByIdHandler : IRequestHandler<EditPlayerByIdRequest, EditPlayerByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly ICommandExecutor commandExecutor;

        public EditPlayerByIdHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.commandExecutor = commandExecutor;
        }
        public async Task<EditPlayerByIdResponse> Handle(EditPlayerByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetPlayerByIdQuery()
            { 
                PlayerId = request.Id 
            };
            var playerToEdit = await this.queryExecutor.Execute(query);
            var command = new EditPlayerByIdCommand()
            {
                Parameter = playerToEdit,
                PlayerName = request.EditNameOfPlayer,
                PlayerSurname = request.EditSurnameOfPlayer,
                PlayerPosition = request.EditPosition,
                PlayerSalary = request.EditSalary,
                PlayerTeamId = request.EditTeamDBId,
                PlayerAge = request.EditAgeOfPlayer
            };
            var playerEdited = await this.commandExecutor.Execute(command);
            return new EditPlayerByIdResponse()
            {
                Data = this.mapper.Map<Player>(playerEdited)
            };
        }
    }
}
