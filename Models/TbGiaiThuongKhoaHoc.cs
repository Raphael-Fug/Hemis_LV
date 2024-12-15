using System;
using System.Collections.Generic;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbGiaiThuongKhoaHoc
{
    public int IdGiaiThuongKhoaHoc { get; set; }

    public string? MaGiaiThuong { get; set; }

    public int? IdLoaiGiaiThuong { get; set; }

    public string? CoQuanToChucGiaiThuong { get; set; }

    public string? TenDeTaiDuocTraoGiai { get; set; }

    public string? TenDonViDuocTraoGiai { get; set; }

    public int? IdMucGiaiThuong { get; set; }

    public string? QuyetDinhCapBangKhen { get; set; }

    public string? CoQuanBanHanhQuyetDinh { get; set; }

    public virtual DmLoaiGiaiThuongKhcn? IdLoaiGiaiThuongNavigation { get; set; }

    public virtual DmMucGiaiThuong? IdMucGiaiThuongNavigation { get; set; }
}
