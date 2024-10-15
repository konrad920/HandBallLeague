using AutoMapper;
using HandBallLeague.AplicationServices.API.Domain.Models;
using HandBallLeague.AplicationServices.API.Domain.Players;
using HandBallLeague.DataAccess;
using HandBallLeague.DataAccess.CQRS.Queries.BYID;
using MediatR;

namespace HandBallLeague.AplicationServices.API.Handlers.Players
{
    public class GetPlayerByIdHandler : IRequestHandler<GetPlayerByIdRequest, GetPlayerByIdResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetPlayerByIdHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetPlayerByIdResponse> Handle(GetPlayerByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetPlayerByIdQuery()
            {
                PlayerId = request.Id
            };
            var player = await queryExecutor.Execute(query);
            var mappedPlayer = mapper.Map<Player>(player);
            var response = new GetPlayerByIdResponse()
            {
                Data = mappedPlayer
            };
            return response;
        }
    }
}
