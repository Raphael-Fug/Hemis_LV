using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbThongTinViecLamSauTotNghiep
{
    [Display(Name = "ID Việc Làm Sau Tốt Nghiệp")]
    public int IdThongTinViecLamSauTotNghiep { get; set; }

    [Display(Name = "ID Học Viên")]
    public int? IdHocVien { get; set; }

    [Display(Name = "Tên Đơn Vị Cấp Bằng")]
    public string? TenDonViCapBang { get; set; }

    [Display(Name = "Đơn Vị Tuyển Dụng")]

    public string? DonViTuyenDung { get; set; }

    [Display(Name = "Hình Thức Tuyển Dụng")]
    public int? IdHinhThucTuyenDung { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]

    [Display(Name = "Thời Gian Tuyển Dụng")]

    public DateOnly? ThoiGianTuyenDung { get; set; }

    [Display(Name = "Id Vị Trí Việc Làm")]
    public int? IdViTriViecLam { get; set; }

    [Display(Name = "Mức Lương Khởi Điểm")]

    public int? MucLuongKhoiDiem { get; set; }

    [Display(Name = "ID Hình Thức Tuyển Dụng")]

    public virtual DmHinhThucTuyenDung? IdHinhThucTuyenDungNavigation { get; set; }

    [Display(Name = "ID Học Viên")]
    public virtual TbHocVien? IdHocVienNavigation { get; set; }

    [Display(Name = "ID Vị Trí Việc Làm")]
    public virtual DmViTriViecLam? IdViTriViecLamNavigation { get; set; }
}
