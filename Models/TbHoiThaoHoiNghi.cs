using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbHoiThaoHoiNghi
{
    [DisplayName(displayName: "ID hội thảo, hội nghị")]
    public int IdHoiThaoHoiNghi { get; set; }
    [DisplayName(displayName: "Mã hội thảo, hội nghị")]
    public string? MaHoiThaoHoiNghi { get; set; }
    [DisplayName(displayName: "Tên hội thảo, hội nghị")]
    public string? TenHoiThaoHoiNghi { get; set; }
    [DisplayName(displayName: "Cơ quan có thẩm quyền, cấp phép")]
    public string? CoQuanCoThamQuyenCapPhep { get; set; }
    [DisplayName(displayName: "Mục tiêu")]
    public string? MucTieu { get; set; }
    [DisplayName(displayName: "Nội dung")]
    public string? NoiDung { get; set; }
    [DisplayName(displayName: "Số lượng đại biểu tham dự")]
    public int? SoLuongDaiBieuThamDu { get; set; }
    [DisplayName(displayName: "Số lượng đại biểu quốc tế tham dự")]
    public int? SoLuongDaiBieuQuocTeThamDu { get; set; }
    [DisplayName(displayName: "Thời gian tổ chức")]
    [DataType(DataType.Date)]
    public DateOnly? ThoiGianToChuc { get; set; }
    [DisplayName(displayName: "Địa điểm tổ chức")]
    public string? DiaDiemToChuc { get; set; }
    [DisplayName(displayName: "Nguồn kinh phí")]
    public int? IdNguonKinhPhiHoiThao { get; set; }
    [DisplayName(displayName: "Đơn vị chủ trì")]
    public string? DonViChuTri { get; set; }
    [DisplayName(displayName: "Nguồn kinh phí")]
    public virtual DmNguonKinhPhi? IdNguonKinhPhiHoiThaoNavigation { get; set; }
}
