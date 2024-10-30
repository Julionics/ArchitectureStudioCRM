using System;
using System.Collections.Generic;

namespace CRMDataModel.Models;

public partial class Client
{
    public int ClientId { get; set; }

    public string CompanyName { get; set; } = null!;

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? Industry { get; set; }

    public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
