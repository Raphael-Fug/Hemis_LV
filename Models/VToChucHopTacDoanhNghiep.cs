using System;
using System.Collections.Generic;

namespace C500Hemis.Models;

public partial class VToChucHopTacDoanhNghiep
{
    public string? MaToChucHopTacDoanhNghiep { get; set; }

    public string? TenToChucHopTacDoanhNghiep { get; set; }

    public string? NoiDungHopTac { get; set; }

    public DateOnly? NgayKyKet { get; set; }

    public string? KetQuaHopTac { get; set; }

    public string? LoaiDeAnChuongTrinh { get; set; }

    public double? GiaTriGiaoDichCuaThiTruong { get; set; }
}
