using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CRMDataModel.Models;

public class Contact
{
    public int ContactId { get; set; }
    public int ClientId { get; set; }
    public string ContactName { get; set; }
    public string Position { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    [JsonIgnore]
    public Client Client { get; set; }
}
