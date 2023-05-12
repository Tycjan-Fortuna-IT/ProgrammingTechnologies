using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data.Implementation.DTO;

internal class State
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int ProductQuantity { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual Product Product { get; set; } = null!;
}
