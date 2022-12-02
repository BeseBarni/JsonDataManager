using System;
using System.Collections.Generic;

namespace Domain.ROBOT;

public partial class Robots
{
    public int r_id { get; set; }

    public string? title { get; set; }

    public string? first { get; set; }

    public string? last { get; set; }

    public string? gender { get; set; }

    public virtual ICollection<Crime> Crime { get; } = new List<Crime>();
}
