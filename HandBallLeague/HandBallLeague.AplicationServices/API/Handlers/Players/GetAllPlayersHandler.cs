using AutoMapper;
using HandBallLeague.AplicationServices.API.Domain.Models;
using HandBallLeague.AplicationServices.API.Domain.Players;
using HandBallLeague.DataAccess;
using HandBallLeague.DataAccess.CQRS.Queries.ALL;
using HandBallLeague.DataAccess.CQRS.Queries.BYID;
using MediatR;

namespace HandBallLeague.AplicationServices.API.Handlers.Players
{
    public class GetAllPlayersHandler : IRequestHandler<GetAllPlayersRequest, GetAllPlayersResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetAllPlayersHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetAllPlayersResponse> Handle(GetAllPlayersRequest request, CancellationToken cancellationToken)
        {
            var query = new GetPlayersQuery();
            var players = await queryExecutor.Execute(query);
            var mappedPlayers = mapper.Map<List<Player>>(players);
            var response = new GetAllPlayersResponse()
            {
                Data = mappedPlayers
            };

            return response;
        }
    }
}
