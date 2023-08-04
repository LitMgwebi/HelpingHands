using System;
using System.Collections.Generic;

namespace HelpingHands.Models;

public partial class Nurse
{
    public int NurseId { get; set; }

    public string Grade { get; set; } = null!;

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual User NurseNavigation { get; set; } = null!;

    public virtual ICollection<Suburb> Suburbs { get; set; } = new List<Suburb>();
}
