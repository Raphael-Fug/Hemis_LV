using System;
using System.Collections.Generic;

namespace C500Hemis.Models.DM;

public partial class DmDoiTuongChinhSach
{
    public int IdDoiTuongChinhSach { get; set; }

    public string? DoiTuongChinhSach { get; set; }

    public virtual ICollection<TbDoiTuongChinhSachCanBo> TbDoiTuongChinhSachCanBos { get; set; } = new List<TbDoiTuongChinhSachCanBo>();
}
