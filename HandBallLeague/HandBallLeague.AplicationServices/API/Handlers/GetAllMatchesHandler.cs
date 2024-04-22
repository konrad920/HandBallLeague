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

        public GetAllMatchesHandler(IRepository<MatchDB> repository)
        {
            this.repository = repository;
        }
        public Task<GetAllMatchesResponse> Handle(GetAllMatchesRequest request, CancellationToken cancellationToken)
        {
            var matches = this.repository.GetAll();
            var matchesDomain = matches.Select(x => new Match()
            {
                Id = x.Id,
                HostsScore = x.HostsScore,
                GuestsScore = x.GuestsScore
            });

            var response = new GetAllMatchesResponse()
            {
                Data = matchesDomain.ToList()
            };

            return Task.FromResult(response);
        }
    }
}
