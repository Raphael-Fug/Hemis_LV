using System;
using System.Collections.Generic;

namespace C500Hemis.Models.DM;

public partial class DmLoaiQuyetDinh
{
    public int IdLoaiQuyetDinh { get; set; }

    public string? LoaiQuyetDinh { get; set; }

    public virtual ICollection<TbChucDanhKhoaHocCuaCanBo> TbChucDanhKhoaHocCuaCanBos { get; set; } = new List<TbChucDanhKhoaHocCuaCanBo>();

    public virtual ICollection<TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai> TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoais { get; set; } = new List<TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai>();
}
