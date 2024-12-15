using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace C500Hemis.Models;

public partial class TbKhoaHoc
{
    [DisplayName("MÃ KHOÁ HỌC")]
    [Range(1, int.MaxValue, ErrorMessage = "Chỉ được phép nhập số dương.")]
    public int IdKhoaHoc { get; set; }
    [DisplayName("TỪ NĂM")]
    
    public string? TuNam { get; set; }
    [DisplayName("ĐẾN NĂM")]
    public string? DenNam { get; set; }
}
