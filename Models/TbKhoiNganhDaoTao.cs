using System;
using System.Collections.Generic;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbKhoiNganhDaoTao
{
    public int IdKhoiNganhDaoTao { get; set; }

    public string? KhoiNganhDaoTao { get; set; }

    public virtual ICollection<DmKhoiNganhLinhVucDaoTao> DmKhoiNganhLinhVucDaoTaos { get; set; } = new List<DmKhoiNganhLinhVucDaoTao>();

    public virtual ICollection<TbThongTinLinhVucDaoTao> TbThongTinLinhVucDaoTaos { get; set; } = new List<TbThongTinLinhVucDaoTao>();
}
