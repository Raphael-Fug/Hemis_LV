using System;
using System.Collections.Generic;

namespace C500Hemis.Models.DM;

public partial class DmNganhDaoTao
{
    public int IdNganhDaoTao { get; set; }

    public string? NganhDaoTao { get; set; }

    public virtual ICollection<TbChiTieuTuyenSinhTheoNganh> TbChiTieuTuyenSinhTheoNganhs { get; set; } = new List<TbChiTieuTuyenSinhTheoNganh>();

    public virtual ICollection<TbChuongTrinhDaoTao> TbChuongTrinhDaoTaos { get; set; } = new List<TbChuongTrinhDaoTao>();

    public virtual ICollection<TbDanhSachNganhDaoTao> TbDanhSachNganhDaoTaos { get; set; } = new List<TbDanhSachNganhDaoTao>();

    public virtual ICollection<TbHinhThucDaoTaoCuaNganh> TbHinhThucDaoTaoCuaNganhs { get; set; } = new List<TbHinhThucDaoTaoCuaNganh>();

    public virtual ICollection<TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh> TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganhs { get; set; } = new List<TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh>();

    public virtual ICollection<TbNganhDungTenGiangDay> TbNganhDungTenGiangDays { get; set; } = new List<TbNganhDungTenGiangDay>();

    public virtual ICollection<TbNganhGiangDayCuaCanBo> TbNganhGiangDayCuaCanBos { get; set; } = new List<TbNganhGiangDayCuaCanBo>();

    public virtual ICollection<TbNguoi> TbNguois { get; set; } = new List<TbNguoi>();

    public virtual ICollection<TbNhomNganhDaoTao> TbNhomNganhDaoTaos { get; set; } = new List<TbNhomNganhDaoTao>();

    public virtual ICollection<TbQuaTrinhDaoTaoCuaCanBo> TbQuaTrinhDaoTaoCuaCanBos { get; set; } = new List<TbQuaTrinhDaoTaoCuaCanBo>();
}
