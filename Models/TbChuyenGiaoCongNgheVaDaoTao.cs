using System;
using System.Collections.Generic;
using System.ComponentModel;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbChuyenGiaoCongNgheVaDaoTao
{
    //[DisplayName(displayName: "NỘI DUNG HOẠT ĐỘNG TẠI VIỆT NAM")]
    public int IdChuyenGiaoCongNgheVaDaoTao { get; set; }

    public int? IdNhiemVuKhcn { get; set; }

    public string? MaSoHopDong { get; set; }

    public string? Ten { get; set; }

    public int? TongChiPhiThucHien { get; set; }

    public int? TongThoiGianThucHien { get; set; }

    public int? IdHinhThucChuyenGiaoCongNghe { get; set; }

    public string? PhuongThucChuyenGiaoCongNghe { get; set; }

    public string? ChuSoHuu { get; set; }

    public string? DonViChuTri { get; set; }

    public string? DonViPhoiHop { get; set; }

    public string? DonViNhanChuyenGiao { get; set; }

    public string? TomTat { get; set; }

    public string? TenDuAn { get; set; }

    public int? GiaTriHopDong { get; set; }

    public int? IdNganhKinhTe { get; set; }

    public int? IdTrangThaiHopDong { get; set; }

    public int? SoNguoiDuocDaoTaoChuyenGiaoCn { get; set; }

    public int? IdLinhVucNghienCuu { get; set; }

    public virtual DmHinhThucChuyenGiaoCongNghe? IdHinhThucChuyenGiaoCongNgheNavigation { get; set; }

    public virtual DmLinhVucNghienCuu? IdLinhVucNghienCuuNavigation { get; set; }

    public virtual DmNganhKinhTe? IdNganhKinhTeNavigation { get; set; }

    public virtual TbNhiemVuKhcn? IdNhiemVuKhcnNavigation { get; set; }

    public virtual DmTrangThaiHopDong? IdTrangThaiHopDongNavigation { get; set; }
}
