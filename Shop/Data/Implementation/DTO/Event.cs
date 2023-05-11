using System;
using System.Collections.Generic;

namespace Data.Implementation.DTO;

internal class Event
{
    public int Id { get; set; }

    public int StateId { get; set; }

    public int UserId { get; set; }

    public DateTime OccurrenceDate { get; set; }
}
