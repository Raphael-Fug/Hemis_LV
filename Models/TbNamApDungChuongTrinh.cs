using System;
using System.Collections.Generic;

namespace C500Hemis.Models;

public partial class TbNamApDungChuongTrinh
{
    public int IdNamApDungChuongTrinh { get; set; }

    public int? IdChuongTrinhDaoTao { get; set; }

    public int? SoTinChiToiThieuDeTotNghiep { get; set; }

    public int? TongHocPhiToanKhoa { get; set; }

    public DateOnly? NamApDung { get; set; }

    public int? ChiTieuTuyenSinhHangNam { get; set; }

    public virtual TbChuongTrinhDaoTao? IdChuongTrinhDaoTaoNavigation { get; set; }
}
