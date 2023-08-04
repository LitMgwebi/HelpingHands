using System;
using System.Collections.Generic;

namespace HelpingHands.Models;

public partial class Condition
{
    public int ConditionId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
}
