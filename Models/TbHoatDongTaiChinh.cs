using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbHoatDongTaiChinh
{
    [DisplayName(displayName: "ID HOẠT ĐỘNG TÀI CHÍNH")]
    [Required(ErrorMessage = "Bắt buộc nhập")]
    public int IdHoatDongTaiChinh { get; set; }
    [DisplayName(displayName: "ID LOẠI HOẠT ĐỘNG TÀI CHÍNH")]
    [Required(ErrorMessage = "Bắt buộc nhập")]
    public int? IdLoaiHoatDongTaiChinh { get; set; }
    [DisplayName(displayName: "NĂM TÀI CHÍNH")]
    [Required(ErrorMessage = "Bắt buộc nhập")]
    public string? NamTaiChinh { get; set; }
    [DisplayName(displayName: "KINH PHÍ (VNĐ)")]
    public int? KinhPhi { get; set; }
    [DisplayName(displayName: "NỘI DUNG ")]
    public string? NoiDung { get; set; }
    [DisplayName(displayName: "ID LOẠI HOẠT ĐỘNG TÀI CHÍNH")]
    public virtual DmHoatDongTaiChinh? IdLoaiHoatDongTaiChinhNavigation { get; set; }
}
