using System;
using System.Collections.Generic;

namespace C500Hemis.Models;

public partial class VThongTinViecLamSauTotNghiep
{
    public string? Ho { get; set; }

    public string? Ten { get; set; }

    public string? SoCccd { get; set; }

    public string? TenDonViCapBang { get; set; }

    public string? DonViTuyenDung { get; set; }

    public string? HinhThucTuyenDung { get; set; }

    public DateOnly? ThoiGianTuyenDung { get; set; }

    public string? ViTriViecLam { get; set; }

    public int? MucLuongKhoiDiem { get; set; }
}
