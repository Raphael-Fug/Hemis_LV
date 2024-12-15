using System;
using System.Collections.Generic;

namespace C500Hemis.Models.DM;

public partial class DmLoaiPhongThiNghiem
{
    public int IdLoaiPhongThiNghiem { get; set; }

    public string? LoaiPhongThiNghiem { get; set; }

    public virtual ICollection<TbPhongThiNghiem> TbPhongThiNghiems { get; set; } = new List<TbPhongThiNghiem>();
}
