using System;
using System.Collections.Generic;

namespace LgbtqResources.Data.Models;

public partial class Resource
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int SubcatagoryId { get; set; }

    public string? Description { get; set; }

    public string? Subtitle { get; set; }

    public string? Url { get; set; }

    public virtual Subcatagory Subcatagory { get; set; } = null!;
}
