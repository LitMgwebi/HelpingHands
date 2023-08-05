using System;
using System.Collections.Generic;

namespace HelpingHands.Models;

public partial class City
{
    public int CityId { get; set; }

    public string Name { get; set; } = null!;

    public string Abbreviation { get; set; } = null!;

    public bool Active { get; set; }

    public virtual ICollection<Suburb> Suburbs { get; set; } = new List<Suburb>();
}
