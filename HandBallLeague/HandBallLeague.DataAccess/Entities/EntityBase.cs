using System.ComponentModel.DataAnnotations;

namespace HandBallLeague.DataAccess.Entities
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}
