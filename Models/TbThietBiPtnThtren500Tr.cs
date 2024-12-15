using System;
using System.Collections.Generic;
using System.ComponentModel;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbThietBiPtnThtren500Tr
{
    public int IdThietBiPtnTh { get; set; }
    [DisplayName("Tên thiết bị")]

    public string? MaThietBi { get; set; }
    [DisplayName("Mã thiết bị")]

    public int? IdCongTrinhCsvc { get; set; }
    [DisplayName("Mã công trình CSVC")]

    public string? TenThietBi { get; set; }
    [DisplayName("Tên thiết bị")]

    public string? NamSanXuat { get; set; }
    [DisplayName("Năm sản xuất")]

    public int? IdQuocGiaXuatXu { get; set; }
    [DisplayName("Xuất xứ")]

    public string? HangSanXuat { get; set; }
    [DisplayName("Hãng sản xuất")]

    public int? SoLuongThietBiCungLoai { get; set; }
    [DisplayName("Số lượng thiết bị cùng loại")]

    public string? NamDuaVaoSuDung { get; set; }
    [DisplayName("Năm đưa vào sử dụng")]

    public virtual TbCongTrinhCoSoVatChat? IdCongTrinhCsvcNavigation { get; set; }
    [DisplayName("Công trình cơ sở vật chất")]

    public virtual DmQuocTich? IdQuocGiaXuatXuNavigation { get; set; }
}