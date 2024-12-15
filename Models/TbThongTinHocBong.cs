using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbThongTinHocBong
{
    [Display(Name = "ID Thông tin học bổng")]
    public int IdThongTinHocBong { get; set; }

    [Display(Name = "ID học viên")]
    public int? IdHocVien { get; set; }

    [Display(Name = "Tên học bổng")]
    public string? TenHocBong { get; set; }

    [Display(Name = "Đơn vị tài trợ")]
    public string? DonViTaiTro { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]

    [Display(Name = "Thời gian trao tặng học bổng")]
    public DateOnly? ThoiGianTraoTangHocBong { get; set; }

    [Display(Name = "ID loại học bổng")]
    public int? IdLoaiHocBong { get; set; }

    [Display(Name = "Giá trị học bổng")]
    public int? GiaTriHocBong { get; set; }

    [Display(Name = "Học viên")]
    public virtual TbHocVien? IdHocVienNavigation { get; set; }

    [Display(Name = "Loại học bổng")]
    public virtual DmLoaiHocBong? IdLoaiHocBongNavigation { get; set; }
}
