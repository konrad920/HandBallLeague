using AutoMapper;
using HandBallLeague.AplicationServices.API.Domain;
using HandBallLeague.AplicationServices.API.Domain.Models;
using HandBallLeague.DataAccess;
using HandBallLeague.DataAccess.CQRS.Queries;
using HandBallLeague.DataAccess.Entities;
using MediatR;

namespace HandBallLeague.AplicationServices.API.Handlers
{
    public class GetAllCoachesHandler : IRequestHandler<GetAllCoachesRequest, GetAllCoachesResponse>
    {
        private readonly IRepository<CoachDB> repository;
        private readonly DataAccess.IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetAllCoachesHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.repository = repository;
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }
        public async Task<GetAllCoachesResponse> Handle(GetAllCoachesRequest request, CancellationToken cancellationToken)
        {
            var query = new GetCoachesQuery();
            var coaches = await this.queryExecutor.Execute(query);
            var mappedCoaches = this.mapper.Map<List<Coach>>(coaches);
            var response = new GetAllCoachesResponse()
            {
                Data = mappedCoaches
            };

            return response;
        }
    }
}
