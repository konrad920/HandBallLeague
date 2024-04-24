using AutoMapper;
using HandBallLeague.AplicationServices.API.Domain;
using HandBallLeague.AplicationServices.API.Domain.Models;
using HandBallLeague.DataAccess;
using HandBallLeague.DataAccess.Entities;
using MediatR;

namespace HandBallLeague.AplicationServices.API.Handlers
{
    public class GetAllMatchesHandler : IRequestHandler<GetAllMatchesRequest, GetAllMatchesResponse>
    {
        private readonly IRepository<MatchDB> repository;
        private readonly IMapper mapper;

        public GetAllMatchesHandler(IRepository<MatchDB> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<GetAllMatchesResponse> Handle(GetAllMatchesRequest request, CancellationToken cancellationToken)
        {
            var matches = await this.repository.GetAll();
            var mappedMatches = this.mapper.Map<List<Match>>(matches);
            var response = new GetAllMatchesResponse()
            {
                Data = mappedMatches
            };

            return response;
        }
    }
}
