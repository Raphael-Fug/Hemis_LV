using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbLoaiThuChi
{
    [DisplayName(displayName: "ID LOẠI THU CHI")]
    [Required(ErrorMessage = "Bắt buộc nhập")]
    public int IdLoaiThuChi { get; set; }
    [DisplayName(displayName: "MÃ LOẠI THU CHI")]
    [Required(ErrorMessage = "Bắt buộc nhập")]
    public string? MaLoaiThuChi { get; set; }
    [DisplayName(displayName: "ID PHÂN LOẠI THU CHI")]
    [Required(ErrorMessage = "Bắt buộc nhập")]
    public int? IdPhanLoaiThuChi { get; set; }
    [DisplayName(displayName: "TÊN LOẠI THU CHI")]
    [Required(ErrorMessage = "Bắt buộc nhập")]
    public string? TenLoaiThuChi { get; set; }
    [DisplayName(displayName: "MÔ TẢ")]
    [Required(ErrorMessage = "Bắt buộc nhập")]
    public string? MoTa { get; set; }
    [DisplayName(displayName: "ID PHÂN LOẠI THU CHI")]
    public virtual DmPhanLoaiThuChi? IdPhanLoaiThuChiNavigation { get; set; }
    [DisplayName(displayName: "THÔNG BÁO CHI TIẾT THU CHI")]
    public virtual ICollection<TbChiTietThuChi> TbChiTietThuChis { get; set; } = new List<TbChiTietThuChi>();
}
