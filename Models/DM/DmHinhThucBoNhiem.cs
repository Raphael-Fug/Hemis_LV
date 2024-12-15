using System;
using System.Collections.Generic;

namespace C500Hemis.Models.DM;

public partial class DmHinhThucBoNhiem
{
    public int IdHinhThucBoNhiem { get; set; }

    public string? HinhThucBoNhiem { get; set; }

    public virtual ICollection<TbDonViCongTacCuaCanBo> TbDonViCongTacCuaCanBos { get; set; } = new List<TbDonViCongTacCuaCanBo>();
}
