using System;
using System.Collections.Generic;

namespace C500Hemis.Models.DM;

public partial class DmDanToc
{
    public int IdDanToc { get; set; }

    public string? DanToc { get; set; }

    public virtual ICollection<TbNguoi> TbNguois { get; set; } = new List<TbNguoi>();
}
