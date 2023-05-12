using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class User
{
    public int Id { get; set; }

    public string Nickname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public decimal Balance { get; set; }

    public DateTime DateOfBirth { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
