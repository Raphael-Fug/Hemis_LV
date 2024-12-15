using System;
using System.Collections.Generic;

namespace C500Hemis.Models;

public partial class VThongTinViPham
{
    public string? Ho { get; set; }

    public string? Ten { get; set; }

    public string? SoCccd { get; set; }

    public DateOnly? ThoiGianViPham { get; set; }

    public string? NoiDungViPham { get; set; }

    public string? HinhThucXuLy { get; set; }

    public string? LoaiViPham { get; set; }
}
