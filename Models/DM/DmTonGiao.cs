using System;
using System.Collections.Generic;

namespace C500Hemis.Models.DM;

public partial class DmTonGiao
{
    public int IdTonGiao { get; set; }

    public string? TonGiao { get; set; }

    public virtual ICollection<TbNguoi> TbNguois { get; set; } = new List<TbNguoi>();
}
