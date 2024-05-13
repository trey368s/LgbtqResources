using System;
using System.Collections.Generic;

namespace LgbtqResources.Data.Models;

public partial class Catagory
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int GroupId { get; set; }

    public string? Description { get; set; }

    public int? Priority { get; set; }

    public virtual Group Group { get; set; } = null!;

    public virtual ICollection<Subcatagory> Subcatagories { get; set; } = new List<Subcatagory>();
}
