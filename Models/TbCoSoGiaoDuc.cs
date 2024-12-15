using System;
using System.Collections.Generic;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbCoSoGiaoDuc
{
    public int IdCoSoGiaoDuc { get; set; }

    public string? MaDonVi { get; set; }

    public string? TenDonVi { get; set; }

    public string? TenTiengAnh { get; set; }

    public int? IdHinhThucThanhLap { get; set; }

    public int? IdLoaiHinhTruong { get; set; }

    public string? SoQuyetDinhChuyenDoiLoaiHinh { get; set; }

    public DateOnly? NgayKyQuyetDinhChuyenDoiLoaiHinh { get; set; }

    public string? TenDaiHocTrucThuoc { get; set; }

    public string? SoDienThoai { get; set; }

    public string? Fax { get; set; }

    public string? Email { get; set; }

    public string? DiaChiWebsite { get; set; }

    public int? IdCoQuanChuQuan { get; set; }

    public string? SoQuyetDinhThanhLap { get; set; }

    public DateOnly? NgayKyQuyetDinhThanhLap { get; set; }

    public string? DiaChi { get; set; }

    public int? IdTinh { get; set; }

    public int? IdHuyen { get; set; }

    public int? IdXa { get; set; }

    public int? HoatDongKhongLoiNhuan { get; set; }

    public string? SoQuyetDinhCapPhepHoatDong { get; set; }

    public DateOnly? NgayDuocCapPhepHoatDong { get; set; }

    public int? IdLoaiHinhCoSoDaoTao { get; set; }

    public int? SoGiaoVienGdtc { get; set; }

    public int? IdPhanLoaiCoSo { get; set; }

    public int? TuChuGiaoDucQpan { get; set; }

    public string? SoQuyetDinhGiaoTuChu { get; set; }

    public int? DaoTaoSvgdqpan1nam { get; set; }

    public string? SoQuyetDinhBanHanhQuyCheTaiChinh { get; set; }

    public DateOnly? NgayKyQuyetDinhBanHanhQuyCheTaiChinh { get; set; }

    public virtual DmTuyChon? HoatDongKhongLoiNhuanNavigation { get; set; }

    public virtual DmCoQuanChuQuan? IdCoQuanChuQuanNavigation { get; set; }

    public virtual DmHinhThucThanhLap? IdHinhThucThanhLapNavigation { get; set; }

    public virtual DmHuyen? IdHuyenNavigation { get; set; }

    public virtual DmLoaiHinhCoSoDaoTao? IdLoaiHinhCoSoDaoTaoNavigation { get; set; }

    public virtual DmLoaiHinhTruong? IdLoaiHinhTruongNavigation { get; set; }

    public virtual DmPhanLoaiCoSo? IdPhanLoaiCoSoNavigation { get; set; }

    public virtual DmTinh? IdTinhNavigation { get; set; }

    public virtual DmXa? IdXaNavigation { get; set; }

    public virtual ICollection<TbDonViLienKetDaoTaoGiaoDuc> TbDonViLienKetDaoTaoGiaoDucs { get; set; } = new List<TbDonViLienKetDaoTaoGiaoDuc>();

    public virtual DmTuyChon? TuChuGiaoDucQpanNavigation { get; set; }
}
