using System;
using System.Collections.Generic;

namespace C500Hemis.Models.DM;

public partial class DmChuongTrinhDaoTao
{
    public int IdChuongTrinhDaoTao { get; set; }

    public string? ChuongTrinhDaoTao { get; set; }

    public virtual ICollection<TbThongTinHocTapNghienCuuSinh> TbThongTinHocTapNghienCuuSinhs { get; set; } = new List<TbThongTinHocTapNghienCuuSinh>();
}
