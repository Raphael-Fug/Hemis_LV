using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace C500Hemis.Models;
//commit  
 
public partial class TbKhoanNopNganSach
{
    [Display(Name = "ID Khoản Nộp Ngân Sách")]
    public int IdKhoanNopNganSach { get; set; }

    [Display(Name = "Mã Khoản Nộp")]

    public string? MaKhoanNop { get; set; }

    [Display(Name = "Tên Khoản Nộp Ngân Sách")]

    public string? TenKhoanNopNganSach { get; set; }

    [Display(Name = "Số Tiền")]

    public int? SoTien { get; set; }

    [Display(Name = "Năm Tài Chính")]

    public string? NamTaiChinh { get; set; }
}