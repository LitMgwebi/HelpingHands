using System;
using System.Collections.Generic;

namespace HelpingHands.Models;

public partial class Patient
{
    public int PatientId { get; set; }

    public string AddressLineOne { get; set; } = null!;

    public string? AddressLineTwo { get; set; }

    public int SuburbId { get; set; }

    public string Icename { get; set; } = null!;

    public string Icenumber { get; set; } = null!;

    public string? AdditionalInfo { get; set; }

    public bool Active { get; set; } = true;

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual ICollection<PatientCondition> PatientConditions { get; set; } = new List<PatientCondition>();

    public virtual User PatientNavigation { get; set; } = null!;

    public virtual Suburb Suburb { get; set; } = null!;
}
