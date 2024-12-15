using System;
using System.Collections.Generic;

namespace C500Hemis.Models.DM;

public partial class DmQuocTich
{
    public int IdQuocTich { get; set; }

    public string? TenNuoc { get; set; }

    public virtual ICollection<TbChuongTrinhDaoTao> TbChuongTrinhDaoTaos { get; set; } = new List<TbChuongTrinhDaoTao>();

    public virtual ICollection<TbDoanCongTac> TbDoanCongTacs { get; set; } = new List<TbDoanCongTac>();

    public virtual ICollection<TbGvduocCuDiDaoTao> TbGvduocCuDiDaoTaos { get; set; } = new List<TbGvduocCuDiDaoTao>();

    public virtual ICollection<TbNguoi> TbNguois { get; set; } = new List<TbNguoi>();

    public virtual ICollection<TbQuaTrinhDaoTaoCuaCanBo> TbQuaTrinhDaoTaoCuaCanBos { get; set; } = new List<TbQuaTrinhDaoTaoCuaCanBo>();

    public virtual ICollection<TbThietBiPtnThtren500Tr> TbThietBiPtnThtren500Trs { get; set; } = new List<TbThietBiPtnThtren500Tr>();

    public virtual ICollection<TbToChucHopTacQuocTe> TbToChucHopTacQuocTes { get; set; } = new List<TbToChucHopTacQuocTe>();
}
