using System;
using System.Collections.Generic;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbDoanCongTac
{
    public int IdDoanCongTac { get; set; }

    public string? MaDoanCongTac { get; set; }

    public int? IdPhanLoaiDoanRaDoanVao { get; set; }

    public string? TenDoanCongTac { get; set; }

    public string? SoQuyetDinh { get; set; }

    public DateTime? NgayQuyetDinh { get; set; }

    public int? IdQuocGiaDoan { get; set; }

    public DateOnly? ThoiGianBatDau { get; set; }

    public DateOnly? ThoiGianketThuc { get; set; }

    public string? MucDichCongTac { get; set; }

    public string? KetQuaCongTac { get; set; }

    public virtual DmPhanLoaiDoanRaDoanVao? IdPhanLoaiDoanRaDoanVaoNavigation { get; set; }

    public virtual DmQuocTich? IdQuocGiaDoanNavigation { get; set; }

    public virtual ICollection<TbThanhPhanThamGiaDoanCongTac> TbThanhPhanThamGiaDoanCongTacs { get; set; } = new List<TbThanhPhanThamGiaDoanCongTac>();
}