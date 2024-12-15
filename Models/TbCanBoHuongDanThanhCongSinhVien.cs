using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace C500Hemis.Models;

public partial class TbCanBoHuongDanThanhCongSinhVien
{
    public int IdCanBoHuongDanThanhCongSinhVien { get; set; }
    [DisplayName("STT")]
    public int? IdCanBo { get; set; }
    [DisplayName("Mã Cán Bộ ")]
    public int? IdSinhVien { get; set; }
    [DisplayName("Mã Sinh Viên ")]
    public string? TrachNhiemHuongDan { get; set; }
    [DisplayName("Trách Nhiệm Hướng Dẫn ")]
    public DateOnly? ThoiGianBatDau { get; set; }
    [DisplayName("Thời Gian Bắt Đầu ")]
    public DateOnly? ThoiGianKetThuc { get; set; }
    [DisplayName("Thời Gian Kết Thúc ")]
    public virtual TbCanBo? IdCanBoNavigation { get; set; }
}
