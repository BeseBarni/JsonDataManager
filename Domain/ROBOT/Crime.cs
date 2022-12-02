using System;
using System.Collections.Generic;

namespace Domain.ROBOT;

public partial class Crime
{
    public int c_id { get; set; }

    public string? type { get; set; }

    public string? neighbourhood { get; set; }

    public int? day { get; set; }

    public int? month { get; set; }

    public int? year { get; set; }

    public int? r_id { get; set; }

    public virtual Robots? r_idNavigation { get; set; }
}
