using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;
//Bùi VĂN ĐẠT

public partial class TbDanhSachVanBangChungChi
{
    [Display(Name = "Danh Sách")]
    public int IdDanhSachVanBangChungChi { get; set; }

    [Display(Name = "Học Viên")]
    public int? IdHocVien { get; set; }

    [Display(Name = "Tên Văn Bằng")]
    public string? TenVanBang { get; set; }

    [Display(Name = "Chương Trình Đào Tạo")]
    public int? IdChuongTrinhDaoTao { get; set; }

    [Display(Name = "Đơn Vị Cấp Bằng")]
    public string? TenDonViBangCap { get; set; }

    [Display(Name = "Ngày Cấp")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateOnly? NgayCap { get; set; }

    [Display(Name = "Năm Tốt Nghiệp")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy}")]
    public string? NamTotNghiep { get; set; }

    [Display(Name = "Loại Bằng")]
    public int? IdLoaiTotNghiep { get; set; }

    [Display(Name = "Số QĐ")]
    public string? SoQuyetDinhCongNhanTotNghiep { get; set; }

    [Display(Name = "Ngày Nhận QĐ")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateOnly? NgayQuyetDinhCongNhanTotNghiep { get; set; }

    [Display(Name = "Số Hiệu VB")]
    public string? SoHieuVanBang { get; set; }

    [Display(Name = "Số Vào Sổ Cấp")]
    public string? SoVaoSoGocCapVanBang { get; set; }

    [Display(Name = "Số QĐHĐ")]
    public string? SoQuyetDinhThanhLapHoiDongDanhGiaLuanVan { get; set; }

    [Display(Name = "Ngày Bảo Vệ")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateOnly? NgayBaoVe { get; set; }

    [Display(Name = "Tệp Đính Kèm")]
    public string? LinkFileScan { get; set; }

    [Display(Name = "Tên Học Viên")]
    public virtual TbHocVien? IdHocVienNavigation { get; set; }

    [Display(Name = "Loại Tốt Nghiệp")]
    public virtual DmLoaiTotNghiep? IdLoaiTotNghiepNavigation { get; set; }

}
