using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CRMDataModel.Models;

public class Project
{
    public int ProjectId { get; set; }
    public int ClientId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Status { get; set; }

    [JsonIgnore]
    public Client Client { get; set; }
}
