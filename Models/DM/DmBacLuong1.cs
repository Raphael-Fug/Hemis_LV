using System;
using System.Collections.Generic;

namespace C500Hemis.Models.DM;

public partial class DmBacLuong1
{
    public int IdBacLuong { get; set; }

    public string? BacLuong { get; set; }

    public virtual ICollection<TbDienBienLuong> TbDienBienLuongs { get; set; } = new List<TbDienBienLuong>();

    public virtual ICollection<TbPhuCap> TbPhuCaps { get; set; } = new List<TbPhuCap>();
}
