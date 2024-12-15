using System;
using System.Collections.Generic;

namespace C500Hemis.Models.DM;

public partial class DmChucDanhGiangVien
{
    public int IdChucDanhGiangVien { get; set; }

    public string? ChucDanhGiangVien { get; set; }

    public virtual ICollection<TbCanBo> TbCanBos { get; set; } = new List<TbCanBo>();

    public virtual ICollection<TbQuaTrinhCongTacCuaCanBo> TbQuaTrinhCongTacCuaCanBos { get; set; } = new List<TbQuaTrinhCongTacCuaCanBo>();
}
