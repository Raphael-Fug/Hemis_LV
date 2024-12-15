using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbHoatDongBaoVeMoiTruong
{
    [Display(Name = "Id Hoạt Động Bảo Vệ Môi Trường")]
    [Range(1, int.MaxValue, ErrorMessage = "Id Hoạt Động Bảo Vệ Môi Trường phải là số dương.")] // xác định giới hạn giá trị cho id là từ 1 đến max int
    public int IdHoatDongBaoVeMoiTruong { get; set; }
    [Display(Name = "Id Nhiệm Vụ KHCN")]
    public int? IdNhiemVuKhcn { get; set; }
    [Display(Name = "Tên Nhiệm Vụ")]
    [Required(ErrorMessage = "Tên Nhiệm vụ là bắt buộc.")] // đánh dấu thuộc tính này phải có giá trị
    [StringLength(200, ErrorMessage = "Tên Nhiệm Vụ không được vượt quá 200 ký tự.")] // đặt giới hạn độ dài của chuỏi ký tự
    public string TenNhiemVuBvmt { get; set; }
    [Display(Name = "Cấp Quản Lý Nhiệm Vụ")]
    public int? IdCapQuanLyNhiemVu { get; set; }
    [Display(Name = "Cơ Quan Chủ Quản")]
    public int? IdCoQuanChuQuan { get; set; }
    [Display(Name = "Cơ Quan Chủ Trì")]
    public string? CoQuanChuTri { get; set; }
    [Display(Name = "Loại Nhiệm Vụ Bảo Vệ Môi Trường")]
    public int? IdLoaiNhiemVuBaoVeMoiTruong { get; set; }
    [Display(Name = "Tổng Kinh Phí Của Nhiệm Vụ")]
    public int? TongKinhPhiCuaNhiemVu { get; set; }
    [Display(Name = "Nguồn Kinh Phí")]
    public int? IdNguonKinhPhi { get; set; }
    [Display(Name = "Thời Gian Bắt Đầu")]
    [DataType(DataType.Date)]//xác định giá trị time là ngày ko gồm giây phút giờ
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")] // hiển thị dưới dạng ngày tháng năm
    public DateOnly? ThoiGianBatDau { get; set; }
    [Display(Name = "Thời GIan Kết Thúc")]
    [DataType(DataType.Date)] //xác định giá trị time là ngày ko gồm giây phút giờ
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")] // hiển thị dưới dạng ngày tháng năm
    public DateOnly? ThoiGianKetThuc { get; set; }
    [Display(Name = "Đánh Giá Kết Quả Nhiệm Vụ")]
    public string? DanhGiaKetQuaNhiemVu { get; set; }
    [Display(Name = "Sản Phẩm Chính Của Nhiệm Vụ")]
    public string? SanPhamChinhCuaNhiemVu { get; set; }
    [Display(Name = "Đơn Vị Thực Hiện Lưu Trữ Sản Phẩm")]
    public string? DonViThucHienLuuTruSanPham { get; set; }
    [Display(Name = "Tình Trạng Nhiệm Vụ")]
    public int? IdTinhTrangNhiemVu { get; set; }
    [Display(Name = "Cấp Quản Lý Nhiệm Vụ Navigation")]
    public virtual DmPhanCapNhiemVu? IdCapQuanLyNhiemVuNavigation { get; set; }
    [Display(Name = "Cơ Quan Chủ Quản Navigation")]
    public virtual DmCoQuanChuQuan? IdCoQuanChuQuanNavigation { get; set; }
    [Display(Name = "Loại Nhiệm Vụ Bảo Vệ Môi Trường Navigation")]
    public virtual DmLoaiNhiemVuBaoVeMoiTruong? IdLoaiNhiemVuBaoVeMoiTruongNavigation { get; set; }
    [Display(Name = "Nguồn Kinh Phí Navigation")]
    public virtual DmNguonKinhPhi? IdNguonKinhPhiNavigation { get; set; }
    [Display(Name = "Nhiệm Vụ KHCN Navigation")]
    public virtual TbNhiemVuKhcn? IdNhiemVuKhcnNavigation { get; set; }
    [Display(Name = "Tình Trạng Nhiệm Vụ Navigation")]
    public virtual DmTinhTrangNhiemVu? IdTinhTrangNhiemVuNavigation { get; set; }
}
