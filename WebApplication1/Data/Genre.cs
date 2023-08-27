using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data
{
    [Table("Genre")]
    public class Genre
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Decsription { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
