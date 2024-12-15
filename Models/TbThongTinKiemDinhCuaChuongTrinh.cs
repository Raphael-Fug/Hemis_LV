using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbThongTinKiemDinhCuaChuongTrinh
{
    [RegularExpression(@"^\d+$", ErrorMessage = "ID phải là số nguyên dương")]
    [Display(Name = "ID")]
    public int IdThongTinKiemDinhCuaChuongTrinh { get; set; }

    [Display(Name = "CHƯƠNG TRÌNH ĐÀO TẠO")]
    public int IdChuongTrinhDaoTao { get; set; }

    [Display(Name = "TỔ CHỨC TÌM KIẾM")]
    public int? IdToChucKiemDinh { get; set; }

    [Display(Name = "KẾT QUẢ KIỂM ĐỊNH")]
    public int? IdKetQuaKiemDinh { get; set; }

    [RegularExpression(@"^\d+$", ErrorMessage = "Số quyết định phải là số nguyên dương")]
    [Display(Name = "SỐ QUYẾT ĐỊNH")]
    public string? SoQuyetDinh { get; set; }

    [Display(Name = "NGÀY CẤP CHỨNG NHẬN")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateOnly? NgayCapChungNhanKiemDinh { get; set; }

    [Display(Name = "THỜI HẠN")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateOnly? ThoiHanKiemDinh { get; set; }

    [Display(Name = "CHƯƠNG TRÌNH ĐÀO TẠO")]
    public virtual TbChuongTrinhDaoTao? IdChuongTrinhDaoTaoNavigation { get; set; } = null!;

    [Display(Name = "KẾT QUẢ KIỂM ĐỊNH")]
    public virtual DmKetQuaKiemDinh? IdKetQuaKiemDinhNavigation { get; set; }

    [Display(Name = "TỔ CHỨC KIỂM ĐỊNH")]
    public virtual DmToChucKiemDinh? IdToChucKiemDinhNavigation { get; set; }
}
