using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbKyLuatCanBo
{
    [Display(Name = "ID kỷ luật")]
    public int IdKyLuatCanBo { get; set; }

    [Display(Name = "Họ và tên cán bộ")]
    public int? IdCanBo { get; set; }

    [Display(Name = "Hình thức kỷ luật")]
    public int? IdLoaiKyLuat { get; set; }

    [Display(Name = "Lý do kỷ luật")]
    [StringLength(200, ErrorMessage = "{0} không tối vượt quá {1}")]
    public string? LyDo { get; set; }

    [Display(Name = "Cấp quyết định")]
    public int? IdCapQuyetDinh { get; set; }

    [Display(Name = "Ngày nhận quyết định")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateOnly? NgayThangNamQuyetDinh { get; set; }

    [Display(Name = "Số quyết định")]
    public string? SoQuyetDinh { get; set; }

    [Display(Name = "Năm bị kỷ luật")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy}")]
    public DateOnly? NamBiKyLuat { get; set; }

    [Display(Name = "Họ và Tên")]
    public virtual TbCanBo? IdCanBoNavigation { get; set; }

    [Display(Name = "Cấp QĐ")]
    public virtual DmCapKhenThuong? IdCapQuyetDinhNavigation { get; set; }

    [Display(Name = "Hình thức kỷ luật")]
    public virtual DmLoaiKyLuat? IdLoaiKyLuatNavigation { get; set; }
}
