using System;
using System.Collections.Generic;

namespace C500Hemis.Models;

public partial class VCongTrinhCoSoVatChat
{
    public string? MaCongTrinh { get; set; }

    public string? TenCongTrinh { get; set; }

    public string? LoaiCongTrinhCoSoVatChat { get; set; }

    public string? MucDichSuDungCsvc { get; set; }

    public string? DoiTuongSuDung { get; set; }

    public double? DienTichSanXayDung { get; set; }

    public double? VonBanDau { get; set; }

    public double? VonDauTu { get; set; }

    public string? TinhTrangCoSoVatChat { get; set; }

    public string? HinhThucSoHuu { get; set; }

    public string? CongTrinhCsvctrongNha { get; set; }

    public int? SoPhongOcongVu { get; set; }

    public int? SoChoOchoCanBoGiangDay { get; set; }

    public string? NamDuaVaoSuDung { get; set; }
}
