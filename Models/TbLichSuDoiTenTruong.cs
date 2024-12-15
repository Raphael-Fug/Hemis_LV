using System;
using System.Collections.Generic;

namespace C500Hemis.Models;

public partial class TbLichSuDoiTenTruong
{
    public int IdLichSuDoiTenTruong { get; set; }

    public string? TenTruongCu { get; set; }

    public string? TenTruongCuTiengAnh { get; set; }

    public string? SoQuyetDinhDoiTen { get; set; }

    public DateOnly? NgayKyQuyetDinhDoiTen { get; set; }
}
