using System;
using System.Collections.Generic;

namespace C500Hemis.Models.DM;

public partial class DmHinhThucSoHuu
{
    public int IdHinhThucSoHuu { get; set; }

    public string? HinhThucSoHuu { get; set; }

    public virtual ICollection<TbCongTrinhCoSoVatChat> TbCongTrinhCoSoVatChats { get; set; } = new List<TbCongTrinhCoSoVatChat>();

    public virtual ICollection<TbDatDai> TbDatDais { get; set; } = new List<TbDatDai>();

    public virtual ICollection<TbKiTucXa> TbKiTucXas { get; set; } = new List<TbKiTucXa>();

    public virtual ICollection<TbPhongHocGiangDuongHoiTruong> TbPhongHocGiangDuongHoiTruongs { get; set; } = new List<TbPhongHocGiangDuongHoiTruong>();
    public virtual ICollection<TbThuVienTrungTamHocLieu> TbThuVienTrungTamHocLieus { get; set; } = new List<TbThuVienTrungTamHocLieu>();
}
