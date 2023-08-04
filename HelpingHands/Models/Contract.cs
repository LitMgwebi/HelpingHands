using System;
using System.Collections.Generic;

namespace HelpingHands.Models;

public partial class Contract
{
    public int ContractId { get; set; }

    public DateTime ContractDate { get; set; }

    public int PatientId { get; set; }

    public string AddressLineOne { get; set; } = null!;

    public string? AddressLineTwo { get; set; }

    public int SuburbId { get; set; }

    public int WoundId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int? NurseId { get; set; }

    public string? Status { get; set; }

    public string? Comment { get; set; }

    public virtual Nurse? Nurse { get; set; }

    public virtual Patient Patient { get; set; } = null!;

    public virtual Suburb Suburb { get; set; } = null!;

    public virtual ICollection<Visit> Visits { get; set; } = new List<Visit>();

    public virtual Wound Wound { get; set; } = null!;
}
