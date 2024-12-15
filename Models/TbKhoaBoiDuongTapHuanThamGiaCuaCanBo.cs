using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbKhoaBoiDuongTapHuanThamGiaCuaCanBo
{
    public int IdKhoaBoiDuongTapHuanThamGiaCuaCanBo { get; set; }

    public int? IdCanBo { get; set; }

    public string? TenKhoaBoiDuongTapHuan { get; set; }

    public string? DonViToChuc { get; set; }

    public int? IdLoaiBoiDuong { get; set; }

    public string? DiaDiemToChuc { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]

    public DateOnly? ThoiGianBatDau { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateOnly? ThoiGianKetThuc { get; set; }

    public int? IdNguonKinhPhi { get; set; }

    public string? ChungChi { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateOnly? NgayCap { get; set; }

    public virtual TbCanBo? IdCanBoNavigation { get; set; }

    public virtual DmLoaiBoiDuong? IdLoaiBoiDuongNavigation { get; set; }

    public virtual DmNguonKinhPhi? IdNguonKinhPhiNavigation { get; set; }
}
