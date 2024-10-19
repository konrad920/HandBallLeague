namespace HandBallLeague.AplicationServices.API.Domain.Models
{
    public class Player
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Position { get; set; }

        public int Age { get; set; }

        public string ? TeamNameOfPlayer { get; set; }
    }
}
