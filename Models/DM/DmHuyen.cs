using System;
using System.Collections.Generic;

namespace C500Hemis.Models.DM;

public partial class DmHuyen
{
    public int IdHuyen { get; set; }

    public string? TenHuyen { get; set; }

    public int? IdTinh { get; set; }

    public virtual ICollection<DmXa> DmXas { get; set; } = new List<DmXa>();

    public virtual DmTinh? IdTinhNavigation { get; set; }

    public virtual ICollection<TbCanBo> TbCanBos { get; set; } = new List<TbCanBo>();

    public virtual ICollection<TbCoSoGiaoDuc> TbCoSoGiaoDucs { get; set; } = new List<TbCoSoGiaoDuc>();

    public virtual ICollection<TbHocVien> TbHocViens { get; set; } = new List<TbHocVien>();
}
