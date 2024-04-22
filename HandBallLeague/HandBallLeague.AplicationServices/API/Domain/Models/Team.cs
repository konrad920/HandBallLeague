using System.ComponentModel.DataAnnotations;

namespace HandBallLeague.AplicationServices.API.Domain.Models
{
    public class Team
    {
        public int Id { get; set; }

        public string NameOfTeam { get; set; }

        public string CityOfTeam { get; set; }
    }
}
