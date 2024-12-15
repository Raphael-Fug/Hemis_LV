using System;
using System.Collections.Generic;

namespace C500Hemis.Models.DM;

public partial class DmLinhVucNghienCuu
{
    public int IdLinhVucNghienCuu { get; set; }

    public string? LinhVucNghienCuu { get; set; }

    public virtual ICollection<TbChuyenGiaoCongNgheVaDaoTao> TbChuyenGiaoCongNgheVaDaoTaos { get; set; } = new List<TbChuyenGiaoCongNgheVaDaoTao>();

    public virtual ICollection<TbLinhVucNghienCuuCuaCanBo> TbLinhVucNghienCuuCuaCanBos { get; set; } = new List<TbLinhVucNghienCuuCuaCanBo>();

    public virtual ICollection<TbNhiemVuKhcn> TbNhiemVuKhcns { get; set; } = new List<TbNhiemVuKhcn>();

    public virtual ICollection<TbPhongThiNghiem> TbPhongThiNghiems { get; set; } = new List<TbPhongThiNghiem>();

    public virtual ICollection<TbPhongThucHanh> TbPhongThucHanhs { get; set; } = new List<TbPhongThucHanh>();

    public virtual ICollection<TbTapChiKhoaHoc> TbTapChiKhoaHocs { get; set; } = new List<TbTapChiKhoaHoc>();
}
