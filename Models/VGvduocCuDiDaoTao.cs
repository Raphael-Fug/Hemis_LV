using System;
using System.Collections.Generic;

namespace C500Hemis.Models;

public partial class VGvduocCuDiDaoTao
{
    public string? MaCanBo { get; set; }

    public string? HinhThucThamGiaGvduocCuDiDaoTao { get; set; }

    public string? TenNuoc { get; set; }

    public string? TenCoSoGiaoDucThamGiaOnn { get; set; }

    public DateOnly? ThoiGianBatDau { get; set; }

    public DateOnly? ThoiGianKetThuc { get; set; }

    public string? TinhTrangGiangVienDuocCuDiDaoTao { get; set; }

    public string? NguonKinhPhiCuaGvduocCuDiDaoTao { get; set; }
}
