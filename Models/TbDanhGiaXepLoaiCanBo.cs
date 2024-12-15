using System;
using System.Collections.Generic;
using System.ComponentModel;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbDanhGiaXepLoaiCanBo
{
    [DisplayName("ID Đánh Giá Xếp Loại Cán Bộ")]
    public int IdDanhGiaXepLoaiCanBo { get; set; }

    [DisplayName("ID Cán Bộ")]
    public int? IdCanBo { get; set; }

    [DisplayName("ID Đánh Giá")]
    public int? IdDanhGia { get; set; }

    [DisplayName("ID Năm Đánh Giá")]
    public DateOnly? NamDanhGia { get; set; }

    [DisplayName("ID Nghành Được Khen Thưởng")]
    public string? NganhDuocKhenThuong { get; set; }

    [DisplayName("ID Cán Bộ Navigation")]
    public virtual TbCanBo? IdCanBoNavigation { get; set; }

    [DisplayName("ID Đánh Giá Navigation")]
    public virtual DmDanhGiaCongChucVienChuc? IdDanhGiaNavigation { get; set; }
}
