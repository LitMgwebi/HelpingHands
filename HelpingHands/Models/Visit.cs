using System;
using System.Collections.Generic;

namespace HelpingHands.Models;

public partial class Visit
{
    public int VisitId { get; set; }

    public int ContractId { get; set; }

    public DateTime VisitDate { get; set; }

    public TimeSpan? Arrival { get; set; }

    public TimeSpan Departure { get; set; }

    public string WoundCondition { get; set; } = null!;

    public string? Note { get; set; }

    public bool Active { get; set; } = true;

    public virtual Contract Contract { get; set; } = null!;
}
