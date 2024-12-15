using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace C500Hemis.Models;

public partial class TbThongTinNguoiHocGdtc
{
    [Display(Name = "Id thông tin người học GDTC")]
    public int IdThongTinNguoiHocGdtc { get; set; }
    [Display(Name = "Id học viên")]
    public int IdHocVien { get; set; }

    [Display(Name = "Kết quả học tập ")]
    public string? KetQuaHocTap { get; set; }

    [Display(Name = "Tiêu chuẩn đánh giá xếp loại thể lực ")]
    public string? TieuChuanDanhGiaXepLoaiTheLuc { get; set; }

    [Display(Name = "Id học viên")]
    public virtual TbHocVien? IdHocVienNavigation { get; set; }
}
