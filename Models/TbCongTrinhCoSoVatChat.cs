using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbCongTrinhCoSoVatChat
{
    [DisplayName("ID công trình cơ sở vật chất")]
    public int IdCongTrinhCoSoVatChat { get; set; }
    [DisplayName("Mã công trình")]
    [Required(ErrorMessage = "Ô này không được để trống")]
    public string? MaCongTrinh { get; set; }
    [DisplayName("Tên công trình")]
    [Required(ErrorMessage = "Ô này không được để trống")]
    public string? TenCongTrinh { get; set; }
    [DisplayName("Loại công trình")]
    [Required(ErrorMessage = "Ô này không được để trống")]
    public int? IdLoaiCongTrinh { get; set; }
    [DisplayName("Mục đích sử dụng")]
    [Required(ErrorMessage = "Ô này không được để trống")]
    public int? IdMucDichSuDung { get; set; }
    [DisplayName("Đối tượng sử dụng")]
    public string? DoiTuongSuDung { get; set; }
    [DisplayName("Diện tích xây dựng")]
    [Required(ErrorMessage = "Ô này không được để trống")]
    public double? DienTichSanXayDung { get; set; }
    [DisplayName("Vốn ban đầu")]
    public double? VonBanDau { get; set; }
    [DisplayName("Vốn đầu tư")]
    public double? VonDauTu { get; set; }
    [DisplayName("Tình trạng CSVC")]
    public int? IdTinhTrangCsvc { get; set; }
    [DisplayName("Hình thức sở hữu")]
    public int? IdHinhThucSoHuu { get; set; }
    [DisplayName("Công trình CSVC trong nhà")]
    public int? CongTrinhCsvctrongNha { get; set; }
    [DisplayName("Số phòng ở công vụ")]
    public int? SoPhongOcongVu { get; set; }
    [DisplayName("Số chỗ ở cho cán bộ giảng dạy")]
    public int? SoChoOchoCanBoGiangDay { get; set; }
    [DisplayName("Năm đưa vào sử dụng")]
    // Đưa vào định dạng yyyy
    public string? NamDuaVaoSuDung { get; set; }

    public virtual DmTuyChon? CongTrinhCsvctrongNhaNavigation { get; set; }
    public virtual DmHinhThucSoHuu? IdHinhThucSoHuuNavigation { get; set; }

    public virtual DmLoaiCongTrinhCoSoVatChat? IdLoaiCongTrinhNavigation { get; set; }

    public virtual DmMucDichSuDungCsvc? IdMucDichSuDungNavigation { get; set; }

    public virtual DmTinhTrangCoSoVatChat? IdTinhTrangCsvcNavigation { get; set; }

    public virtual ICollection<TbPhongThiNghiem> TbPhongThiNghiems { get; set; } = new List<TbPhongThiNghiem>();

    public virtual ICollection<TbPhongThucHanh> TbPhongThucHanhs { get; set; } = new List<TbPhongThucHanh>();

    public virtual ICollection<TbThietBiPtnThtren500Tr> TbThietBiPtnThtren500Trs { get; set; } = new List<TbThietBiPtnThtren500Tr>();
}