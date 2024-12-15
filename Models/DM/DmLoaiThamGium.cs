using System;
using System.Collections.Generic;

namespace C500Hemis.Models.DM;

public partial class DmLoaiThamGium
{
    public int IdLoaiThamGia { get; set; }

    public string? LoaiThamGia { get; set; }

    public virtual ICollection<TbDoiTuongThamGium> TbDoiTuongThamGia { get; set; } = new List<TbDoiTuongThamGium>();
}
