using AutoMapper;
using HandBallLeague.AplicationServices.API.Domain.Models;
using HandBallLeague.AplicationServices.API.Domain.Players;
using HandBallLeague.DataAccess;
using HandBallLeague.DataAccess.CQRS.Commands.ADD;
using HandBallLeague.DataAccess.Entities;
using MediatR;

namespace HandBallLeague.AplicationServices.API.Handlers.Players
{
    public class AddPlayerHandler : IRequestHandler<AddPLayerRequest, AddPlayerResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddPlayerHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }
        public async Task<AddPlayerResponse> Handle(AddPLayerRequest request, CancellationToken cancellationToken)
        {
            var playerToDB = new AddPlayerCommand()
            {
                Parameter = this.mapper.Map<PlayerDB>(request)
            };
            var command = await this.commandExecutor.Execute(playerToDB);
            return new AddPlayerResponse
            {
                Data = this.mapper.Map<Player>(command)
            };
        }
    }
}
