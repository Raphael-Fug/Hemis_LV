using System;
using System.Collections.Generic;

namespace C500Hemis.Models.DM;

public partial class DmLoaiHinhTruong
{
    public int IdLoaiHinhTruong { get; set; }

    public string? LoaiHinhTruong { get; set; }

    public virtual ICollection<TbCoSoGiaoDuc> TbCoSoGiaoDucs { get; set; } = new List<TbCoSoGiaoDuc>();
}
