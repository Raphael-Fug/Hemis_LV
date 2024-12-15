using System;
using System.Collections.Generic;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbDonViCongTacCuaCanBo
{
    public int IdDvct { get; set; }

    public int? IdCanBo { get; set; }

    public string? MaPhongBanDonVi { get; set; }

    public int? IdChucVu { get; set; }

    public int? IdHinhThucBoNhiem { get; set; }

    public string? SoQuyetDinh { get; set; }

    public DateOnly? NgayQuyetDinh { get; set; }

    public bool? LaDonViChinh { get; set; }

    public bool? LaDonViGiangDay { get; set; }

    public DateOnly? ThoiGianCoHieuLuc { get; set; }

    public DateOnly? ThoiGianHetHieuLuc { get; set; }

    public virtual TbCanBo? IdCanBoNavigation { get; set; }

    public virtual DmChucVu? IdChucVuNavigation { get; set; }

    public virtual DmHinhThucBoNhiem? IdHinhThucBoNhiemNavigation { get; set; }
}
