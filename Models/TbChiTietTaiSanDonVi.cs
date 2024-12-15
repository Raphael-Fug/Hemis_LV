using System;
using System.Collections.Generic;
using System.ComponentModel;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbChiTietTaiSanDonVi
{
    public int IdChiTietTaiSanDonVi { get; set; }
    [DisplayName(displayName: "Tài Sản Đơn Vị")]

    public int? IdTaiSanDonVi { get; set; }
    [DisplayName(displayName: "Mã Tài Sản")]

    public string? MaTaiSan { get; set; }
    [DisplayName(displayName: "Tên Tài Sản")]

    public string? TenTaiSan { get; set; }
    [DisplayName(displayName: "Nguyên Giá")]

    public int? NguyenGia { get; set; }
    [DisplayName(displayName: "Tình Trạng Thiết Bị")]

    public int? IdTinhTrangThietBi { get; set; }
    [DisplayName(displayName: "Hình Thức Sở Hữu")]

    public int? IdChuSoHuu { get; set; }

    public virtual DmChuSoHuu? IdChuSoHuuNavigation { get; set; }

    public virtual TbTaiSanDonVi? IdTaiSanDonViNavigation { get; set; }

    public virtual DmTinhTrangThietBi? IdTinhTrangThietBiNavigation { get; set; }
}
