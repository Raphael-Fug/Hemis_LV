using System;
using System.Collections.Generic;

namespace C500Hemis.Models.DM;

public partial class DmLinhVucDaoTao
{
    public int IdLinhVucDaoTao { get; set; }

    public string? LinhVucDaoTao { get; set; }

    public virtual ICollection<DmKhoiNganhLinhVucDaoTao> DmKhoiNganhLinhVucDaoTaos { get; set; } = new List<DmKhoiNganhLinhVucDaoTao>();

    public virtual ICollection<DmLinhVucNhomNganh> DmLinhVucNhomNganhs { get; set; } = new List<DmLinhVucNhomNganh>();

    public virtual ICollection<TbNhomNganhDaoTao> TbNhomNganhDaoTaos { get; set; } = new List<TbNhomNganhDaoTao>();

    public virtual ICollection<TbThongTinLinhVucDaoTao> TbThongTinLinhVucDaoTaos { get; set; } = new List<TbThongTinLinhVucDaoTao>();
}
