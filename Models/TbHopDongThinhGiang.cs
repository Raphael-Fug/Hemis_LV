using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbHopDongThinhGiang
{
    public int IdHopDongThinhGiang { get; set; }

    public int? IdCanBo { get; set; }
    [DisplayName(displayName: "Mã hợp đồng thỉnh giảng")]
    public string? MaHopDongThinhGiang { get; set; }

    [DisplayName(displayName: "Số sổ lao động")]
    public string? SoSoLaoDong { get; set; }

    [DisplayName(displayName: "Ngày cấp sổ lao động")]
    public DateOnly? NgayCapSoLaoDong { get; set; }

    [DisplayName(displayName: "Nơi cấp sổ lao động")]
    public string? NoiCapSoLaoDong { get; set; }

    [DisplayName(displayName: "Giá trị từ")]
    [DataType(DataType.Date)]
    public DateOnly? CoGiaTriTu { get; set; }
    [DisplayName(displayName: "Giá trị đến")]
    [DataType(DataType.Date)]
    public DateOnly? CoGiaTriDen { get; set; }

    [DisplayName(displayName: "Mã trạng thái hợp đồng")]
    public int? IdTrangThaiHopDong { get; set; }

    [DisplayName(displayName: "Tỷ lệ thời gian giảng dạy")]
    public int? TyLeThoiGianGiangDay { get; set; }
    [DisplayName(displayName: "ID định vị Cán Bộ")]
    public virtual TbCanBo? IdCanBoNavigation { get; set; }

    [DisplayName(displayName: "ID định vị trạng thái hợp đồng")]
    public virtual DmTrangThaiHopDong? IdTrangThaiHopDongNavigation { get; set; }
}
