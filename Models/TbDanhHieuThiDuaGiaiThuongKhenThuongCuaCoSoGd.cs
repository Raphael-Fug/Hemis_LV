using System;
using System.Collections.Generic;
using System.ComponentModel;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd
{
    [DisplayName(displayName: "Danh hiệu thi đua, danh hiệu vinh dự và giải thưởng nhà nước, hình thức khen thưởng")]
    public int IdDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd { get; set; }
    [DisplayName(displayName: "loại danh hiệu thi đua, giải thưởng, khen thưởng")]
    public int? IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong { get; set; }
    [DisplayName(displayName: "Danh hiệu thi đua giải thưởng, khen thưởng")]
    public int? IdDanhHieuThiDuaGiaiThuongKhenThuong { get; set; }
    [DisplayName(displayName: "Số quyết định khen thưởng")]
    public string? SoQuyetDinhKhenThuong { get; set; }
    [DisplayName(displayName: "Phương thức khen thưởng")]
    public int? IdPhuongThucKhenThuong { get; set; }
    [DisplayName(displayName: "Năm khen thưởng")]
    public string? NamKhenThuong { get; set; }
    [DisplayName(displayName: "Cấp khen thưởng")]
    public int? IdCapKhenThuong { get; set; }
    [DisplayName(displayName: "Cấp khen thưởng")]
    public virtual DmCapKhenThuong? IdCapKhenThuongNavigation { get; set; }
    [DisplayName(displayName: " Danh hiệu thi đua, danh hiệu vinh dự và giải thưởng nhà nước, hình thức khen thưởng")]
    public virtual DmThiDuaGiaiThuongKhenThuong? IdDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGdNavigation { get; set; } = null!;
    [DisplayName(displayName: " Loại danh hiệu thi đua giải thưởng khen thưởng")]
    public virtual DmLoaiDanhHieuThiDuaGiaiThuongKhenThuong? IdLoaiDanhHieuThiDuaGiaiThuongKhenThuongNavigation { get; set; }
    [DisplayName(displayName: " Phương thức khen thưởng")]
    public virtual DmPhuongThucKhenThuong? IdPhuongThucKhenThuongNavigation { get; set; }
}