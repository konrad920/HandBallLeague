namespace HandBallLeague.AplicationServices.API.Domain.Models
{
    public class Coach
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public int TeamIdOfCoach { get; set; }
    }
}
