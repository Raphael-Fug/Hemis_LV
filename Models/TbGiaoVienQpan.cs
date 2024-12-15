using System;
using System.Collections.Generic;
using System.ComponentModel;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbGiaoVienQpan
{
    [DisplayName(displayName: "ID Giáo viên QPAN")]
    public int IdGiaoVienQpan { get; set; }
    [DisplayName(displayName: "ID Cán bộ")]
    public int? IdCanBo { get; set; }
    [DisplayName(displayName: "Năm bắt đầu biệt phái")]
    public DateOnly? NamBatDauBietPhai { get; set; }
    [DisplayName(displayName: "Số năm biệt phái")]
    public DateOnly? SoNamBietPhai { get; set; }
    [DisplayName(displayName: "Loại giảng viên QP")]

    public int? IdLoaiGiangVienQp { get; set; }
    [DisplayName(displayName: "Đào tạo GDQPAN")]

    public string? DaoTaoGdqpan { get; set; }
    [DisplayName(displayName: "Quân hàm")]
    public int? IdQuanHam { get; set; }
    [DisplayName(displayName: "Sở trường công tác")]
    public string? SoTruongCongTac { get; set; }
    [DisplayName(displayName: "ID Cán bộ")]

    public virtual TbCanBo? IdCanBoNavigation { get; set; }
    [DisplayName(displayName: "ID Loại giảng viên QP")]
    public virtual DmLoaiGiangVienQuocPhong? IdLoaiGiangVienQpNavigation { get; set; }
    [DisplayName(displayName: "Quân hàm")]
    public virtual DmQuanHam? IdQuanHamNavigation { get; set; }
}
