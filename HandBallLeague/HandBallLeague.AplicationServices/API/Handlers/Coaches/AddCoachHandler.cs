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
            var coachFromDB = new AddCoachCommand()
            {
                Parametr = this.mapper.Map<CoachDB>(request)
            };
            var command = await this.commandExecutor.Execute(coachFromDB);
            return new AddCoachResponse()
            {
                Data = this.mapper.Map<Coach>(command)
            };
        }
    }
}
