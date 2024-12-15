using System;
using System.Collections.Generic;

namespace C500Hemis.Models.DM;

public partial class DmXa
{
    public int IdXa { get; set; }

    public string? TenXa { get; set; }

    public int? IdHuyen { get; set; }

    public virtual DmHuyen? IdHuyenNavigation { get; set; }

    public virtual ICollection<TbCanBo> TbCanBos { get; set; } = new List<TbCanBo>();

    public virtual ICollection<TbCoSoGiaoDuc> TbCoSoGiaoDucs { get; set; } = new List<TbCoSoGiaoDuc>();

    public virtual ICollection<TbHocVien> TbHocViens { get; set; } = new List<TbHocVien>();
}
