using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Implementation.DTO;

internal class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Nickname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public double Balance { get; set; }

    public DateTime DateOfBirth { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
