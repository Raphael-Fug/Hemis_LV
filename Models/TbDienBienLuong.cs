using System;
using System.Collections.Generic;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbDienBienLuong
{
    public int IdDienBienLuong { get; set; }

    public int? IdCanBo { get; set; }

    public int? IdTrinhDoDaoTao { get; set; }

    public DateOnly? NgayThangNam { get; set; }

    public int? IdBacLuong { get; set; }

    public int? IdHeSoLuong { get; set; }

    public virtual DmBacLuong1? IdBacLuongNavigation { get; set; }

    public virtual TbCanBo? IdCanBoNavigation { get; set; }

    public virtual DmHeSoLuong? IdHeSoLuongNavigation { get; set; }

    public virtual DmTrinhDoDaoTao? IdTrinhDoDaoTaoNavigation { get; set; }
}
