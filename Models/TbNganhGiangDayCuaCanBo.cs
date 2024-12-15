using System;
using System.Collections.Generic;
using System.ComponentModel;
using C500Hemis.Models.DM;
namespace C500Hemis.Models;

public partial class TbNganhGiangDayCuaCanBo
{
    [DisplayName(displayName: "ID Ngành Giảng Dạy Của Cán Bộ")]
    public int IdNganhGiangDayCuaCanBo { get; set; }
    [DisplayName(displayName: "ID Cán Bộ")]
    public int? IdCanBo { get; set; }
    [DisplayName(displayName: "ID Trình Độ Đào Tạo")]
    public int? IdTrinhDoDaoTao { get; set; }
    [DisplayName(displayName: "ID Ngành")]
    public int? IdNganh { get; set; }
    [DisplayName(displayName: "Ngành Chính")]
    public bool? LaNganhChinh { get; set; }
    [DisplayName(displayName: "Đơn Vị Thỉnh Giảng")]
    public string? DonViThinhGiang { get; set; }

    [DisplayName(displayName: "ID Cán Bộ")]
    public virtual TbCanBo? IdCanBoNavigation { get; set; }
    [DisplayName(displayName: "ID Ngành")]
    public virtual DmNganhDaoTao? IdNganhNavigation { get; set; }
    [DisplayName(displayName: "ID Trình Độ Đào Tạo")]
    public virtual DmTrinhDoDaoTao? IdTrinhDoDaoTaoNavigation { get; set; }
}