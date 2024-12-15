using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using C500Hemis.Models.DM;
using Microsoft.Build.Framework;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;




namespace C500Hemis.Models;

public partial class TbTaiSanTriTue
{

    [DisplayName("ID")]
    [Required(ErrorMessage = "dữ liệu này không được để trống")]
    [Range(0, int.MaxValue, ErrorMessage = "Giá trị không thể là số âm.")]
    public int IdTaiSanTriTue { get; set; }//primary key

    [DisplayName("Nhiệm Vụ KHCN")]
    public int? IdNhiemVuKhcn { get; set; }

    [DisplayName("Loại Tài Sản Trí Tuệ")]
    public int? IdLoaiTaiSanTriTue { get; set; }

    [DisplayName("Mã Giải Pháp Sáng Chế")]

    public string? MaGiaiPhapSangChe { get; set; }
    [MaxLength(60)]
    [DisplayName("Tên Tài Sản Trí Tuệ")]
    public string? TenTaiSanTriTue { get; set; }
    [DisplayName("Tổ Chức Cấp Bằng Giấy Chứng Nhận")]
    public string? ToChucCapBangGiayChungNhan { get; set; }

    [DisplayName("Ngày Cấp Bằng Giấy Chứng Nhận")]
    //định dạng dd/MM/yyyy
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateOnly? NgayCapBangGiayChungNhan { get; set; }
    [DisplayName("Tổ Chức Cấp Bằng")]
    public string? ToChucCapBang { get; set; }
    [DisplayName("Số Bằng")]
    [Range(0, int.MaxValue, ErrorMessage = "Giá trị không thể là số âm.")]
    public int? SoBang { get; set; }
    [DisplayName("Ngày Cấp")]
    //định dạng dd/MM/yyyy
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateOnly? NgayCap { get; set; }
    [DisplayName("Số Đơn")]
    [Range(0, int.MaxValue, ErrorMessage = "Giá trị không thể là số âm.")]
    public int? SoDon { get; set; }
    [DisplayName("Ngày Nộp Đơn ")]
    //định dạng dd/MM/yyyy
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateOnly? NgayNopDon { get; set; }
    [DisplayName("Quyết Định Cấp Bằng Giấy Chứng Nhận")]
    public string? QuyetDinhCapBangGiayChungNhan { get; set; }
    [DisplayName("Công Bố Bằng")]
    public string? CongBoBang { get; set; }
    [DisplayName("IPC")]
    public string? Ipc { get; set; }
    [MaxLength(60)]
    [DisplayName("Chủ Sở Hữu")]
    public string? ChuSoHuu { get; set; }
    [DisplayName("Tác Giả Sáng Chế Giải Pháp")]
    public string? TacGiaSangCheGiaiPhap { get; set; }
    [DisplayName("Tóm Tắt Nội Dung Tài Sản Trí Tuệ")]
    public string? TomTatNoiDungTaiSanTriTue { get; set; }
    [DisplayName("Người Chủ Trì")]
    public string? NguoiChuTri { get; set; }
    [DisplayName("Năm Được Chấp Nhận Đơn Hợp Lệ")]
    [Range(0, int.MaxValue, ErrorMessage = "Giá trị không thể là số âm.")]
    public int? NamDuocChapNhanDonHopLe { get; set; }

    [DisplayName("ID Loại Tài Sản Trí Tuệ Navigation")]

    public virtual DmLoaiTaiSanTriTue? IdLoaiTaiSanTriTueNavigation { get; set; }//foreign key

    [DisplayName("ID Nhiệm Vụ KHCN Navigation")]

    public virtual TbNhiemVuKhcn? IdNhiemVuKhcnNavigation { get; set; }//foreign key
}
