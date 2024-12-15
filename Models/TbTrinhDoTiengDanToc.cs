using System;
using System.Collections.Generic;
using System.ComponentModel;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbTrinhDoTiengDanToc
{
    [DisplayName(displayName: "Trình độ tiếng dân tộc")]
    public int IdTrinhDoTiengDanToc { get; set; }
    [DisplayName(displayName: "Cán bộ")]
    public int? IdCanBo { get; set; }
    [DisplayName(displayName: "Tiếng dân tộc")]
    public int? IdTiengDanToc { get; set; }
    [DisplayName(displayName: "Khung năng lực ngoại ngữ")]
    public int? IdKhungNangLucNgoaiNgu { get; set; }
    [DisplayName(displayName: "Id Cán bộ")]
    public virtual TbCanBo? IdCanBoNavigation { get; set; }
    [DisplayName(displayName: "Id Khung năng lực ngoại ngữ")]
    public virtual DmKhungNangLucNgoaiNgu? IdKhungNangLucNgoaiNguNavigation { get; set; }
    [DisplayName(displayName: "Id Tiếng dân tộc")]
    public virtual DmTiengDanToc? IdTiengDanTocNavigation { get; set; }
}
