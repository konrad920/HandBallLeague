using AutoMapper;
using HandBallLeague.AplicationServices.API.Domain.Coaches;
using HandBallLeague.AplicationServices.API.Domain.Models;
using HandBallLeague.DataAccess;
using HandBallLeague.DataAccess.CQRS.Queries.ALL;
using MediatR;

namespace HandBallLeague.AplicationServices.API.Handlers.Coaches
{
    public class GetAllCoachesHandler : IRequestHandler<GetAllCoachesRequest, GetAllCoachesResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetAllCoachesHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }
        public async Task<GetAllCoachesResponse> Handle(GetAllCoachesRequest request, CancellationToken cancellationToken)
        {
            var query = new GetCoachesQuery();
            var coaches = await queryExecutor.Execute(query);
            var mappedCoaches = mapper.Map<List<Coach>>(coaches);
            var response = new GetAllCoachesResponse()
            {
                Data = mappedCoaches
            };

            return response;
        }
    }
}
