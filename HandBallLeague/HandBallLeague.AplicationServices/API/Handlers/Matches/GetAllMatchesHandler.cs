using AutoMapper;
using HandBallLeague.AplicationServices.API.Domain.Matches;
using HandBallLeague.AplicationServices.API.Domain.Models;
using HandBallLeague.DataAccess;
using HandBallLeague.DataAccess.CQRS.Queries.ALL;
using MediatR;

namespace HandBallLeague.AplicationServices.API.Handlers.Matches
{
    public class GetAllMatchesHandler : IRequestHandler<GetAllMatchesRequest, GetAllMatchesResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetAllMatchesHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetAllMatchesResponse> Handle(GetAllMatchesRequest request, CancellationToken cancellationToken)
        {
            var query = new GetMatchesQuery();
            var matches = await queryExecutor.Execute(query);
            var mappedMatches = mapper.Map<List<Match>>(matches);
            var response = new GetAllMatchesResponse()
            {
                Data = mappedMatches
            };

            return response;
        }
    }
}
