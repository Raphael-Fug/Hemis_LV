using System;
using System.Collections.Generic;

namespace C500Hemis.Models;

public partial class VLoaiHinhDaoTaoKhacDuocChoPhepMoNganh
{
    public string? NganhDaoTao { get; set; }

    public string? LoaiHinhDaoTao { get; set; }

    public string? SoQuyetDinhChoPhep { get; set; }

    public DateOnly? NgayBanHanhQuyetDinhChoPhep { get; set; }
}
