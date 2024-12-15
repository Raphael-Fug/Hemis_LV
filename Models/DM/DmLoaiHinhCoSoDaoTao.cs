using System;
using System.Collections.Generic;

namespace C500Hemis.Models.DM;

public partial class DmLoaiHinhCoSoDaoTao
{
    public int IdLoaiHinhCoSoDaoTao { get; set; }

    public string? LoaiHinhCoSoDaoTao { get; set; }

    public virtual ICollection<TbCoSoGiaoDuc> TbCoSoGiaoDucs { get; set; } = new List<TbCoSoGiaoDuc>();
}
