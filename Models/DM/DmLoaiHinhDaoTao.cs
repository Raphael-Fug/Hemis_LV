using System;
using System.Collections.Generic;

namespace C500Hemis.Models.DM;

public partial class DmLoaiHinhDaoTao
{
    public int IdLoaiHinhDaoTao { get; set; }

    public string? LoaiHinhDaoTao { get; set; }

    public virtual ICollection<TbChiTieuTuyenSinhTheoNganh> TbChiTieuTuyenSinhTheoNganhs { get; set; } = new List<TbChiTieuTuyenSinhTheoNganh>();

    public virtual ICollection<TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh> TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganhs { get; set; } = new List<TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh>();

    public virtual ICollection<TbQuaTrinhDaoTaoCuaCanBo> TbQuaTrinhDaoTaoCuaCanBos { get; set; } = new List<TbQuaTrinhDaoTaoCuaCanBo>();

    public virtual ICollection<TbThongTinHocTapNghienCuuSinh> TbThongTinHocTapNghienCuuSinhs { get; set; } = new List<TbThongTinHocTapNghienCuuSinh>();
}
