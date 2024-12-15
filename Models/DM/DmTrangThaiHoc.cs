using System;
using System.Collections.Generic;

namespace C500Hemis.Models.DM;

public partial class DmTrangThaiHoc
{
    public int IdTrangThaiHoc { get; set; }

    public string? TrangThaiHoc { get; set; }

    public virtual ICollection<TbThongTinHocTapNghienCuuSinh> TbThongTinHocTapNghienCuuSinhs { get; set; } = new List<TbThongTinHocTapNghienCuuSinh>();
}
