using System;
using System.Collections.Generic;

namespace HelpingHands.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public string EmailAddress { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Username { get; set; }

    public string ContactNumber { get; set; } = null!;

    public string? UserType { get; set; }

    public string? ApplicationType { get; set; }

    public int Idnumber { get; set; }

    public string Gender { get; set; } = null!;

    public byte[]? ProfilePicture { get; set; }

    public string? ProfilePictureName { get; set; }

    public bool Active { get; set; } = true;

    public virtual Nurse? Nurse { get; set; }

    public virtual Patient? Patient { get; set; }
}
