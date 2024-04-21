using HandBallLeague.AplicationServices.API.Domain;
using HandBallLeague.AplicationServices.API.Domain.Models;
using HandBallLeague.DataAccess;
using HandBallLeague.DataAccess.Entities;
using MediatR;

namespace HandBallLeague.AplicationServices.API.Handlers
{
    public class GetAllPlayersHandler : IRequestHandler<GetAllPlayersRequest, GetAllPlayersResponse>
    {
        private readonly IRepository<PlayerDB> repository;

        public GetAllPlayersHandler(IRepository<PlayerDB> repository)
        {
            this.repository = repository;
        }
        public Task<GetAllPlayersResponse> Handle(GetAllPlayersRequest request, CancellationToken cancellationToken)
        {
            var players = this.repository.GetAll();
            var domainPlayers = players.Select(x => new Player() 
            {
                Id = x.Id,
                Name = x.NameOfPlayer,
                Position = x.Position
            });

            var response = new GetAllPlayersResponse()
            {
                Data = domainPlayers.ToList()
            };

            return Task.FromResult( response );
        }
    }
}
