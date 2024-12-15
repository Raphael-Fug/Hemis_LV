using System;
using System.Collections.Generic;

namespace C500Hemis.Models;

public partial class VThongTinHopTac
{
    public string? MaHopTac { get; set; }

    public DateOnly? ThoiGianHopTacTu { get; set; }

    public DateOnly? ThoiGianHopTacDen { get; set; }

    public string? TenThoaThuan { get; set; }

    public string? ThongTinLienHeDoiTac { get; set; }

    public string? MucTieu { get; set; }

    public string? DonViTrienKhai { get; set; }

    public string? HinhThucHopTac { get; set; }

    public string? SanPhamChinh { get; set; }
}
