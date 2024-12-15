using System;
using System.Collections.Generic;

namespace C500Hemis.Models.DM;

public partial class DmLoaiTotNghiep
{
    public int IdLoaiTotNghiep { get; set; }

    public string? LoaiTotNghiep { get; set; }

    public virtual ICollection<TbDanhSachVanBangChungChi> TbDanhSachVanBangChungChis { get; set; } = new List<TbDanhSachVanBangChungChi>();

    public virtual ICollection<TbThongTinHocTapNghienCuuSinh> TbThongTinHocTapNghienCuuSinhs { get; set; } = new List<TbThongTinHocTapNghienCuuSinh>();
}
