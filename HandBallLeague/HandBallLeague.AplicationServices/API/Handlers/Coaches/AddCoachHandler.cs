using AutoMapper;
using HandBallLeague.AplicationServices.API.Domain.Coaches;
using HandBallLeague.AplicationServices.API.Domain.Models;
using HandBallLeague.DataAccess;
using HandBallLeague.DataAccess.CQRS.Commands.ADD;
using HandBallLeague.DataAccess.Entities;
using MediatR;

namespace HandBallLeague.AplicationServices.API.Handlers.Coaches
{
    public class AddCoachHandler : IRequestHandler<AddCoachRequest, AddCoachResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddCoachHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }
        public async Task<AddCoachResponse> Handle(AddCoachRequest request, CancellationToken cancellationToken)
        {
            var command = new AddCoachCommand()
            {
                Parameter = this.mapper.Map<CoachDB>(request)
            };
            var coachToDB = await this.commandExecutor.Execute(command);
            return new AddCoachResponse()
            {
                Data = this.mapper.Map<Coach>(coachToDB)
            };
        }
    }
}
