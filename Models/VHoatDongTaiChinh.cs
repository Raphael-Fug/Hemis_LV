using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class VHoatDongTaiChinh
{
    [DisplayName(displayName: "HOẠT ĐỘNG TÀI CHÍNH")]
    [Required(ErrorMessage = "Bắt buộc nhập")]
    public string? HoatDongTaiChinh { get; set; }
    [DisplayName(displayName: "NĂM TÀI CHÍNH")]
    [Required(ErrorMessage = "Bắt buộc nhập")]
    public string? NamTaiChinh { get; set; }
    [DisplayName(displayName: "KINH PHÍ")]
    [Required(ErrorMessage = "Bắt buộc nhập")]
    public int? KinhPhi { get; set; }
    [DisplayName(displayName: "NỘI DUNG")]
    [Required(ErrorMessage = "Bắt buộc nhập")]
    public string? NoiDung { get; set; }
}
