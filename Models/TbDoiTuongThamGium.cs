using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;
public partial class TbDoiTuongThamGium
{
    //B8D55 AT13 Ca Kỳ Hòa

    public int IdDoiTuongThamGia { get; set; }

    [DisplayName(displayName: "Loại tham gia")]
    public int? IdLoaiThamGia { get; set; }

    [DisplayName(displayName: "Mã loại tham gia")]

    public string? MaLoaiThamGia { get; set; }

    [DisplayName(displayName: "Id Người")]
    public int? IdNguoi { get; set; }
    [DisplayName(displayName: "Vai trò")]
    public int? IdVaiTro { get; set; }
    [DisplayName(displayName: "Phân loại")]
    public int? IdPhanLoai { get; set; }

    public virtual DmLoaiThamGium? IdLoaiThamGiaNavigation { get; set; }

    public virtual TbNguoi? IdNguoiNavigation { get; set; }

    public virtual DmPhanLoaiDoiNguNguoiHoc? IdPhanLoaiNavigation { get; set; }

    public virtual DmVaiTroThamGium? IdVaiTroNavigation { get; set; }
}
