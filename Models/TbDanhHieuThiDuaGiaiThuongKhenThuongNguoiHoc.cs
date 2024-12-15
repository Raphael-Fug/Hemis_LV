using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using C500Hemis.Models.DM;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;

namespace C500Hemis.Models;

public partial class TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc
{
    [Display(Name = "Danh hiệu thi đua giải thưởng khen thưởng người học")]
    public int IdDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc { get; set; }
    [Display(Name = "Học viên")]
    public int? IdHocVien { get; set; }
    [Display(Name = "Loại danh hiệu thi đua giải thưởng khen thưởng")]
    public int? IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong { get; set; }
    [Display(Name = "Danh hiệu thi đua giải thưởng khen thưởng")]
    public int? IdDanhHieuThiDuaGiaiThuongKhenThuong { get; set; }
    [Display(Name = "Số quyết định khen thưởng")]
    public string? SoQuyetDinhKhenThuong { get; set; }
    [Display(Name = "Phương thức khen thưởng")]
    public int? IdPhuongThucKhenThuong { get; set; }
    [Display(Name = "Năm khen thưởng")]
    public string? NamKhenThuong { get; set; }
    [Display(Name = "Cấp khen thưởng")]
    public int? IdCapKhenThuong { get; set; }
    [Display(Name = "Cấp khen thưởng")]
    public virtual DmCapKhenThuong? IdCapKhenThuongNavigation { get; set; }
    [Display(Name = "Danh hiệu thi đua giải thưởng khen thưởng")]
    public virtual DmThiDuaGiaiThuongKhenThuong? IdDanhHieuThiDuaGiaiThuongKhenThuongNavigation { get; set; }
    [Display(Name = "Học viên")]
    public virtual TbHocVien? IdHocVienNavigation { get; set; }
    [Display(Name = "Loại danh hiệu thi đua giải thưởng khen thưởng")]
    public virtual DmLoaiDanhHieuThiDuaGiaiThuongKhenThuong? IdLoaiDanhHieuThiDuaGiaiThuongKhenThuongNavigation { get; set; }
    [Display(Name = "Phương thức khen thưởng")]
    public virtual DmPhuongThucKhenThuong? IdPhuongThucKhenThuongNavigation { get; set; }
}
