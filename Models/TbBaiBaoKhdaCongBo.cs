using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbBaiBaoKhdaCongBo
{
    /*Đặt tên cột*/
    [DisplayName(displayName: "ID Bài Báo KH Đã Công Bố")]
    public int IdBaiBaoKhdaCongBo { get; set; }
    [DisplayName(displayName: "Tên Nhiệm Vụ KHCN")]

    public int? IdNhiemVuKhcn { get; set; }
    [DisplayName(displayName: "Mã Bài Báo KH")]
    [StringLength(36, ErrorMessage = "Nhập tối đa 36 ký tự")]
    public string? MaBaiBaoKh { get; set; }
    [DisplayName(displayName: "Tên Bài Báo KH")]
    [StringLength(255, ErrorMessage = "Nhập tối đa 255 ký tự")]
    public string? TenBaiBaoKh { get; set; }
    [DisplayName(displayName: "Tên Tạp Chí")]
    public string? TenTapChi { get; set; }
    [DisplayName(displayName: "Tạp Chí Trong Nước")]
    public int? IdTapChiTrongNuoc { get; set; }
    [DisplayName(displayName: "Tạp Chí Quốc Tế")]
    public int? IdTapChiQuocTe { get; set; }
    [DisplayName(displayName: "Xếp Hạng Q")]
    public int? IdXepHangQ { get; set; }
    [DisplayName(displayName: "Ghi Chú Đường Dẫn Bài Báo")]
    public string? GhiChuDuongDanBaiBao { get; set; }
    [DisplayName(displayName: "Tập Số")]
    public int? TapSo { get; set; }
    [DisplayName(displayName: "Trang")]
    public int? Trang { get; set; }
    [DisplayName(displayName: "Năm Công Bố")]
    public string? NamCongBo { get; set; }
    [DisplayName(displayName: "Tên Nhiệm Vụ KHCN")]
    public virtual TbNhiemVuKhcn? IdNhiemVuKhcnNavigation { get; set; }
    [DisplayName(displayName: "Tạp Chí Quốc Tế")]
    public virtual DmTapChiKhoaHocQuocTe? IdTapChiQuocTeNavigation { get; set; }
    [DisplayName(displayName: "Tạp Trí Trong Nước")]
    public virtual DmTapChiTrongNuoc? IdTapChiTrongNuocNavigation { get; set; }
    [DisplayName(displayName: " Xếp Hạng Q")]
    public virtual DmXepHangQ? IdXepHangQNavigation { get; set; }
}