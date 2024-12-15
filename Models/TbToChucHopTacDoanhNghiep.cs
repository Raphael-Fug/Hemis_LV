using System;
using System.Collections.Generic;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbToChucHopTacDoanhNghiep
{
    public int IdToChucHopTacDoanhNghiep { get; set; }

    public string? MaToChucHopTacDoanhNghiep { get; set; }

    public string? TenToChucHopTacDoanhNghiep { get; set; }

    public string? NoiDungHopTac { get; set; }

    public DateOnly? NgayKyKet { get; set; }

    public string? KetQuaHopTac { get; set; }

    public int? IdLoaiDeAn { get; set; }

    public double? GiaTriGiaoDichCuaThiTruong { get; set; }

    public virtual DmLoaiDeAnChuongTrinh? IdLoaiDeAnNavigation { get; set; }
}
