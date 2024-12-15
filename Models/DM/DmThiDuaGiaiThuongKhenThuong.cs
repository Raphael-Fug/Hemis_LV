using System;
using System.Collections.Generic;

namespace C500Hemis.Models.DM;

public partial class DmThiDuaGiaiThuongKhenThuong
{
    public int IdThiDuaGiaiThuongKhenThuong { get; set; }

    public string? ThiDuaGiaiThuongKhenThuong { get; set; }

    public virtual ICollection<TbDanhHieuThiDuaGiaiThuongKhenThuongCanBo> TbDanhHieuThiDuaGiaiThuongKhenThuongCanBos { get; set; } = new List<TbDanhHieuThiDuaGiaiThuongKhenThuongCanBo>();

    public virtual TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd? TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd { get; set; }

    public virtual ICollection<TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc> TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocs { get; set; } = new List<TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc>();
}
