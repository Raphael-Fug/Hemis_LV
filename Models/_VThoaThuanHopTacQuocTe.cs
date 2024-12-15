using System;
using System.Collections.Generic;

namespace C500Hemis.Models;

public partial class _VThoaThuanHopTacQuocTe
{
    public int id { get; set; }

    public string? MaThoaThuan { get; set; }

    public string? TenThoaThuan { get; set; }

    public string? NoiDungTomTat { get; set; }

    public string? TenToChuc { get; set; }

    public DateOnly? NgayKyKet { get; set; }

    public string? SoVanBanKyKet { get; set; }

    public string? TenNuoc { get; set; }

    public DateOnly? NgayHetHan { get; set; }
}
