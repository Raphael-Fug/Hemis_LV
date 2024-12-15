using System;
using System.Collections.Generic;

namespace C500Hemis.Models;

public partial class VChuongTrinhDaoTao
{
    public string? NganhDaoTao { get; set; }

    public string? MaChuongTrinhDaoTao { get; set; }

    public string? TenChuongTrinh { get; set; }

    public string? TenChuongTrinhBangTiengAnh { get; set; }

    public DateOnly? NamBatDauTuyenSinh { get; set; }

    public string? TenCoSoDaoTaoNuocNgoai { get; set; }

    public string? LoaiChuongTrinhDaoTao { get; set; }

    public string? LoaiChuongTrinhLienKetDaoTao { get; set; }

    public string? DiaDiemDaoTao { get; set; }

    public string? HocCheDaoTao { get; set; }

    public string? TenNuoc { get; set; }

    public DateOnly? NgayBanHanhChuanDauRa { get; set; }

    public string? TrinhDoDaoTao { get; set; }

    public int? ThoiGianDaoTaoChuan { get; set; }

    public string? ChuanDauRa { get; set; }

    public string? DonViCapBang { get; set; }

    public string? LoaiChungChiDuocChapThuan { get; set; }

    public string? DonViThucHienChuongTrinh { get; set; }

    public string? TrangThaiChuongTrinhDaoTao { get; set; }

    public string? ChuanDauRaVeNgoaiNgu { get; set; }

    public string? ChuanDauRaVeTinHoc { get; set; }

    public int? HocPhiTaiVietNam { get; set; }

    public int? HocPhiTaiNuocNgoai { get; set; }
}
