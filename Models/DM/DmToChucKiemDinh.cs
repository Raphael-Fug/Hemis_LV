using System;
using System.Collections.Generic;

namespace C500Hemis.Models.DM;

public partial class DmToChucKiemDinh
{
    public int IdToChucKiemDinh { get; set; }

    public string? ToChucKiemDinh { get; set; }

    public virtual ICollection<TbThongTinKiemDinhCuaChuongTrinh> TbThongTinKiemDinhCuaChuongTrinhs { get; set; } = new List<TbThongTinKiemDinhCuaChuongTrinh>();

    public virtual ICollection<TbToChucKiemDinh> TbToChucKiemDinhs { get; set; } = new List<TbToChucKiemDinh>();
}
