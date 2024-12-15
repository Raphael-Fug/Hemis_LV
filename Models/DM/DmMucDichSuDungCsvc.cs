using System;
using System.Collections.Generic;

namespace C500Hemis.Models.DM;

public partial class DmMucDichSuDungCsvc
{
    public int IdMucDichSuDungCsvc { get; set; }

    public string? MucDichSuDungCsvc { get; set; }

    public virtual ICollection<TbCongTrinhCoSoVatChat> TbCongTrinhCoSoVatChats { get; set; } = new List<TbCongTrinhCoSoVatChat>();
}
