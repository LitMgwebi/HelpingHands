using System;
using System.Collections.Generic;

namespace HelpingHands.Models;

public partial class Wound
{
    public int WoundId { get; set; }

    public string Name { get; set; } = null!;

    public string Grade { get; set; } = null!;

    public string? Description { get; set; }

    public bool Active { get; set; } = true;

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();
}
