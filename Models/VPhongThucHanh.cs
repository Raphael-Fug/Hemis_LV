using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace C500Hemis.Models;

public partial class VPhongThucHanh
{
    
    public string? MaCongTrinh { get; set; }
    [Display(Name ="Lĩnh vực nghiên cứu")]
    public string? LinhVucNghienCuu { get; set; }
    [Display(Name = "Mức độ đáp ứng nhu cầu NCKH")]
    public string? MucDoDapUngNhuCauNckh { get; set; }
    [Display(Name = "Năm đưa vào sử dụng ")]
    public string? NamDuaVaoSuDung { get; set; }
}
