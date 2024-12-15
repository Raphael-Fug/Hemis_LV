using System;
using System.Collections.Generic;

namespace C500Hemis.Models.DM;

public partial class DmDoiTuongDauVao
{
    public int IdDoiTuongDauVao { get; set; }

    public string? DoiTuongDauVao { get; set; }

    public virtual ICollection<TbDuLieuTrungTuyen> TbDuLieuTrungTuyens { get; set; } = new List<TbDuLieuTrungTuyen>();

    public virtual ICollection<TbThongTinHocTapNghienCuuSinh> TbThongTinHocTapNghienCuuSinhs { get; set; } = new List<TbThongTinHocTapNghienCuuSinh>();
}
