using System;
using System.Collections.Generic;

namespace C500Hemis.Models;

public partial class VToChucKiemDinh
{
    public string? ToChucKiemDinh { get; set; }

    public string? KetQuaKiemDinh { get; set; }

    public string? SoQuyetDinhKiemDinh { get; set; }

    public DateOnly? NgayCapChungNhanKiemDinh { get; set; }

    public DateOnly? ThoiHanKiemDinh { get; set; }
}
