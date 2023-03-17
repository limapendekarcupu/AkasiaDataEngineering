using System;
using System.Collections.Generic;

namespace AkasiaDataEngineer.DBAzureAkasia;

public partial class TEmployee
{
    public int Id { get; set; }

    public string Employeeid { get; set; } = null!;

    public string Fullname { get; set; } = null!;

    public DateOnly Birthdate { get; set; }

    public string? Address { get; set; }
}
