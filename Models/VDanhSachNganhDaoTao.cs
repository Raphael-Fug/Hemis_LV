using System;
using System.Collections.Generic;

namespace C500Hemis.Models;

public partial class VDanhSachNganhDaoTao
{
    public int? IdNganhDaoTao { get; set; }

    public string? SoQuyetDinhChoPhepMoNganh { get; set; }

    public DateOnly? NgayBanHanhVanBanQuyetDinhMoNganh { get; set; }

    public string? MaNganhMoLanDau { get; set; }

    public string? TenNganhMoLanDau { get; set; }

    public string? CoQuanBanHanh { get; set; }

    public string? NguoiKy { get; set; }

    public string? SoQuyetDinhChoPhepDoiTenNganh { get; set; }

    public DateOnly? NgayBanHanhVanBanQuyetDinhDoiTenNganh { get; set; }

    public string? HinhThucDaoTaoTheoChuyenNgu { get; set; }

    public string? NamBatDauDaoTao { get; set; }

    public string? QuyetDinhTuChu { get; set; }

    public string? TuChuMoNganh { get; set; }

    public int? SoNamDaoTaoThSts { get; set; }

    public string? NamTuyenSinhVaDaoTaoGanNhat { get; set; }

    public int? TongSoNamDaoTaoCuaNganh { get; set; }

    public string? UuTienDaoTaoNhanLucDuLichCntt { get; set; }

    public string? NamBatDauThucHienUuTienDaoTaoNhanLucDuLichCntt { get; set; }

    public string? SoQuyetDinhDaoTaoTuXa { get; set; }

    public DateOnly? NgayQuyetDinhDaoTaoTuXa { get; set; }

    public string? NamBatDauDaoTaoTuXa { get; set; }

    public string? NganhDaoTaoLienKetNuocNgoai { get; set; }

    public string? TrangThaiDaoTao { get; set; }
}
