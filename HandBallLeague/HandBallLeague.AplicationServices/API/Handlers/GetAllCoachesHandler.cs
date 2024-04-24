using AutoMapper;
using HandBallLeague.AplicationServices.API.Domain;
using HandBallLeague.AplicationServices.API.Domain.Models;
using HandBallLeague.DataAccess;
using HandBallLeague.DataAccess.Entities;
using MediatR;

namespace HandBallLeague.AplicationServices.API.Handlers
{
    public class GetAllCoachesHandler : IRequestHandler<GetAllCoachesRequest, GetAllCoachesResponse>
    {
        private readonly IRepository<CoachDB> repository;
        private readonly IMapper mapper;

        public GetAllCoachesHandler(IRepository<CoachDB> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<GetAllCoachesResponse> Handle(GetAllCoachesRequest request, CancellationToken cancellationToken)
        {
            var coaches = await this.repository.GetAll();
            var mappedCoaches = this.mapper.Map<List<Coach>>(coaches);
            var response = new GetAllCoachesResponse()
            {
                Data = mappedCoaches
            };

            return response;
        }
    }
}
