using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data
{
    [Table("Actor")]
    public class Actor
    {
        [Key]
        public Guid Id { get; set; }
        public Guid MovieId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Decsription { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CareerStartYear { get; set; }

        public Movie Movies { get; set; }
    }
}
