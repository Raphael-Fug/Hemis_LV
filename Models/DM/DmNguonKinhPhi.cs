using System;
using System.Collections.Generic;

namespace C500Hemis.Models.DM;

public partial class DmNguonKinhPhi
{
    public int IdNguonKinhPhi { get; set; }

    public string? NguonKinhPhi { get; set; }

    public virtual ICollection<TbHoatDongBaoVeMoiTruong> TbHoatDongBaoVeMoiTruongs { get; set; } = new List<TbHoatDongBaoVeMoiTruong>();

    public virtual ICollection<TbHoiThaoHoiNghi> TbHoiThaoHoiNghis { get; set; } = new List<TbHoiThaoHoiNghi>();

    public virtual ICollection<TbKhoaBoiDuongTapHuanThamGiaCuaCanBo> TbKhoaBoiDuongTapHuanThamGiaCuaCanBos { get; set; } = new List<TbKhoaBoiDuongTapHuanThamGiaCuaCanBo>();

    public virtual ICollection<TbNhiemVuKhcn> TbNhiemVuKhcns { get; set; } = new List<TbNhiemVuKhcn>();
}
