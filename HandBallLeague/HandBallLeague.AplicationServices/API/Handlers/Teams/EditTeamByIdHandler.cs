using AutoMapper;
using HandBallLeague.AplicationServices.API.Domain.Models;
using HandBallLeague.AplicationServices.API.Domain.Teams;
using HandBallLeague.DataAccess;
using HandBallLeague.DataAccess.CQRS.Commands.PUT;
using HandBallLeague.DataAccess.CQRS.Queries.BYID;
using MediatR;

namespace HandBallLeague.AplicationServices.API.Handlers.Teams
{
    public class EditTeamByIdHandler : IRequestHandler<EditTeamByIdRequest, EditTeamByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public EditTeamByIdHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }
        public async Task<EditTeamByIdResponse> Handle(EditTeamByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetTeamByIdQuery()
            {
                TeamId = request.Id
            };
            var teamToEdit = await this.queryExecutor.Execute(query);
            var command = new EditTeamByIdCommand()
            {
                Parameter = teamToEdit,
                TeamBudget = teamToEdit.BudgetOfTeam,
                TeamName = teamToEdit.NameOfTeam,
                TeamFoundingYear = teamToEdit.FoundingYear,
                TeamCity = teamToEdit.CityOfTeam
            };
            var teamEdited = await this.commandExecutor.Execute(command);
            return new EditTeamByIdResponse()
            {
                Data = this.mapper.Map<Team>(teamEdited)
            };
        }
    }
}
