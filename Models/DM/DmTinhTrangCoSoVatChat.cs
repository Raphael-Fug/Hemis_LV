using System;
using System.Collections.Generic;

namespace C500Hemis.Models.DM;

public partial class DmTinhTrangCoSoVatChat
{
    public int IdTinhTrangCoSoVatChat { get; set; }

    public string? TinhTrangCoSoVatChat { get; set; }

    public virtual ICollection<TbCongTrinhCoSoVatChat> TbCongTrinhCoSoVatChats { get; set; } = new List<TbCongTrinhCoSoVatChat>();

    public virtual ICollection<TbKiTucXa> TbKiTucXas { get; set; } = new List<TbKiTucXa>();

    public virtual ICollection<TbPhongHocGiangDuongHoiTruong> TbPhongHocGiangDuongHoiTruongs { get; set; } = new List<TbPhongHocGiangDuongHoiTruong>();
    public virtual ICollection<TbThuVienTrungTamHocLieu> TbThuVienTrungTamHocLieus { get; set; } = new List<TbThuVienTrungTamHocLieu>();
}

