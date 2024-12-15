using System;
using System.Collections.Generic;

namespace C500Hemis.Models;

public partial class VThongTinKiemDinhCuaChuongTrinh
{
    public string? TenChuongTrinh { get; set; }

    public string? MaChuongTrinhDaoTao { get; set; }

    public string? ToChucKiemDinh { get; set; }

    public string? KetQuaKiemDinh { get; set; }

    public string? SoQuyetDinh { get; set; }

    public DateOnly? NgayCapChungNhanKiemDinh { get; set; }

    public DateOnly? ThoiHanKiemDinh { get; set; }
}
