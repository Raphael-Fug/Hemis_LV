using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;
public partial class TbDatDai
{
    public int IdDatDai { get; set; }

    [DisplayName("Mã giấy chứng nhận quyền sở hữu ")]

    public string? MaGiayChungNhanQuyenSoHuu { get; set; }
    [DisplayName("Diện tích đất(m2) ")]

    public double? DienTichDat { get; set; }

    public int? IdHinhThucSoHuu { get; set; }
    [DisplayName("Tên Đơn Vị Sở Hữu ")]
    public string? TenDonViSoHuu { get; set; }
    [DisplayName("Minh Chứng Quyền Sở Hữu Đất Đai")]
    public string? MinhChungQuyenSoHuuDatDai { get; set; }
    [DisplayName("Mục Đích Sử Sụng Đất")]
    public string? MucDichSuDungDat { get; set; }

    //[DataType(DataType.Date)]
    //[DisplayFormat(DataFormatString = "{0:yyyy}")]
    [DisplayName("Năm Bắt Đầu Sử Dụng")]
    public string? NamBatDauSuDungDat { get; set; }
    [DisplayName("Thời Gian Sử Dụng Đất")]
    public int? ThoiGianSuDungDat { get; set; }
    [DisplayName("Diện Tích Đất Đã Sử Dụng (m2)")]

    public double? DienTichDatDaSuDung { get; set; }
    [DisplayName("Hình Thức Sở Hữu")]
    public virtual DmHinhThucSoHuu? IdHinhThucSoHuuNavigation { get; set; }
}
