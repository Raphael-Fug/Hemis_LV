using System;
using System.Collections.Generic;
using System.ComponentModel;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbPhongHocGiangDuongHoiTruong
{
    public int IdPhongHocGiangDuongHoiTruong { get; set; }
    [DisplayName("STT ")]
    public string? MaPhongHocGiangDuongHoiTruong { get; set; }
    [DisplayName("Mã Số ")]
    public string? TenPhongHocGiangDuongHoiTruong { get; set; }
    [DisplayName("Tên Phòng Học ")]
    public double? DienTich { get; set; }
    [DisplayName("Diện Tích ")]
    public int? IdHinhThucSoHuu { get; set; }
    [DisplayName("Hình Thức Sở Hữu ")]
    public int? QuyMoChoNgoi { get; set; }
    [DisplayName("Quy Mô ")]
    public int? IdTinhTrangCoSoVatChat { get; set; }
    [DisplayName("Tình Trạng Cơ Sở Vật Chất ")]
    public int? IdPhanLoaiCsvc { get; set; }
    [DisplayName("Phân Loại Cơ Sở Vật Chất ")]
    public int? IdLoaiPhongHoc { get; set; }
    [DisplayName("Loại Phòng Học ")]
    public int? IdLoaiDeAn { get; set; }
    [DisplayName("Loại Đề Án ")]
    public string? NamDuaVaoSuDung { get; set; }
    [DisplayName("Năm Đưa Vào Sử Dụng ")]
    public virtual DmHinhThucSoHuu? IdHinhThucSoHuuNavigation { get; set; }
    
    public virtual DmLoaiDeAnChuongTrinh? IdLoaiDeAnNavigation { get; set; }
    
    public virtual DmLoaiPhongHoc? IdLoaiPhongHocNavigation { get; set; }
    
    public virtual DmPhanLoaiCsvc? IdPhanLoaiCsvcNavigation { get; set; }
   
    public virtual DmTinhTrangCoSoVatChat? IdTinhTrangCoSoVatChatNavigation { get; set; }
    
}
