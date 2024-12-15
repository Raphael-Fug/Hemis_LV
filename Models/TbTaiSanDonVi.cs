using System;
using System.Collections.Generic;

namespace C500Hemis.Models;

public partial class TbTaiSanDonVi
{
    public int IdTaiSanDonVi { get; set; }

    public string? MaLoaiTaiSan { get; set; }

    public string? TenLoaiTaiSan { get; set; }

    public string? MoTa { get; set; }

    public string? NamTaiChinh { get; set; }

    public virtual ICollection<TbChiTietTaiSanDonVi> TbChiTietTaiSanDonVis { get; set; } = new List<TbChiTietTaiSanDonVi>();
}
