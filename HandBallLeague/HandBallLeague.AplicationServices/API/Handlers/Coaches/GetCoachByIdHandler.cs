using AutoMapper;
using HandBallLeague.AplicationServices.API.Domain.Coaches;
using HandBallLeague.AplicationServices.API.Domain.Models;
using HandBallLeague.DataAccess;
using HandBallLeague.DataAccess.CQRS.Queries.BYID;
using MediatR;

namespace HandBallLeague.AplicationServices.API.Handlers.Coaches
{
    public class GetCoachByIdHandler : IRequestHandler<GetCoachByIdRequest, GetCoachByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetCoachByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetCoachByIdResponse> Handle(GetCoachByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetCoachByIdQuery()
            {
                CoachId = request.Id
            };
            var coach = await this.queryExecutor.Execute(query);
            var mappedCoach = this.mapper.Map<Coach>(coach);
            var response = new GetCoachByIdResponse()
            {
                Data = mappedCoach
            };
            return response;
        }
    }
}
