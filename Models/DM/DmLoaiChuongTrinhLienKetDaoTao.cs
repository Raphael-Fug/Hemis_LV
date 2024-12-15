using System;
using System.Collections.Generic;

namespace C500Hemis.Models.DM;

public partial class DmLoaiChuongTrinhLienKetDaoTao
{
    public int IdLoaiChuongTrinhLienKetDaoTao { get; set; }

    public string? LoaiChuongTrinhLienKetDaoTao { get; set; }

    public virtual ICollection<TbChuongTrinhDaoTao> TbChuongTrinhDaoTaos { get; set; } = new List<TbChuongTrinhDaoTao>();
}
