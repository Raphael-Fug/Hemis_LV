using System;
using System.Collections.Generic;

namespace C500Hemis.Models.DM;

public partial class DmPhanCapNhiemVu
{
    public int IdPhanCapNhiemVu { get; set; }

    public string? PhanCapNhiemVu { get; set; }

    public virtual ICollection<TbHoatDongBaoVeMoiTruong> TbHoatDongBaoVeMoiTruongs { get; set; } = new List<TbHoatDongBaoVeMoiTruong>();

    public virtual ICollection<TbNhiemVuKhcn> TbNhiemVuKhcns { get; set; } = new List<TbNhiemVuKhcn>();
}
