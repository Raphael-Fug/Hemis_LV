using System;
using System.Collections.Generic;

namespace C500Hemis.Models;

public partial class VDuLieuTrungTuyen
{
    public string? Cccd { get; set; }

    public string? HoVaTen { get; set; }

    public string? MaTuyenSinh { get; set; }

    public string? KhoaDaoTaoTrungTuyen { get; set; }

    public string? DoiTuongDauVao { get; set; }

    public string? DoiTuongUuTien { get; set; }

    public string? HinhThucTuyenSinh { get; set; }

    public string? KhuVuc { get; set; }

    public string? TruongThpt { get; set; }

    public string? ToHopMonTrungTuyen { get; set; }

    public double? DiemMon1 { get; set; }

    public double? DiemMon2 { get; set; }

    public double? DiemMon3 { get; set; }

    public double? DiemUuTien { get; set; }

    public double? TongDiemXetTuyen { get; set; }

    public string? SoQuyetDinhTrungTuyen { get; set; }

    public DateOnly? NgayBanHanhQuyetDinhTrungTuyen { get; set; }

    public string? ChuongTrinhDaoTaoDaTotNghiepTrinhDoDaiHoc { get; set; }

    public string? NganhDaTotNghiepTrinhDoDaiHoc { get; set; }

    public string? ChuongTrinhDaoTaoDaTotNghiepTrinhDoThacSi { get; set; }

    public string? NganhDaTotNghiepTrinhDoThacSi { get; set; }
}
