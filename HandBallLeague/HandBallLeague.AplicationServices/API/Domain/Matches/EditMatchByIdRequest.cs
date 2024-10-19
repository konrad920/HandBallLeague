using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HandBallLeague.AplicationServices.API.Domain.Matches
{
    public class EditMatchByIdRequest : IRequest<EditMatchByIdResponse>
    {
        public int Id { get; set; }

        public int EditAudience { get; set; }

        public int EditHostsScore { get; set; }

        public int EditGuestsScore { get; set; }

        public int EditGuestsTeamId { get; set; }

        public int EditHostsTeamId { get; set; }
    }
}
