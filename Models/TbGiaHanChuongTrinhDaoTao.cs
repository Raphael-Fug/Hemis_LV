using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace C500Hemis.Models;

public partial class TbGiaHanChuongTrinhDaoTao
{
    [DisplayName(displayName: "Id Chương Trình Đào Tạo")]
    [Required(ErrorMessage ="Bắt buộc phải nhập ID")]
    public int IdGiaHanChuongTrinhDaoTao { get; set; }
    [DisplayName(displayName: "Tên Chương Trình Đào Tạo")]

    public int? IdChuongTrinhDaoTao { get; set; }


    [DisplayName(displayName: "Số Quyết Định Gia Hạn")]
    public string? SoQuyetDinhGiaHan { get; set; }

    [DisplayName(displayName: "Ngày Ban Hành Văn Bản Gia Hạn")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateOnly? NgayBanHanhVanBanGiaHan { get; set; }
    [DisplayName(displayName: "Số Lần Gia Hạn")]
    
    public int? GiaHanLanThu { get; set; }
    [DisplayName(displayName: "ID Chương Trình Đào Tạo")]
    public virtual TbChuongTrinhDaoTao? IdChuongTrinhDaoTaoNavigation { get; set; }
}