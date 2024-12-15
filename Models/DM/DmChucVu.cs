using System;
using System.Collections.Generic;

namespace C500Hemis.Models.DM;

public partial class DmChucVu
{
    public int IdChucVu { get; set; }

    public string? ChucVu { get; set; }

    public virtual ICollection<TbCanBo> TbCanBos { get; set; } = new List<TbCanBo>();

    public virtual ICollection<TbDonViCongTacCuaCanBo> TbDonViCongTacCuaCanBos { get; set; } = new List<TbDonViCongTacCuaCanBo>();

    public virtual ICollection<TbQuaTrinhCongTacCuaCanBo> TbQuaTrinhCongTacCuaCanBos { get; set; } = new List<TbQuaTrinhCongTacCuaCanBo>();
}
