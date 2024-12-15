using System;
using System.Collections.Generic;

namespace C500Hemis.Models.DM;

public partial class DmLoaiLuuHocSinh
{
    public int IdLoaiLuuHocSinh { get; set; }

    public string? LoaiLuuHocSinh { get; set; }

    public virtual ICollection<TbLuuHocSinhSinhVienNn> TbLuuHocSinhSinhVienNns { get; set; } = new List<TbLuuHocSinhSinhVienNn>();
}
