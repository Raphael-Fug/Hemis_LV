using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbThongTinViPham
{
    [Display(Name = "Id thông tin vi phạm")]

    public int IdThongTinViPham { get; set; }

    [Display(Name = "Id học viên")]
    public int? IdHocVien { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]

    [Display(Name = "Thời gian vi phạm")]

    public DateOnly? ThoiGianViPham { get; set; }

    [Display(Name = "Nội dung vi phạm")]
    public string? NoiDungViPham { get; set; }

    [Display(Name = "Hình thức xử lí")]

    public string? HinhThucXuLy { get; set; }

    [Display(Name = "Id loại vi phạm")]
    public int? IdLoaiViPham { get; set; }

    [Display(Name = "Id học viên")]
    public virtual TbHocVien? IdHocVienNavigation { get; set; }

    [Display(Name = "Id loại vi phạm")]
    public virtual DmLoaiViPham? IdLoaiViPhamNavigation { get; set; }
}
