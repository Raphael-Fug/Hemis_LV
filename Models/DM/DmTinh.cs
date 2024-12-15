using System;
using System.Collections.Generic;

namespace C500Hemis.Models.DM;

public partial class DmTinh
{
    public int IdTinh { get; set; }

    public string? TenTinh { get; set; }

    public virtual ICollection<DmHuyen> DmHuyens { get; set; } = new List<DmHuyen>();

    public virtual ICollection<TbCanBo> TbCanBos { get; set; } = new List<TbCanBo>();

    public virtual ICollection<TbCoSoGiaoDuc> TbCoSoGiaoDucs { get; set; } = new List<TbCoSoGiaoDuc>();

    public virtual ICollection<TbHocVien> TbHocViens { get; set; } = new List<TbHocVien>();
}
