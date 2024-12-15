using System;
using System.Collections.Generic;

namespace C500Hemis.Models.DM;

public partial class DmNguonKinhPhiChoLuuHocSinh
{
    public int IdNguonKinhPhiChoLuuHocSinh { get; set; }

    public string? NguonKinhPhiChoLuuHocSinh { get; set; }

    public virtual ICollection<TbLuuHocSinhSinhVienNn> TbLuuHocSinhSinhVienNns { get; set; } = new List<TbLuuHocSinhSinhVienNn>();
}
