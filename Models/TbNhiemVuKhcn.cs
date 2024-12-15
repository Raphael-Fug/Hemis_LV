using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;
/*Chỉnh sửa 10/10/24:
+) Việt hóa tên hiển thị tất cả các trường 
+) Định dạng format ngày/tháng/năm 
+) Định dạng format của Tổng kinh phí 
+) Bắt buộc Required đối với 5 trường bắt buộc phải nhập 
*/

public partial class TbNhiemVuKhcn
{
    [Display(Name = "Mã quản lí nhiệm vụ")]
    public int IdNhiemVuKhcn { get; set; }

    //Bắt buộc phải nhập 

    [Display(Name = "Mã nhiệm vụ")]
    public string? MaNhiemVu { get; set; }

    //Bắt buộc phải nhập 

    [Display(Name = "Tên nhiệm vụ")]
    public string? TenNhiemVu { get; set; }

    //Bắt buộc phải chọn

    [Display(Name = "Cấp quản lí nhiệm vụ")]
    public int? IdCapQuanLyNhiemVu { get; set; }


    [Display(Name = "Cơ quan chủ quản")]
    public int? IdCoQuanChuQuan { get; set; }


    [Display(Name = "Cơ quan chủ trì ")]
    public string? CoQuanChuTri { get; set; }


    [Display(Name = "Người chủ trì ")]
    public string? NguoiChuTri { get; set; }

    [Display(Name = "Phân loại nhiệm vụ")]

    //Bắt buộc phải chọn  
    public int? IdPhanLoaiNhiemVu { get; set; }


    [Display(Name = "Thuộc loại nhiệm vụ")]
    public string? ThuocNhiemVu { get; set; }


    [Display(Name = "Lĩnh vực nghiên cứu")]
    public int? IdLinhVucNghienCuu { get; set; }


    [Display(Name = "Tổng nguồn kinh phí")]
    public string? TongKinhPhiCuaNhiemVu { get; set; }

    [Display(Name = "Nguồn kinh phí")]

    public int? IdNguonKinhPhi { get; set; }

    //Bắt buộc phải nhập theo đúng Form ngày/tháng/năm 

    [Display(Name = "Thời gian bắt đầu")]
    [DataType(DataType.Date)]
    //ĐỊNh dạng cho ngày/tháng/năm và cho phép cập nhật trong Edot 
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
    public DateOnly? ThoiGianBatDau { get; set; }


    [Display(Name = "Thời gian kết thúc")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)] //ĐỊNh dạng cho ngày/tháng/năm và cho phép cập nhật trong Edit 
    public DateOnly? ThoiGianKetThuc { get; set; }

    [Display(Name = "Đánh giá kết quả nhiệm vụ ")]
    public string? DanhGiaKetQuaNhiemVu { get; set; }

    [Display(Name = "Sản phẩm chính của nhiệm vụ")]
    public string? SanPhamChinhCuaNhiemVu { get; set; }

    [Display(Name = "Tình trạng của nhiệm vụ")]
    public int? IdTinhTrangNhiemVu { get; set; }

    public virtual DmPhanCapNhiemVu? IdCapQuanLyNhiemVuNavigation { get; set; }

    public virtual DmCoQuanChuQuan? IdCoQuanChuQuanNavigation { get; set; }

    public virtual DmLinhVucNghienCuu? IdLinhVucNghienCuuNavigation { get; set; }

    public virtual DmNguonKinhPhi? IdNguonKinhPhiNavigation { get; set; }

    public virtual DmLoaiNhiemVu? IdPhanLoaiNhiemVuNavigation { get; set; }

    public virtual DmTinhTrangNhiemVu? IdTinhTrangNhiemVuNavigation { get; set; }

    public virtual ICollection<TbBaiBaoKhdaCongBo> TbBaiBaoKhdaCongBos { get; set; } = new List<TbBaiBaoKhdaCongBo>();

    public virtual ICollection<TbChuyenGiaoCongNgheVaDaoTao> TbChuyenGiaoCongNgheVaDaoTaos { get; set; } = new List<TbChuyenGiaoCongNgheVaDaoTao>();

    public virtual ICollection<TbHoatDongBaoVeMoiTruong> TbHoatDongBaoVeMoiTruongs { get; set; } = new List<TbHoatDongBaoVeMoiTruong>();

    public virtual ICollection<TbSachDaXuatBan> TbSachDaXuatBans { get; set; } = new List<TbSachDaXuatBan>();

    public virtual ICollection<TbTaiSanTriTue> TbTaiSanTriTues { get; set; } = new List<TbTaiSanTriTue>();
}
