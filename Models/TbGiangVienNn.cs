using System;
using System.Collections.Generic;
using System.ComponentModel;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbGiangVienNn
{

    public int IdGvnn { get; set; }
  
    public int? IdCanBo { get; set; }
    [DisplayName(displayName: "CƠ QUAN CHỦ QUẢN Ở NƯỚC NGOÀI")]
    public string? CoQuanChuQuanOnuocNgoai { get; set; }

    public int? IdNoiDungHoatDongTaiVietNam { get; set; }
    [DisplayName(displayName: "TÊN CÁN BỘ")]
    public virtual TbCanBo? IdCanBoNavigation { get; set; }
    [DisplayName(displayName: "NỘI DUNG HOẠT ĐỘNG TẠI VIỆT NAM")]

    public virtual DmNoiDungHoatDongTaiVietNam? IdNoiDungHoatDongTaiVietNamNavigation { get; set; }
}