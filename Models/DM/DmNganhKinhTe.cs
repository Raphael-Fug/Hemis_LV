using System;
using System.Collections.Generic;

namespace C500Hemis.Models.DM;

public partial class DmNganhKinhTe
{
    public int IdNganhKinhTe { get; set; }

    public string? Cap1 { get; set; }

    public string? NganhKinhTe { get; set; }

    public virtual ICollection<TbChuyenGiaoCongNgheVaDaoTao> TbChuyenGiaoCongNgheVaDaoTaos { get; set; } = new List<TbChuyenGiaoCongNgheVaDaoTao>();
}
