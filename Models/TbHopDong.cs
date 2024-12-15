using System;
using System.Collections.Generic;
using System.ComponentModel;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbHopDong
{
    public int IdHopDong { get; set; }

    public int? IdCanBo { get; set; }
    [DisplayName("Số hợp đồng")]
    public string? SoHopDong { get; set; }
    [DisplayName("Loại hợp đồng")]
    public int? IdLoaiHopDong { get; set; }
    [DisplayName("Số quyết định")]
    public string? SoQuyetDinh { get; set; }
    [DisplayName("Ngày quyết định")]
    public DateOnly? NgayQuyetDinh { get; set; }
    [DisplayName("Có giá trị từ")]
    public DateOnly? CoGiaTriTu { get; set; }
    [DisplayName("Có giá trị đến")]
    public DateOnly? CoGiaTriDen { get; set; }
    [DisplayName("Tình trạng hợp đồng")]
    public int? IdTinhTrangHopDong { get; set; }
    [DisplayName("Làm việc toàn thời gian")]
    public bool? LamViecToanThoiGian { get; set; }
    
    [DisplayName("ID Cán bộ")]
    public virtual TbCanBo? IdCanBoNavigation { get; set; }

    [DisplayName("ID Hợp đồng")]
    public virtual DmLoaiHopDong? IdLoaiHopDongNavigation { get; set; }

    [DisplayName("ID Tình trạng hợp đồng")]
    public virtual DmTinhTrangHopDong? IdTinhTrangHopDongNavigation { get; set; }
}