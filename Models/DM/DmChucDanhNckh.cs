using System;
using System.Collections.Generic;

namespace C500Hemis.Models.DM;

public partial class DmChucDanhNckh
{
    public int IdChucDanhNghienCuuKhoaHoc { get; set; }

    public string? ChucDanhNghienCuuKhoaHoc { get; set; }

    public virtual ICollection<TbCanBo> TbCanBos { get; set; } = new List<TbCanBo>();
}
