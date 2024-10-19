using HandBallLeague.DataAccess.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HandBallLeague.AplicationServices.API.Domain.Players
{
    public class EditPlayerByIdRequest : IRequest<EditPlayerByIdResponse>
    {
        public int Id { get; set; }

        public int EditTeamDBId { get; set; }

        public string ? EditNameOfPlayer { get; set; }

        public string ? EditSurnameOfPlayer { get; set; }

        public string ? EditPosition { get; set; }

        public float EditSalary { get; set; }

        public int EditAgeOfPlayer { get; set; }
    }
}
