using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbDuLieuTrungTuyen
{

    [Display(Name = "Id dữ liệu trúng tuyển")]
    public int IdDuLieuTrungTuyen { get; set; }

    [Display(Name = "Số Cccd/ Hộ Chiếu")]
    public string? Cccd { get; set; }

    [Display(Name ="Họ và tên")]
    public string? HoVaTen { get; set; }

    [Display(Name ="Mã tuyển sinh")]
    public string? MaTuyenSinh { get; set; }

    [Display(Name ="Khóa đào tạo trúng tuyển")]
    public string? KhoaDaoTaoTrungTuyen { get; set; }
    
    [Display(Name = "Đối tượng tuyển sinh")]
    public int? IdDoiTuongDauVao { get; set; } // là đối tượng tuyển sinh ( để trùng với DM nên đề đầu vào )

    [Display(Name = "Đối tượng ưu tiên")]
    public int? IdDoiTuongUuTien { get; set; }

    [Display(Name = "Hình thức tuyển sinh")]
    public int? IdHinhThucTuyenSinh { get; set; }

    [Display(Name = "Khu vực tuyển sinh")]
    public int? IdKhuVuc { get; set; }

    [Display(Name = "Trường THPT")]
    public string? TruongThpt { get; set; }

    [Display(Name = "Tổ hợp môn trúng tuyển")]
    public string? ToHopMonTrungTuyen { get; set; }

    [Display(Name = "Điểm môn 1")]
    [Range(0, 10, ErrorMessage = "Điểm môn 1 phải từ 0 đến 10")]
    [RegularExpression(@"\d{1,2}(\.\d{1,2})?", ErrorMessage = "Điểm môn 1 chỉ được có tối đa 2 chữ số thập phân")]
    public double? DiemMon1 { get; set; }

    [Display(Name = "Điểm môn 2")]
    [Range(0, 10, ErrorMessage = "Điểm môn 2 phải từ 0 đến 10")]
    [RegularExpression(@"\d{1,2}(\.\d{1,2})?", ErrorMessage = "Điểm môn 2 chỉ được có tối đa 2 chữ số thập phân")]
    public double? DiemMon2 { get; set; }

    [Display(Name = "Điểm môn 3")]
    [Range(0, 10, ErrorMessage = "Điểm môn 3 phải từ 0 đến 10")]
    [RegularExpression(@"\d{1,2}(\.\d{1,2})?", ErrorMessage = "Điểm môn 3 chỉ được có tối đa 2 chữ số thập phân")]
    public double? DiemMon3 { get; set; }

    [Display(Name = "Điểm ưu tiên")]
    [Range(0, 10, ErrorMessage = "Điểm ưu tiên phải từ 0 đến 10")]
    [RegularExpression(@"\d{1,2}(\.\d{1,2})?", ErrorMessage = "Điểm ưu tiên chỉ được có tối đa 2 chữ số thập phân")]
    public double? DiemUuTien { get; set; }

    [Display(Name = "Tổng điểm xét tuyển")]
    public double? TongDiemXetTuyen { get; set; }

    [Display(Name = "Số quyết định trúng tuyển")]
    public string? SoQuyetDinhTrungTuyen { get; set; }

    [Display(Name = "Ngày ban hành quyết định trúng tuyển")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateOnly? NgayBanHanhQuyetDinhTrungTuyen { get; set; }

    [Display(Name = "Chương trình đào tạo đã tốt nghiệp trình độ đại học")]
    public string? ChuongTrinhDaoTaoDaTotNghiepTrinhDoDaiHoc { get; set; }

    [Display(Name = "Ngành đã tốt nghiệp trình độ đại học")]
    public string? NganhDaTotNghiepTrinhDoDaiHoc { get; set; }

    [Display(Name = "Chương trình đào tạo đã tốt nghệp trình độ thạc sĩ")]
    public string? ChuongTrinhDaoTaoDaTotNghiepTrinhDoThacSi { get; set; }

    [Display(Name = "Ngành đã tốt nghiệp trình độ thạc sĩ")]
    public string? NganhDaTotNghiepTrinhDoThacSi { get; set; }

    public virtual DmDoiTuongDauVao? IdDoiTuongDauVaoNavigation { get; set; }

    public virtual DmDoiTuongUuTien? IdDoiTuongUuTienNavigation { get; set; }

    public virtual DmHinhThucTuyenSinh? IdHinhThucTuyenSinhNavigation { get; set; }

    public virtual DmKhuVuc? IdKhuVucNavigation { get; set; }
}