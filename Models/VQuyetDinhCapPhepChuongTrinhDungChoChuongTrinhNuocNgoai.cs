using System;
using System.Collections.Generic;

namespace C500Hemis.Models;

public partial class VQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai
{
    public string? TenChuongTrinh { get; set; }

    public string? MaChuongTrinhDaoTao { get; set; }

    public string? LoaiQuyetDinh { get; set; }

    public string? SoQuyetDinh { get; set; }

    public DateOnly? NgayBanHanhQuyetDinh { get; set; }

    public string? HinhThucDaoTao { get; set; }
}
