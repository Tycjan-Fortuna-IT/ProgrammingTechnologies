using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class State
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int ProductQuantity { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual Product Product { get; set; } = null!;
}
