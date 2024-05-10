using System;
using System.Collections.Generic;

namespace LgbtqResources.Data.Models;

public partial class Subcatagory
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int CatagoryId { get; set; }

    public string? Description { get; set; }

    public virtual Catagory Catagory { get; set; } = null!;

    public virtual ICollection<Resource> Resources { get; set; } = new List<Resource>();
}
