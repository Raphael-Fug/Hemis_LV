using System;
using System.Collections.Generic;

namespace C500Hemis.Models;

public partial class VKyLuatNguoiHoc
{
    public string? Ho { get; set; }

    public string? Ten { get; set; }

    public string? SoCccd { get; set; }

    public string? LoaiKyLuat { get; set; }

    public string? LyDo { get; set; }

    public string? CapQuyetDinh { get; set; }

    public string? SoQuyetDinh { get; set; }

    public DateOnly? NgayQuyetDinh { get; set; }

    public string? NamBiKyLuat { get; set; }
}
