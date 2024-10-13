using AutoMapper;
using HandBallLeague.AplicationServices.API.Domain;
using HandBallLeague.AplicationServices.API.Domain.Models;
using HandBallLeague.DataAccess;
using HandBallLeague.DataAccess.CQRS.Queries;
using HandBallLeague.DataAccess.Entities;
using MediatR;

namespace HandBallLeague.AplicationServices.API.Handlers
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
            var matches = await this.queryExecutor.Execute(query);
            var mappedMatches = this.mapper.Map<List<Match>>(matches);
            var response = new GetAllMatchesResponse()
            {
                Data = mappedMatches
            };

            return response;
        }
    }
}
