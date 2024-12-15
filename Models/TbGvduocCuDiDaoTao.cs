using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbGvduocCuDiDaoTao
{
    [DisplayName("GV được cử đi đào tạo")]
    public int IdGvduocCuDiDaoTao { get; set; }
    [DisplayName("Cán bộ")]
    public int? IdCanBo { get; set; }
    [DisplayName("Hình thức tham gia GV cử đi đào tạo")]
    public int? IdHinhThucThamGiaGvduocCuDiDaoTao { get; set; }
    [DisplayName("Quốc gia đến")]
    public int? IdQuocGiaDen { get; set; }
    [DisplayName("Tên cơ sở tham gia ôn")]
    public string? TenCoSoGiaoDucThamGiaOnn { get; set; }
    [DisplayName("Thời gian bắt đầu")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? ThoiGianBatDau { get; set; }
    [DisplayName("Thời gian kết thúc")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? ThoiGianKetThuc { get; set; }
    [DisplayName("Tình trạng GV được cử đi đào tạo")]
    public int? IdTinhTrangGvduocCuDiDaoTao { get; set; }
    [DisplayName("Nguồn kinh phí của GV")]
    public int? IdNguonKinhPhiCuaGv { get; set; }
    [DisplayName("Cán bộ")]
    public virtual TbCanBo? IdCanBoNavigation { get; set; }
    [DisplayName("Hình thức tham gia GV cử đi đào tạo")]
    public virtual DmHinhThucThamGiaGvduocCuDiDaoTao? IdHinhThucThamGiaGvduocCuDiDaoTaoNavigation { get; set; }
    [DisplayName("Nguồn kinh phí của GV")]
    public virtual DmNguonKinhPhiCuaGvduocCuDiDaoTao? IdNguonKinhPhiCuaGvNavigation { get; set; }
    [DisplayName("Quốc gia đến")]
    public virtual DmQuocTich? IdQuocGiaDenNavigation { get; set; }
    [DisplayName("Tình trạng GV được cử đi đào tạo")]
    public virtual DmTinhTrangGiangVienDuocCuDiDaoTao? IdTinhTrangGvduocCuDiDaoTaoNavigation { get; set; }
}
