using System;
using System.Collections.Generic;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbQuaTrinhDaoTaoCuaCanBo
{
    public int IdQuaTrinhDaoTaoCuaCanBo { get; set; }

    public int? IdCanBo { get; set; }

    public int? IdTrinhDoDaoTao { get; set; }

    public int? IdQuocGiaDaoTao { get; set; }

    public string? CoSoDaoTao { get; set; }

    public DateOnly? ThoiGianBatDau { get; set; }

    public DateOnly? ThoiGianKetThuc { get; set; }

    public int? IdNganhDaoTao { get; set; }

    public DateOnly? NamTotNghiep { get; set; }

    public int? IdLoaiHinhDaoTao { get; set; }

    public virtual TbCanBo? IdCanBoNavigation { get; set; }

    public virtual DmLoaiHinhDaoTao? IdLoaiHinhDaoTaoNavigation { get; set; }

    public virtual DmNganhDaoTao? IdNganhDaoTaoNavigation { get; set; }

    public virtual DmQuocTich? IdQuocGiaDaoTaoNavigation { get; set; }

    public virtual DmTrinhDoDaoTao? IdTrinhDoDaoTaoNavigation { get; set; }
}
