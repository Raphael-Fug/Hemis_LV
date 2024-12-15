using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbDauMoiLienHe
{
    [Display(Name = "ID")]
    public int IdDauMoiLienHe { get; set; }

    [Display(Name = "Loại đầu mối liên hệ")]
    public int? IdLoaiDauMoiLienHe { get; set; }

    [Display(Name = "Số điện thoại")]
    public string? SoDienThoai { get; set; }

    [Display(Name = "E-mail")]
    public string? Email { get; set; }

    [Display(Name = "Loại đầu mối liên hệ")]
    public virtual DmDauMoiLienHe? IdLoaiDauMoiLienHeNavigation { get; set; }
}
