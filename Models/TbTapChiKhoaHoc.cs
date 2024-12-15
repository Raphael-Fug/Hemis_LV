using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbTapChiKhoaHoc
{
    //B8D55 AT13 Ca Kỳ Hòa
    [DisplayName(displayName: "ID tạp chí khoa học")]
    public int IdTapChiKhoaHoc { get; set; }

    [DisplayName(displayName: "Mã tạp chí")]
    [StringLength(36,ErrorMessage= "Mã tạp chí không quá 36 kí tự")]
    public string? MaTapChi { get; set; }

    [DisplayName(displayName: "Tên tạp chí tiếng Việt")]
    [StringLength(255, ErrorMessage = "Tên tạp chí không quá 255 kí tự")]
    public string? TenTapChiTiengViet { get; set; }
    [DisplayName(displayName: "Tên tạp chí tiếng Anh")]
    public string? TenTapChiTiengAnh { get; set; }
    [DisplayName(displayName: "Mã Chuẩn ISSN")]
    [RegularExpression(@"^\d{4}-\d{4}$", ErrorMessage ="Hãy nhập theo định dạng ****-****")]
    public string? MaChuanIssn { get; set; }
    [DisplayName(displayName: "ID lĩnh vực xuất bản")]
    public int? IdLinhVucXuatBan { get; set; }
    [DisplayName(displayName: "ID xếp loại tạp chí")]
    public int? IdXepLoaiTapChi { get; set; }
    [DisplayName(displayName: "Số bài báo 1 năm")]
    public int? SoBaiBao1Nam { get; set; }

    public virtual DmLinhVucNghienCuu? IdLinhVucXuatBanNavigation { get; set; }

    public virtual DmTapChiTrongNuoc? IdXepLoaiTapChiNavigation { get; set; }
}
