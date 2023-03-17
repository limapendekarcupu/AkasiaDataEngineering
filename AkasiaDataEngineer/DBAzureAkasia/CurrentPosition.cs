using System;
using System.Collections.Generic;

namespace AkasiaDataEngineer.DBAzureAkasia;

public partial class CurrentPosition
{
    public string? Employeeid { get; set; }

    public string? Fullname { get; set; }

    public DateOnly? Birthdate { get; set; }

    public string? Address { get; set; }

    public string? Postitle { get; set; }
}
