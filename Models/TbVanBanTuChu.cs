using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace C500Hemis.Models;

public partial class TbVanBanTuChu
{
    [DisplayName("MÃ VĂN BẢN TỪ CHỮ")]
    [Range(1, int.MaxValue, ErrorMessage = "Chỉ được phép nhập số dương.")]
    public int IdVanBanTuChu { get; set; }
    [DisplayName("LOẠI VĂN BẢN")]
    public string? LoaiVanBan { get; set; }
    [DisplayName("NỘI DUNG VĂN BẢN")]
    public string? NoiDungVanBan { get; set; }
    [DisplayName("QUYẾT ĐỊNH BAN HÀNH")]
    public string? QuyetDinhBanHanh { get; set; }
    [DisplayName("CƠ QUAN QUYẾT ĐỊNH BAN HÀNH")]
    public string? CoQuanQuyetDinhBanHanh { get; set; }
}
