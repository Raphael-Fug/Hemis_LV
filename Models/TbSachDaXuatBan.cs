using System;
using System.Collections.Generic;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbSachDaXuatBan
{
    public int IdSachDaXuatBan { get; set; }

    public int? IdNhiemVuKhcn { get; set; }

    public string? MaSach { get; set; }

    public string? TenSach { get; set; }

    public int? IdLoaiSachTapChi { get; set; }

    public string? MaChuanIsbn { get; set; }

    public int? SoTrang { get; set; }

    public string? Nxb { get; set; }

    public string? NamXuatBan { get; set; }

    public string? NamViet { get; set; }

    public int? IdDangTaiLieu { get; set; }

    public virtual DmDangTaiLieu? IdDangTaiLieuNavigation { get; set; }

    public virtual DmLoaiSachTapChi? IdLoaiSachTapChiNavigation { get; set; }

    public virtual TbNhiemVuKhcn? IdNhiemVuKhcnNavigation { get; set; }
}
