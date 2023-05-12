using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public double Price { get; set; }

    public int Pegi { get; set; }

    public virtual ICollection<State> States { get; set; } = new List<State>();
}
