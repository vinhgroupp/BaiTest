using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data
{
    [Table("Movie")]
    public class Movie
    {
        [Key]
        public Guid Id { get; set; }
        public Guid GenreId { get; set; }
        public Guid ActorId { get; set; }
        public string? Decription { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }

        public Genre Genres { get; set; }
        public ICollection<Actor> Actors { get; set; }

    }
}
