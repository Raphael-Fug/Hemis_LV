using System;
using System.Collections.Generic;

namespace C500Hemis.Models.DM;

public partial class DmHoGiaDinhChinhSach
{
    public int IdHoGiaDinhChinhSach { get; set; }

    public string? HoGiaDinhChinhSach { get; set; }

    public virtual ICollection<TbNguoi> TbNguois { get; set; } = new List<TbNguoi>();
}
