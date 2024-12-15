using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbThuVienTrungTamHocLieu
{

    [DisplayName("ID Thư viện trung tâm học liệu")]
    public int IdThuVienTrungTamHocLieu { get; set; }

    [DisplayName("Tên Thư viện trung tâm học liệu")]
    public string? TenThuVienTrungTamHocLieu { get; set; }

    [DisplayName("Năm đưa vào sử dụng")]
    [DisplayFormat(DataFormatString = "{0:yyyy}", ApplyFormatInEditMode = true)]
    public string? NamDuaVaoSuDung { get; set; }

    [DisplayName("Diện tích")]
    public double? DienTich { get; set; }


    [DisplayName("Diện tích phòng đọc")]
    public double? DienTichPhongDoc { get; set; }

    [DisplayName("Số phòng đọc")]
    public int? SoPhongDoc { get; set; }

    [DisplayName("Số lượng máy tính")]
    public int? SoLuongMayTinh { get; set; }

    [DisplayName("Số lượng chỗ ngồi đọc sách")]
    public int? SoLuongChoNgoi { get; set; }

    [DisplayName("Số lượng sách")]
    public int? SoLuongSach { get; set; }

    [DisplayName("Số lượng tạp chí")]
    public int? SoLuongTapChi { get; set; }

    [DisplayName("Số lượng sách điện tử")]
    public int? SoLuongSachDienTu { get; set; }

    [DisplayName("Số lượng tạp chí điện tử")]
    public int? SoLuongTapChiDienTu { get; set; }


    [DisplayName("Số lượng Thư viện điện tử liên kết nước ngoài")]
    public int? SoLuonngThuVienDienTuLienKetNn { get; set; }

    [DisplayName("Số lượng đầu sách")]
    public int? SoLuongDauSach { get; set; }

    [DisplayName("Số lượng đầu tạp chí")]
    public int? SoLuongDauTapChi { get; set; }

    [DisplayName("Số lượng đầu sách điện tử")]
    public int? SoLuongDauSachDienTu { get; set; }

    [DisplayName("Số lượng đầu tạp chí điện tử")]
    public int? SoLuongDauTapChiDienTu { get; set; }

    [DisplayName(" Hình thức sở hữu")]
    
    public int? IdHinhThucSoHuu { get; set; }

    [DisplayName("ID Hình thức sở hữu")]
    [ForeignKey("IdHinhThucSoHuu")]
    public virtual DmHinhThucSoHuu? IdHinhThucSoHuuNavigation { get; set; }



    [DisplayName("Tình trạng cơ sở vật chất")]
    
    
    public int? IdTinhTrangCsvc { get; set; }

    [DisplayName("ID Tình trạng cơ sở vật chất")]
    [ForeignKey("IdTinhTrangCsvc")]
    public virtual DmTinhTrangCoSoVatChat? IdTinhTrangCsvcNavigation { get; set; }

}