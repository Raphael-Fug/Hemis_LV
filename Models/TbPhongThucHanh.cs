using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbPhongThucHanh
{
    [DisplayName("STT ")]
    [Range(1, int.MaxValue, ErrorMessage = "STT phải là số dương.")]
    public int IdPhongThucHanh { get; set; }
    [DisplayName("STT Công trình csvc")]
    public int? IdCongTrinhCsvc { get; set; }
    [DisplayName("STT Lĩnh vực")]
    public int? IdLinhVuc { get; set; }
    [DisplayName("Mức độ đáp ứng nhu cầu NCKH ")]
    public string? MucDoDapUngNhuCauNckh { get; set; }
    [DisplayName("Năm đưa vào sử dụng ")]
    public string? NamDuaVaoSuDung { get; set; }
    [DisplayName("Công trình CSVC ")]
    public virtual TbCongTrinhCoSoVatChat? IdCongTrinhCsvcNavigation { get; set; }
    [DisplayName("Lĩnh vực ")]
    public virtual DmLinhVucNghienCuu? IdLinhVucNavigation { get; set; }
}