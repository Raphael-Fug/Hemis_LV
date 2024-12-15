using System;
using System.Collections.Generic;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbLuuHocSinhSinhVienNn
{
    public int IdLuuHocSinhSinhVienNn { get; set; }

    public int? IdNguoiHoc { get; set; }

    public int? IdNguonKinhPhiLuuHocSinh { get; set; }

    public int? IdLoaiLuuHocSinh { get; set; }

    public virtual DmLoaiLuuHocSinh? IdLoaiLuuHocSinhNavigation { get; set; }

    public virtual DmNguonKinhPhiChoLuuHocSinh? IdNguonKinhPhiLuuHocSinhNavigation { get; set; }
}
