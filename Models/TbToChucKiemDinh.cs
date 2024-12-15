using System;
using System.Collections.Generic;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbToChucKiemDinh
{
    public int IdToChucKiemDinhCsdg { get; set; }

    public int? IdToChucKiemDinh { get; set; }

    public int? IdKetQua { get; set; }

    public string? SoQuyetDinhKiemDinh { get; set; }

    public DateOnly? NgayCapChungNhanKiemDinh { get; set; }

    public DateOnly? ThoiHanKiemDinh { get; set; }

    public virtual DmKetQuaKiemDinh? IdKetQuaNavigation { get; set; }

    public virtual DmToChucKiemDinh? IdToChucKiemDinhNavigation { get; set; }
}
