using System;
using System.Collections.Generic;

namespace LgbtqResources.Data.Models;

public partial class Group
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int? Priority { get; set; }

    public virtual ICollection<Catagory> Catagories { get; set; } = new List<Catagory>();
}
