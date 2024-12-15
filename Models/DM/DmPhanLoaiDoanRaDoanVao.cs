using System;
using System.Collections.Generic;

namespace C500Hemis.Models.DM;

public partial class DmPhanLoaiDoanRaDoanVao
{
    public int IdPhanLoaiDoanRaDoanVao { get; set; }

    public string? PhanLoaiDoanRaDoanVao { get; set; }

    public virtual ICollection<TbDoanCongTac> TbDoanCongTacs { get; set; } = new List<TbDoanCongTac>();
}
