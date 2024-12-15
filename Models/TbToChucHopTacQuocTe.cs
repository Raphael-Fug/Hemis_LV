using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbToChucHopTacQuocTe
{
    [Display(Name = "Tổ chức hợp tác")]
    public int IdToChucHopTacQuocTe { get; set; }

    [Display(Name = "Mã số hợp tác")]
    public string? MaHopTac { get; set; }

    [Display(Name = "Tên tổ chức")]
    public string? TenToChuc { get; set; }

    [Display(Name = "Mã quốc gia")]
    public int? IdQuocGia { get; set; }

    [Display(Name = "Thông tin Nội dung")]
    public string? NoiDung { get; set; }

    [Display(Name = "Thời gian ký kết")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? ThoiGianKyKet { get; set; }

    [Display(Name = "Kết quả hợp tác")]
    public string? KetQuaHopTac { get; set; }

    [Display(Name = "Loại tổ chức")]
    public string? LoaiToChuc { get; set; }

    public virtual DmQuocTich? IdQuocGiaNavigation { get; set; }

    public virtual ICollection<TbThongTinHopTac> TbThongTinHopTacs { get; set; } = new List<TbThongTinHopTac>();
}
