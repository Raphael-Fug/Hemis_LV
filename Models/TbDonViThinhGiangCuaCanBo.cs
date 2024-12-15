using System;
using System.Collections.Generic;

namespace C500Hemis.Models;

public partial class TbDonViThinhGiangCuaCanBo
{
    public int IdDonViThinhGiangCuaCanBo { get; set; }

    public int? IdCanBo { get; set; }

    public string? DonViThinhGiang { get; set; }

    public string? SoHopDongThinhGiang { get; set; }

    public DateOnly? ThoiGianBatDau { get; set; }

    public DateOnly? ThoiGianKetThuc { get; set; }

    public int? ThamNienGiangDay { get; set; }

    public virtual TbCanBo? IdCanBoNavigation { get; set; }
}
