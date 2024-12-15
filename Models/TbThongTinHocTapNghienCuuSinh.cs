using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbThongTinHocTapNghienCuuSinh
{
    [Display(Name = "ID Thông tin học tập nghiên cứu sinh")]
    public int IdThongTinHocTapNghienCuuSinh { get; set; }

    [Display(Name = "Tên học viên")]
    public int? IdHocVien { get; set; }

    [Display(Name = "Đối tượng đầu vào")]
    public int? IdDoiTuongDauVao { get; set; }

    [Display(Name = "Sinh viên năm")]
    public int? IdSinhVienNam { get; set; }

    [Display(Name = "Chương trình đào tạo")]
    public int? IdChuongTrinhDaoTao { get; set; }

    [Display(Name = "Loại hình đào tạo")]
    public int? IdLoaiHinhDaoTao { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy}")]

    [Display(Name = "Đào tạo từ năm")]
    public DateOnly? DaoTaoTuNam { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy}")]

    [Display(Name = "Đào tạo đến năm")]
    public DateOnly? DaoTaoDenNam { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

    [Display(Name = "Ngày nhập học")]
    public DateOnly? NgayNhapHoc { get; set; }

    [Display(Name = "Trạng thái học")]
    public int? IdTrangThaiHoc { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

    [Display(Name = "Ngày chuyển trạng thái")]
    public DateOnly? NgayChuyenTrangThai { get; set; }

    [Display(Name = "Số quyết định thôi học")]
    public string? SoQuyetDinhThoiHoc { get; set; }

    [Display(Name = "Tên luận văn")]
    public string? TenLuanVan { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

    [Display(Name = "Ngày báo về cấp trường")]
    public DateOnly? NgayBaoVeCapTruong { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

    [Display(Name = "Ngày báo về cấp cơ sở")]
    public DateOnly? NgayBaoVeCapCoSo { get; set; }

    [Display(Name = "Quy chuẩn người hướng dẫn")]
    public string? QuyChuanNguoiHuongDan { get; set; }

    [Display(Name = "Người hướng dẫn chính")]
    public int? IdNguoiHuongDanChinh { get; set; }

    [Display(Name = "Người hướng dẫn phụ")]
    public int? IdNguoiHuongDanPhu { get; set; }

    [Display(Name = "Số quyết định công nhận")]
    public string? SoQuyetDinhCongNhan { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

    [Display(Name = "Ngày quyết định công nhận")]
    public DateOnly? NgayQuyetDinhCongNhan { get; set; }

    [Display(Name = "Loại tốt nghiệp")]
    public int? IdLoaiTotNghiep { get; set; }

    [Display(Name = "Số quyết định thành lập hội đồng báo về cấp cơ sở")]
    public string? SoQuyetDinhThanhLapHoiDongBaoVeCapCoSo { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

    [Display(Name = "Ngày quyết định thành lập hội đồng báo về cấp cơ sở")]
    public DateOnly? NgayQuyetDinhThanhLapHoiDongBaoVeCapCoSo { get; set; }

    [Display(Name = "Số quyết định thành lập hội đồng bảo vệ cấp trường")]
    public string? SoQuyetDinhThanhLapHoiDongBaoVeCapTruong { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

    [Display(Name = "Ngày quyết định thành lập hội đồng báo về cấp trường")]
    public DateOnly? NgayQuyetDinhThanhLapHoiDongBaoVeCapTruong { get; set; }

    [Display(Name = "Chương trình đào tạo")]
    public virtual DmChuongTrinhDaoTao? IdChuongTrinhDaoTaoNavigation { get; set; }

    [Display(Name = "Đối tượng đầu vào")]
    public virtual DmDoiTuongDauVao? IdDoiTuongDauVaoNavigation { get; set; }

    [Display(Name = "Tên học viên")]
    public virtual TbHocVien? IdHocVienNavigation { get; set; }

    [Display(Name = "Loại Hình đào tạo")]
    public virtual DmLoaiHinhDaoTao? IdLoaiHinhDaoTaoNavigation { get; set; }

    [Display(Name = "Loại tốt nghiệp")]
    public virtual DmLoaiTotNghiep? IdLoaiTotNghiepNavigation { get; set; }

    [Display(Name = "Người hướng dẫn chính")]
    public virtual TbCanBo? IdNguoiHuongDanChinhNavigation { get; set; }

    [Display(Name = "Người hướng dẫn phụ")]
    public virtual TbCanBo? IdNguoiHuongDanPhuNavigation { get; set; }

    [Display(Name = "Sinh viên năm")]
    public virtual DmSinhVienNam? IdSinhVienNamNavigation { get; set; }

    [Display(Name = "Trạng thái học viên")]
    public virtual DmTrangThaiHoc? IdTrangThaiHocNavigation { get; set; }
}