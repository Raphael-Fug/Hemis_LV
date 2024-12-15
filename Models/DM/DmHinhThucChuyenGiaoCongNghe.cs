using System;
using System.Collections.Generic;

namespace C500Hemis.Models.DM;

public partial class DmHinhThucChuyenGiaoCongNghe
{
    public int IdHinhThucChuyenGiaoCongNghe { get; set; }

    public string? HinhThucChuyenGiaoCongNghe { get; set; }

    public virtual ICollection<TbChuyenGiaoCongNgheVaDaoTao> TbChuyenGiaoCongNgheVaDaoTaos { get; set; } = new List<TbChuyenGiaoCongNgheVaDaoTao>();
}
