using AutoMapper;
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
        private readonly IMapper mapper;

        public GetAllPlayersHandler(IRepository<PlayerDB> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<GetAllPlayersResponse> Handle(GetAllPlayersRequest request, CancellationToken cancellationToken)
        {
            var players = await this.repository.GetAll();
            var mappedPlayers = this.mapper.Map<List<Player>>(players);
            var response = new GetAllPlayersResponse()
            {
                Data = mappedPlayers
            };

            return response;
        }
    }
}
