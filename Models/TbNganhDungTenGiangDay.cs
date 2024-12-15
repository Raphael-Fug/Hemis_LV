using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbNganhDungTenGiangDay
{

    public int IdNganhDungTenGiangDay { get; set; }

    public int? IdCanBo { get; set; }

    public int? IdNganhDaoTao { get; set; }
    public string? TenCanBo { get; set; }
    public string? TenNganhGiangDay { get; set; }

    [DataType(DataType.Date)]
    //NguyenDangPhuc 
    //Nguyen Tan Son
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
    public DateTime? NgayBatDau { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
    public DateTime? NgayKetThuc { get; set; }

    public double? TrongSo { get; set; }

    public virtual TbCanBo? IdCanBoNavigation { get; set; }

    public virtual DmNganhDaoTao? IdNganhDaoTaoNavigation { get; set; }
}
