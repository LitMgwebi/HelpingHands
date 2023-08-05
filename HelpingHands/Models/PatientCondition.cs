using System;
using System.Collections.Generic;

namespace HelpingHands.Models;

public partial class PatientCondition
{
    public int PatientId { get; set; }

    public int ConditionId { get; set; }

    public bool Active { get; set; } = true;

    public virtual Condition Condition { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;
}
