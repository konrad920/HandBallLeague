using AutoMapper;
using HandBallLeague.AplicationServices.API.Domain.Coaches;
using HandBallLeague.AplicationServices.API.Domain.Models;
using HandBallLeague.DataAccess;
using HandBallLeague.DataAccess.CQRS.Commands.PUT;
using HandBallLeague.DataAccess.CQRS.Queries.BYID;
using MediatR;

namespace HandBallLeague.AplicationServices.API.Handlers.Coaches
{
    public class EditCoachByIdHandler : IRequestHandler<EditCoachByIdRequest, EditCoachByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public EditCoachByIdHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }
        public async Task<EditCoachByIdResponse> Handle(EditCoachByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetCoachByIdQuery()
            {
                CoachId = request.Id
            };
            var coachToEdit = await this.queryExecutor.Execute(query);
            var command = new EditCoachByIdCommand()
            {
                Parameter = coachToEdit,
                CoachAgeOfCoach = coachToEdit.AgeOfCoach,
                CoachNameOfCoach = coachToEdit.NameOfCoach,
                CoachSalary = coachToEdit.Salary,
                CoachSurnameOfCoach = coachToEdit.SurnameOfCoach,
                CoachTeamDBId = coachToEdit.TeamDBId,
            };
            var coachEdited = await this.commandExecutor.Execute(command);
            return new EditCoachByIdResponse()
            {
                Data = this.mapper.Map<Coach>(coachEdited)
            };
        }
    }
}
