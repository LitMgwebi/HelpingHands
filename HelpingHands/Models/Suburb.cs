using System;
using System.Collections.Generic;

namespace HelpingHands.Models;

public partial class Suburb
{
    public int SuburbId { get; set; }

    public string SuburbName { get; set; } = null!;

    public int PostalCode { get; set; }

    public int CityId { get; set; }

    public bool Active { get; set; }

    public virtual City City { get; set; } = null!;

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();

    public virtual ICollection<PrefferedSuburb> PrefferedSuburbs { get; set; } = new List<PrefferedSuburb>();
}
