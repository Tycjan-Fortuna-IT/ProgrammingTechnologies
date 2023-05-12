using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data.Implementation.DTO;

internal class Event
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int StateId { get; set; }

    public int UserId { get; set; }

    public DateTime OccurrenceDate { get; set; }

    public string Type { get; set; } = null!;

    public int? Quantity { get; set; }

    public virtual State State { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
