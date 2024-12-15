using System;
using System.Collections.Generic;
using C500Hemis.Models.DM;
using Microsoft.EntityFrameworkCore;

namespace C500Hemis.Models;

public partial class HemisContext : DbContext
{
    public HemisContext()
    {
    }

    public HemisContext(DbContextOptions<HemisContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DmBacLuong> DmBacLuongs { get; set; }

    public virtual DbSet<DmBacLuong1> DmBacLuongs1 { get; set; }

    public virtual DbSet<DmCapHoiNghi> DmCapHoiNghis { get; set; }

    public virtual DbSet<DmCapKhenThuong> DmCapKhenThuongs { get; set; }

    public virtual DbSet<DmChuSoHuu> DmChuSoHuus { get; set; }

    public virtual DbSet<DmChucDanhGiangVien> DmChucDanhGiangViens { get; set; }

    public virtual DbSet<DmChucDanhHoiDong> DmChucDanhHoiDongs { get; set; }

    public virtual DbSet<DmChucDanhKhoaHoc> DmChucDanhKhoaHocs { get; set; }

    public virtual DbSet<DmChucDanhNckh> DmChucDanhNckhs { get; set; }

    public virtual DbSet<DmChucDanhNgheNghiep> DmChucDanhNgheNghieps { get; set; }

    public virtual DbSet<DmChucDanhPhongBan> DmChucDanhPhongBans { get; set; }

    public virtual DbSet<DmChucVu> DmChucVus { get; set; }

    public virtual DbSet<DmChuongTrinhDaoTao> DmChuongTrinhDaoTaos { get; set; }

    public virtual DbSet<DmCoQuanBanHanh> DmCoQuanBanHanhs { get; set; }

    public virtual DbSet<DmCoQuanChuQuan> DmCoQuanChuQuans { get; set; }

    public virtual DbSet<DmDanToc> DmDanTocs { get; set; }

    public virtual DbSet<DmDangTaiLieu> DmDangTaiLieus { get; set; }

    public virtual DbSet<DmDanhGiaCongChucVienChuc> DmDanhGiaCongChucVienChucs { get; set; }

    public virtual DbSet<DmDanhHieuVinhDuGiaiThuong> DmDanhHieuVinhDuGiaiThuongs { get; set; }

    public virtual DbSet<DmDaoTaoGdqpan> DmDaoTaoGdqpans { get; set; }

    public virtual DbSet<DmDauMoiLienHe> DmDauMoiLienHes { get; set; }

    public virtual DbSet<DmDoiTuongChinhSach> DmDoiTuongChinhSaches { get; set; }

    public virtual DbSet<DmDoiTuongDauVao> DmDoiTuongDauVaos { get; set; }

    public virtual DbSet<DmDoiTuongUuTien> DmDoiTuongUuTiens { get; set; }

    public virtual DbSet<DmDonViCapBang> DmDonViCapBangs { get; set; }

    public virtual DbSet<DmGioiTinh> DmGioiTinhs { get; set; }

    public virtual DbSet<DmHangThuongBinh> DmHangThuongBinhs { get; set; }

    public virtual DbSet<DmHeSoLuong> DmHeSoLuongs { get; set; }

    public virtual DbSet<DmHinhThucBoNhiem> DmHinhThucBoNhiems { get; set; }

    public virtual DbSet<DmHinhThucChuyenGiaoCongNghe> DmHinhThucChuyenGiaoCongNghes { get; set; }

    public virtual DbSet<DmHinhThucDaoTao> DmHinhThucDaoTaos { get; set; }

    public virtual DbSet<DmHinhThucDaoTaoTheoChuyenNgu> DmHinhThucDaoTaoTheoChuyenNgus { get; set; }

    public virtual DbSet<DmHinhThucDoanhNghiepKhcn> DmHinhThucDoanhNghiepKhcns { get; set; }

    public virtual DbSet<DmHinhThucHopTac> DmHinhThucHopTacs { get; set; }

    public virtual DbSet<DmHinhThucSoHuu> DmHinhThucSoHuus { get; set; }

    public virtual DbSet<DmHinhThucThamGiaGvduocCuDiDaoTao> DmHinhThucThamGiaGvduocCuDiDaoTaos { get; set; }

    public virtual DbSet<DmHinhThucThanhLap> DmHinhThucThanhLaps { get; set; }

    public virtual DbSet<DmHinhThucTuyenDung> DmHinhThucTuyenDungs { get; set; }

    public virtual DbSet<DmHinhThucTuyenSinh> DmHinhThucTuyenSinhs { get; set; }

    public virtual DbSet<DmHoGiaDinhChinhSach> DmHoGiaDinhChinhSaches { get; set; }

    public virtual DbSet<DmHoatDongTaiChinh> DmHoatDongTaiChinhs { get; set; }

    public virtual DbSet<DmHocCheDaoTao> DmHocCheDaoTaos { get; set; }

    public virtual DbSet<DmHuyen> DmHuyens { get; set; }

    public virtual DbSet<DmKetQuaKiemDinh> DmKetQuaKiemDinhs { get; set; }

    public virtual DbSet<DmKhoiNganhLinhVucDaoTao> DmKhoiNganhLinhVucDaoTaos { get; set; }

    public virtual DbSet<DmKhuVuc> DmKhuVucs { get; set; }

    public virtual DbSet<DmKhungNangLucNgoaiNgu> DmKhungNangLucNgoaiNgus { get; set; }

    public virtual DbSet<DmLinhVucDaoTao> DmLinhVucDaoTaos { get; set; }

    public virtual DbSet<DmLinhVucNghienCuu> DmLinhVucNghienCuus { get; set; }

    public virtual DbSet<DmLinhVucNhomNganh> DmLinhVucNhomNganhs { get; set; }

    public virtual DbSet<DmLoaiBoiDuong> DmLoaiBoiDuongs { get; set; }

    public virtual DbSet<DmLoaiChuongTrinhDaoTao> DmLoaiChuongTrinhDaoTaos { get; set; }

    public virtual DbSet<DmLoaiChuongTrinhLienKetDaoTao> DmLoaiChuongTrinhLienKetDaoTaos { get; set; }

    public virtual DbSet<DmLoaiCongTrinhCoSoVatChat> DmLoaiCongTrinhCoSoVatChats { get; set; }

    public virtual DbSet<DmLoaiDanhHieuThiDuaGiaiThuongKhenThuong> DmLoaiDanhHieuThiDuaGiaiThuongKhenThuongs { get; set; }

    public virtual DbSet<DmLoaiDeAnChuongTrinh> DmLoaiDeAnChuongTrinhs { get; set; }

    public virtual DbSet<DmLoaiDeTai> DmLoaiDeTais { get; set; }

    public virtual DbSet<DmLoaiGiaiThuongKhcn> DmLoaiGiaiThuongKhcns { get; set; }

    public virtual DbSet<DmLoaiGiangVienQuocPhong> DmLoaiGiangVienQuocPhongs { get; set; }

    public virtual DbSet<DmLoaiHinhCoSoDaoTao> DmLoaiHinhCoSoDaoTaos { get; set; }

    public virtual DbSet<DmLoaiHinhDaoTao> DmLoaiHinhDaoTaos { get; set; }

    public virtual DbSet<DmLoaiHinhTruong> DmLoaiHinhTruongs { get; set; }

    public virtual DbSet<DmLoaiHocBong> DmLoaiHocBongs { get; set; }

    public virtual DbSet<DmLoaiHocVien> DmLoaiHocViens { get; set; }

    public virtual DbSet<DmLoaiHopDong> DmLoaiHopDongs { get; set; }

    public virtual DbSet<DmLoaiKhuyetTat> DmLoaiKhuyetTats { get; set; }

    public virtual DbSet<DmLoaiKyLuat> DmLoaiKyLuats { get; set; }

    public virtual DbSet<DmLoaiLienKet> DmLoaiLienKets { get; set; }

    public virtual DbSet<DmLoaiLuuHocSinh> DmLoaiLuuHocSinhs { get; set; }

    public virtual DbSet<DmLoaiNhiemVu> DmLoaiNhiemVus { get; set; }

    public virtual DbSet<DmLoaiNhiemVuBaoVeMoiTruong> DmLoaiNhiemVuBaoVeMoiTruongs { get; set; }

    public virtual DbSet<DmLoaiPhongBan> DmLoaiPhongBans { get; set; }

    public virtual DbSet<DmLoaiPhongHoc> DmLoaiPhongHocs { get; set; }

    public virtual DbSet<DmLoaiPhongThiNghiem> DmLoaiPhongThiNghiems { get; set; }

    public virtual DbSet<DmLoaiQuyetDinh> DmLoaiQuyetDinhs { get; set; }

    public virtual DbSet<DmLoaiSachTapChi> DmLoaiSachTapChis { get; set; }

    public virtual DbSet<DmLoaiTaiSanTriTue> DmLoaiTaiSanTriTues { get; set; }

    public virtual DbSet<DmLoaiThamGium> DmLoaiThamGia { get; set; }

    public virtual DbSet<DmLoaiToChuc> DmLoaiToChucs { get; set; }

    public virtual DbSet<DmLoaiTotNghiep> DmLoaiTotNghieps { get; set; }

    public virtual DbSet<DmLoaiViPham> DmLoaiViPhams { get; set; }

    public virtual DbSet<DmMucDichSuDungCsvc> DmMucDichSuDungCsvcs { get; set; }

    public virtual DbSet<DmMucGiaiThuong> DmMucGiaiThuongs { get; set; }

    public virtual DbSet<DmMucTieuNhiemVu> DmMucTieuNhiemVus { get; set; }

    public virtual DbSet<DmNgach> DmNgaches { get; set; }

    public virtual DbSet<DmNganhDaoTao> DmNganhDaoTaos { get; set; }

    public virtual DbSet<DmNganhKinhTe> DmNganhKinhTes { get; set; }

    public virtual DbSet<DmNgoaiNgu> DmNgoaiNgus { get; set; }

    public virtual DbSet<DmNguonKinhPhi> DmNguonKinhPhis { get; set; }

    public virtual DbSet<DmNguonKinhPhiChoDeAn> DmNguonKinhPhiChoDeAns { get; set; }

    public virtual DbSet<DmNguonKinhPhiChoLuuHocSinh> DmNguonKinhPhiChoLuuHocSinhs { get; set; }

    public virtual DbSet<DmNguonKinhPhiCuaGvduocCuDiDaoTao> DmNguonKinhPhiCuaGvduocCuDiDaoTaos { get; set; }

    public virtual DbSet<DmNhomNganh> DmNhomNganhs { get; set; }

    public virtual DbSet<DmNoiDungHoatDong> DmNoiDungHoatDongs { get; set; }

    public virtual DbSet<DmNoiDungHoatDongTaiVietNam> DmNoiDungHoatDongTaiVietNams { get; set; }

    public virtual DbSet<DmPhanCapNhiemVu> DmPhanCapNhiemVus { get; set; }

    public virtual DbSet<DmPhanLoaiCoSo> DmPhanLoaiCoSos { get; set; }

    public virtual DbSet<DmPhanLoaiCsvc> DmPhanLoaiCsvcs { get; set; }

    public virtual DbSet<DmPhanLoaiDoanRaDoanVao> DmPhanLoaiDoanRaDoanVaos { get; set; }

    public virtual DbSet<DmPhanLoaiDoiNguNguoiHoc> DmPhanLoaiDoiNguNguoiHocs { get; set; }

    public virtual DbSet<DmPhanLoaiDoiTuong> DmPhanLoaiDoiTuongs { get; set; }

    public virtual DbSet<DmPhanLoaiHoiNghiHoiThao> DmPhanLoaiHoiNghiHoiThaos { get; set; }

    public virtual DbSet<DmPhanLoaiThuChi> DmPhanLoaiThuChis { get; set; }

    public virtual DbSet<DmPhuongThucKhenThuong> DmPhuongThucKhenThuongs { get; set; }

    public virtual DbSet<DmQuanHam> DmQuanHams { get; set; }

    public virtual DbSet<DmQuocTich> DmQuocTiches { get; set; }

    public virtual DbSet<DmQuyetDinhTuChu> DmQuyetDinhTuChus { get; set; }

    public virtual DbSet<DmSangCheGiaiPhap> DmSangCheGiaiPhaps { get; set; }

    public virtual DbSet<DmSinhVienNam> DmSinhVienNams { get; set; }

    public virtual DbSet<DmTapChiKhoaHocQuocTe> DmTapChiKhoaHocQuocTes { get; set; }

    public virtual DbSet<DmTapChiTrongNuoc> DmTapChiTrongNuocs { get; set; }

    public virtual DbSet<DmThiDuaGiaiThuongKhenThuong> DmThiDuaGiaiThuongKhenThuongs { get; set; }

    public virtual DbSet<DmTiengDanToc> DmTiengDanTocs { get; set; }

    public virtual DbSet<DmTinh> DmTinhs { get; set; }

    public virtual DbSet<DmTinhTrangCoSoVatChat> DmTinhTrangCoSoVatChats { get; set; }

    public virtual DbSet<DmTinhTrangGiangVienDuocCuDiDaoTao> DmTinhTrangGiangVienDuocCuDiDaoTaos { get; set; }

    public virtual DbSet<DmTinhTrangHopDong> DmTinhTrangHopDongs { get; set; }

    public virtual DbSet<DmTinhTrangNhiemVu> DmTinhTrangNhiemVus { get; set; }

    public virtual DbSet<DmTinhTrangThietBi> DmTinhTrangThietBis { get; set; }

    public virtual DbSet<DmToChucKiemDinh> DmToChucKiemDinhs { get; set; }

    public virtual DbSet<DmTonGiao> DmTonGiaos { get; set; }

    public virtual DbSet<DmTrangThaiCanBo> DmTrangThaiCanBos { get; set; }

    public virtual DbSet<DmTrangThaiChuongTrinhDaoTao> DmTrangThaiChuongTrinhDaoTaos { get; set; }

    public virtual DbSet<DmTrangThaiCoSoGd> DmTrangThaiCoSoGds { get; set; }

    public virtual DbSet<DmTrangThaiDaoTao> DmTrangThaiDaoTaos { get; set; }

    public virtual DbSet<DmTrangThaiHoc> DmTrangThaiHocs { get; set; }

    public virtual DbSet<DmTrangThaiHopDong> DmTrangThaiHopDongs { get; set; }

    public virtual DbSet<DmTrangThaiThucHien> DmTrangThaiThucHiens { get; set; }

    public virtual DbSet<DmTrinhDo> DmTrinhDos { get; set; }

    public virtual DbSet<DmTrinhDoDaoTao> DmTrinhDoDaoTaos { get; set; }

    public virtual DbSet<DmTrinhDoLyLuanChinhTri> DmTrinhDoLyLuanChinhTris { get; set; }

    public virtual DbSet<DmTrinhDoQuanLyNhaNuoc> DmTrinhDoQuanLyNhaNuocs { get; set; }

    public virtual DbSet<DmTrinhDoTinHoc> DmTrinhDoTinHocs { get; set; }

    public virtual DbSet<DmTuChuMoNganh> DmTuChuMoNganhs { get; set; }

    public virtual DbSet<DmTuyChon> DmTuyChons { get; set; }

    public virtual DbSet<DmVaiTroThamGium> DmVaiTroThamGia { get; set; }

    public virtual DbSet<DmViTriViecLam> DmViTriViecLams { get; set; }

    public virtual DbSet<DmXa> DmXas { get; set; }

    public virtual DbSet<DmXepHangQ> DmXepHangQs { get; set; }

    public virtual DbSet<TbBaiBaoKhdaCongBo> TbBaiBaoKhdaCongBos { get; set; }

    public virtual DbSet<TbCanBo> TbCanBos { get; set; }

    public virtual DbSet<TbCanBoHuongDanThanhCongSinhVien> TbCanBoHuongDanThanhCongSinhViens { get; set; }

    public virtual DbSet<TbChiTietTaiSanDonVi> TbChiTietTaiSanDonVis { get; set; }

    public virtual DbSet<TbChiTietThuChi> TbChiTietThuChis { get; set; }

    public virtual DbSet<TbChiTieuTuyenSinhTheoNganh> TbChiTieuTuyenSinhTheoNganhs { get; set; }

    public virtual DbSet<TbChucDanhKhoaHocCuaCanBo> TbChucDanhKhoaHocCuaCanBos { get; set; }

    public virtual DbSet<TbChuongTrinhDaoTao> TbChuongTrinhDaoTaos { get; set; }

    public virtual DbSet<TbChuyenGiaoCongNgheVaDaoTao> TbChuyenGiaoCongNgheVaDaoTaos { get; set; }

    public virtual DbSet<TbCoCauToChuc> TbCoCauToChucs { get; set; }

    public virtual DbSet<TbCoSoGiaoDuc> TbCoSoGiaoDucs { get; set; }

    public virtual DbSet<TbCongTrinhCoSoVatChat> TbCongTrinhCoSoVatChats { get; set; }

    public virtual DbSet<TbDanhGiaXepLoaiCanBo> TbDanhGiaXepLoaiCanBos { get; set; }

    public virtual DbSet<TbDanhHieuThiDuaGiaiThuongKhenThuongCanBo> TbDanhHieuThiDuaGiaiThuongKhenThuongCanBos { get; set; }

    public virtual DbSet<TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd> TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGds { get; set; }

    public virtual DbSet<TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc> TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocs { get; set; }

    public virtual DbSet<TbDanhSachNganhDaoTao> TbDanhSachNganhDaoTaos { get; set; }

    public virtual DbSet<TbDanhSachVanBangChungChi> TbDanhSachVanBangChungChis { get; set; }

    public virtual DbSet<TbDatDai> TbDatDais { get; set; }

    public virtual DbSet<TbDauMoiLienHe> TbDauMoiLienHes { get; set; }

    public virtual DbSet<TbDeAnDuAnChuongTrinh> TbDeAnDuAnChuongTrinhs { get; set; }

    public virtual DbSet<TbDienBienLuong> TbDienBienLuongs { get; set; }

    public virtual DbSet<TbDoanCongTac> TbDoanCongTacs { get; set; }

    public virtual DbSet<TbDoanhNghiepKhcn> TbDoanhNghiepKhcns { get; set; }

    public virtual DbSet<TbDoiTuongChinhSachCanBo> TbDoiTuongChinhSachCanBos { get; set; }

    public virtual DbSet<TbDoiTuongThamGium> TbDoiTuongThamGia { get; set; }

    public virtual DbSet<TbDonViCongTacCuaCanBo> TbDonViCongTacCuaCanBos { get; set; }

    public virtual DbSet<TbDonViLienKetDaoTaoGiaoDuc> TbDonViLienKetDaoTaoGiaoDucs { get; set; }

    public virtual DbSet<TbDonViThinhGiangCuaCanBo> TbDonViThinhGiangCuaCanBos { get; set; }

    public virtual DbSet<TbDuLieuTrungTuyen> TbDuLieuTrungTuyens { get; set; }

    public virtual DbSet<TbGiaHanChuongTrinhDaoTao> TbGiaHanChuongTrinhDaoTaos { get; set; }

    public virtual DbSet<TbGiaiThuongKhoaHoc> TbGiaiThuongKhoaHocs { get; set; }

    public virtual DbSet<TbGiangVienNn> TbGiangVienNns { get; set; }

    public virtual DbSet<TbGiaoVienQpan> TbGiaoVienQpans { get; set; }

    public virtual DbSet<TbGvduocCuDiDaoTao> TbGvduocCuDiDaoTaos { get; set; }

    public virtual DbSet<TbHinhThucDaoTaoCuaNganh> TbHinhThucDaoTaoCuaNganhs { get; set; }

    public virtual DbSet<TbHoatDongBaoVeMoiTruong> TbHoatDongBaoVeMoiTruongs { get; set; }

    public virtual DbSet<TbHoatDongTaiChinh> TbHoatDongTaiChinhs { get; set; }

    public virtual DbSet<TbHocVien> TbHocViens { get; set; }

    public virtual DbSet<TbHoiThaoHoiNghi> TbHoiThaoHoiNghis { get; set; }

    public virtual DbSet<TbHopDong> TbHopDongs { get; set; }

    public virtual DbSet<TbHopDongThinhGiang> TbHopDongThinhGiangs { get; set; }

    public virtual DbSet<TbKhoaBoiDuongTapHuanThamGiaCuaCanBo> TbKhoaBoiDuongTapHuanThamGiaCuaCanBos { get; set; }

    public virtual DbSet<TbKhoaHoc> TbKhoaHocs { get; set; }

    public virtual DbSet<TbKhoanNopNganSach> TbKhoanNopNganSaches { get; set; }

    public virtual DbSet<TbKhoanTrichLapQuy> TbKhoanTrichLapQuies { get; set; }

    public virtual DbSet<TbKhoiNganhDaoTao> TbKhoiNganhDaoTaos { get; set; }

    public virtual DbSet<TbKiTucXa> TbKiTucXas { get; set; }

    public virtual DbSet<TbKyLuatCanBo> TbKyLuatCanBos { get; set; }

    public virtual DbSet<TbKyLuatNguoiHoc> TbKyLuatNguoiHocs { get; set; }

    public virtual DbSet<TbLichSuDoiTenTruong> TbLichSuDoiTenTruongs { get; set; }

    public virtual DbSet<TbLinhVucNghienCuuCuaCanBo> TbLinhVucNghienCuuCuaCanBos { get; set; }

    public virtual DbSet<TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh> TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganhs { get; set; }

    public virtual DbSet<TbLoaiThuChi> TbLoaiThuChis { get; set; }

    public virtual DbSet<TbLuuHocSinhSinhVienNn> TbLuuHocSinhSinhVienNns { get; set; }

    public virtual DbSet<TbNamApDungChuongTrinh> TbNamApDungChuongTrinhs { get; set; }

    public virtual DbSet<TbNganhDungTenGiangDay> TbNganhDungTenGiangDays { get; set; }

    public virtual DbSet<TbNganhGiangDayCuaCanBo> TbNganhGiangDayCuaCanBos { get; set; }

    public virtual DbSet<TbNgonNguGiangDay> TbNgonNguGiangDays { get; set; }

    public virtual DbSet<TbNguoi> TbNguois { get; set; }

    public virtual DbSet<TbNguoiHocVayTinDung> TbNguoiHocVayTinDungs { get; set; }

    public virtual DbSet<TbNhiemVuKhcn> TbNhiemVuKhcns { get; set; }

    public virtual DbSet<TbNhomNganhDaoTao> TbNhomNganhDaoTaos { get; set; }

    public virtual DbSet<TbNhomNghienCuuManh> TbNhomNghienCuuManhs { get; set; }

    public virtual DbSet<TbPhongHocGiangDuongHoiTruong> TbPhongHocGiangDuongHoiTruongs { get; set; }

    public virtual DbSet<TbPhongThiNghiem> TbPhongThiNghiems { get; set; }

    public virtual DbSet<TbPhongThucHanh> TbPhongThucHanhs { get; set; }

    public virtual DbSet<TbPhuCap> TbPhuCaps { get; set; }

    public virtual DbSet<TbQuaTrinhCongTacCuaCanBo> TbQuaTrinhCongTacCuaCanBos { get; set; }

    public virtual DbSet<TbQuaTrinhDaoTaoCuaCanBo> TbQuaTrinhDaoTaoCuaCanBos { get; set; }

    public virtual DbSet<TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai> TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoais { get; set; }

    public virtual DbSet<TbSachDaXuatBan> TbSachDaXuatBans { get; set; }

    public virtual DbSet<TbTaiSanDonVi> TbTaiSanDonVis { get; set; }

    public virtual DbSet<TbTaiSanTriTue> TbTaiSanTriTues { get; set; }

    public virtual DbSet<TbTapChiKhoaHoc> TbTapChiKhoaHocs { get; set; }

    public virtual DbSet<TbThanhPhanThamGiaDoanCongTac> TbThanhPhanThamGiaDoanCongTacs { get; set; }

    public virtual DbSet<TbThietBiPtnThtren500Tr> TbThietBiPtnThtren500Trs { get; set; }

    public virtual DbSet<TbThoaThuanHopTacQuocTe> TbThoaThuanHopTacQuocTes { get; set; }

    public virtual DbSet<TbThongTinHocBong> TbThongTinHocBongs { get; set; }

    public virtual DbSet<TbThongTinHocTapNghienCuuSinh> TbThongTinHocTapNghienCuuSinhs { get; set; }

    public virtual DbSet<TbThongTinHocTapSinhVien> TbThongTinHocTapSinhViens { get; set; }

    public virtual DbSet<TbThongTinHopTac> TbThongTinHopTacs { get; set; }

    public virtual DbSet<TbThongTinKiemDinhCuaChuongTrinh> TbThongTinKiemDinhCuaChuongTrinhs { get; set; }

    public virtual DbSet<TbThongTinLinhVucDaoTao> TbThongTinLinhVucDaoTaos { get; set; }

    public virtual DbSet<TbThongTinNguoiHocGdtc> TbThongTinNguoiHocGdtcs { get; set; }

    public virtual DbSet<TbThongTinViPham> TbThongTinViPhams { get; set; }

    public virtual DbSet<TbThongTinViecLamSauTotNghiep> TbThongTinViecLamSauTotNghieps { get; set; }

    public virtual DbSet<TbThuVienTrungTamHocLieu> TbThuVienTrungTamHocLieus { get; set; }

    public virtual DbSet<TbToChucHopTacDoanhNghiep> TbToChucHopTacDoanhNghieps { get; set; }

    public virtual DbSet<TbToChucHopTacQuocTe> TbToChucHopTacQuocTes { get; set; }

    public virtual DbSet<TbToChucKiemDinh> TbToChucKiemDinhs { get; set; }

    public virtual DbSet<TbTrinhDoTiengDanToc> TbTrinhDoTiengDanTocs { get; set; }

    public virtual DbSet<TbVanBanTuChu> TbVanBanTuChus { get; set; }

    public virtual DbSet<VBaiBaoKhdaCongBo> VBaiBaoKhdaCongBos { get; set; }

    public virtual DbSet<VChiTietTaiSanDonVi> VChiTietTaiSanDonVis { get; set; }

    public virtual DbSet<VChiTietThuChi> VChiTietThuChis { get; set; }

    public virtual DbSet<VChiTieuTuyenSinhTheoNganh> VChiTieuTuyenSinhTheoNganhs { get; set; }

    public virtual DbSet<VChuongTrinhDaoTao> VChuongTrinhDaoTaos { get; set; }

    public virtual DbSet<VChuyenGiaoCongNgheVaDaoTao> VChuyenGiaoCongNgheVaDaoTaos { get; set; }

    public virtual DbSet<VCoCauToChuc> VCoCauToChucs { get; set; }

    public virtual DbSet<VCoSoGiaoDuc> VCoSoGiaoDucs { get; set; }

    public virtual DbSet<VCongTrinhCoSoVatChat> VCongTrinhCoSoVatChats { get; set; }

    public virtual DbSet<VDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd> VDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGds { get; set; }

    public virtual DbSet<VDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc> VDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocs { get; set; }

    public virtual DbSet<VDanhSachNganhDaoTao> VDanhSachNganhDaoTaos { get; set; }

    public virtual DbSet<VDanhSachVanBangChungChi> VDanhSachVanBangChungChis { get; set; }

    public virtual DbSet<VDatDai> VDatDais { get; set; }

    public virtual DbSet<VDauMoiLienHe> VDauMoiLienHes { get; set; }

    public virtual DbSet<VDeAnDuAnChuongTrinh> VDeAnDuAnChuongTrinhs { get; set; }

    public virtual DbSet<VDoanCongTac> VDoanCongTacs { get; set; }

    public virtual DbSet<VDoanhNghiepKhcn> VDoanhNghiepKhcns { get; set; }

    public virtual DbSet<VDoiTuongThamGium> VDoiTuongThamGia { get; set; }

    public virtual DbSet<VDonViLienKetDaoTaoGiaoDuc> VDonViLienKetDaoTaoGiaoDucs { get; set; }

    public virtual DbSet<VDuLieuTrungTuyen> VDuLieuTrungTuyens { get; set; }

    public virtual DbSet<VGiaHanChuongTrinhDaoTao> VGiaHanChuongTrinhDaoTaos { get; set; }

    public virtual DbSet<VGiaiThuongKhoaHoc> VGiaiThuongKhoaHocs { get; set; }

    public virtual DbSet<VGvduocCuDiDaoTao> VGvduocCuDiDaoTaos { get; set; }

    public virtual DbSet<VHinhThucDaoTaoCuaNganh> VHinhThucDaoTaoCuaNganhs { get; set; }

    public virtual DbSet<VHoatDongBaoVeMoiTruong> VHoatDongBaoVeMoiTruongs { get; set; }

    public virtual DbSet<VHoatDongTaiChinh> VHoatDongTaiChinhs { get; set; }

    public virtual DbSet<VHocVien> VHocViens { get; set; }

    public virtual DbSet<VHoiThaoHoiNghi> VHoiThaoHoiNghis { get; set; }

    public virtual DbSet<VKhoaHoc> VKhoaHocs { get; set; }

    public virtual DbSet<VKhoanNopNganSach> VKhoanNopNganSaches { get; set; }

    public virtual DbSet<VKhoanTrichLapQuy> VKhoanTrichLapQuies { get; set; }

    public virtual DbSet<VKhoiNganhDaoTao> VKhoiNganhDaoTaos { get; set; }

    public virtual DbSet<VKiTucXa> VKiTucXas { get; set; }

    public virtual DbSet<VKyLuatNguoiHoc> VKyLuatNguoiHocs { get; set; }

    public virtual DbSet<VLichSuDoiTenTruong> VLichSuDoiTenTruongs { get; set; }

    public virtual DbSet<VLoaiHinhDaoTaoKhacDuocChoPhepMoNganh> VLoaiHinhDaoTaoKhacDuocChoPhepMoNganhs { get; set; }

    public virtual DbSet<VLoaiThuChi> VLoaiThuChis { get; set; }

    public virtual DbSet<VLuuHocSinhSinhVienNn> VLuuHocSinhSinhVienNns { get; set; }

    public virtual DbSet<VNamApdungChuongTrinh> VNamApdungChuongTrinhs { get; set; }

    public virtual DbSet<VNgonNguGiangDay> VNgonNguGiangDays { get; set; }

    public virtual DbSet<VNguoi> VNguois { get; set; }

    public virtual DbSet<VNguoiHocVayTinDung> VNguoiHocVayTinDungs { get; set; }

    public virtual DbSet<VNhiemVuKhcn> VNhiemVuKhcns { get; set; }

    public virtual DbSet<VNhomNganhDaoTao> VNhomNganhDaoTaos { get; set; }

    public virtual DbSet<VNhomNghienCuuManh> VNhomNghienCuuManhs { get; set; }

    public virtual DbSet<VPhongHocGiangDuongHoiTruong> VPhongHocGiangDuongHoiTruongs { get; set; }

    public virtual DbSet<VPhongThiNghiem> VPhongThiNghiems { get; set; }

    public virtual DbSet<VPhongThucHanh> VPhongThucHanhs { get; set; }

    public virtual DbSet<VQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai> VQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoais { get; set; }

    public virtual DbSet<VSachDaXuatBan> VSachDaXuatBans { get; set; }

    public virtual DbSet<VTaiSanDonVi> VTaiSanDonVis { get; set; }

    public virtual DbSet<VTaiSanTriTue> VTaiSanTriTues { get; set; }

    public virtual DbSet<VTapChiKhoaHoc> VTapChiKhoaHocs { get; set; }

    public virtual DbSet<VThanhPhanThamGiaDoanCongTac> VThanhPhanThamGiaDoanCongTacs { get; set; }

    public virtual DbSet<VThietBiPtnThtren500Tr> VThietBiPtnThtren500Trs { get; set; }

    public virtual DbSet<VThoaThuanHopTacQuocTe> VThoaThuanHopTacQuocTes { get; set; }

    public virtual DbSet<VThongTinHocBong> VThongTinHocBongs { get; set; }

    public virtual DbSet<VThongTinHocTapNghienCuuSinh> VThongTinHocTapNghienCuuSinhs { get; set; }

    public virtual DbSet<VThongTinHocTapSinhVien> VThongTinHocTapSinhViens { get; set; }

    public virtual DbSet<VThongTinHopTac> VThongTinHopTacs { get; set; }

    public virtual DbSet<VThongTinKiemDinhCuaChuongTrinh> VThongTinKiemDinhCuaChuongTrinhs { get; set; }

    public virtual DbSet<VThongTinLinhVucDaoTao> VThongTinLinhVucDaoTaos { get; set; }

    public virtual DbSet<VThongTinNguoiHocGdtc> VThongTinNguoiHocGdtcs { get; set; }

    public virtual DbSet<VThongTinViPham> VThongTinViPhams { get; set; }

    public virtual DbSet<VThongTinViecLamSauTotNghiep> VThongTinViecLamSauTotNghieps { get; set; }

    public virtual DbSet<VThuVienTrungTamHocLieu> VThuVienTrungTamHocLieus { get; set; }

    public virtual DbSet<VToChucHopTacDoanhNghiep> VToChucHopTacDoanhNghieps { get; set; }

    public virtual DbSet<VToChucHopTacQuocTe> VToChucHopTacQuocTes { get; set; }

    public virtual DbSet<VToChucKiemDinh> VToChucKiemDinhs { get; set; }

    public virtual DbSet<VVanBanTuChu> VVanBanTuChus { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
                    // => optionsBuilder.UseSqlServer("Server=172.20.10.2\\SQLEXPRESS;Encrypt=false;Database=dbHemisC500;User ID=sa;Password=@Abc123");
                    //=> optionsBuilder.UseSqlServer("Server=tcp:c500sv.database.windows.net,1433;Encrypt=false;Database=dbHemisC500;User ID=c500;Password=@Abc1234");
                    => optionsBuilder.UseSqlServer("Server=10.0.28.54;Database=dbHemisC500;Encrypt=false;User Id=c500;Password=@Abc1234");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DmBacLuong>(entity =>
        {
            entity.HasKey(e => e.IdBacLuong);

            entity.ToTable("dmBacLuong");

            entity.Property(e => e.IdBacLuong).ValueGeneratedNever();
            entity.Property(e => e.BacLuong).HasMaxLength(200);
        });

        modelBuilder.Entity<DmBacLuong1>(entity =>
        {
            entity.HasKey(e => e.IdBacLuong);

            entity.ToTable("dmBacLuong", "DM");

            entity.Property(e => e.IdBacLuong).ValueGeneratedNever();
            entity.Property(e => e.BacLuong).HasMaxLength(200);
        });

        modelBuilder.Entity<DmCapHoiNghi>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("dmCapHoiNghi", "DM");

            entity.Property(e => e.CapHoiNghi).HasMaxLength(50);
        });

        modelBuilder.Entity<DmCapKhenThuong>(entity =>
        {
            entity.HasKey(e => e.IdCapKhenThuong);

            entity.ToTable("dmCapKhenThuong", "DM");

            entity.Property(e => e.IdCapKhenThuong).ValueGeneratedNever();
            entity.Property(e => e.CapKhenThuong).HasMaxLength(200);
        });

        modelBuilder.Entity<DmChuSoHuu>(entity =>
        {
            entity.HasKey(e => e.IdChuSoHuu);

            entity.ToTable("dmChuSoHuu", "DM");

            entity.Property(e => e.IdChuSoHuu).ValueGeneratedNever();
            entity.Property(e => e.ChuSoHuu).HasMaxLength(50);
        });

        modelBuilder.Entity<DmChucDanhGiangVien>(entity =>
        {
            entity.HasKey(e => e.IdChucDanhGiangVien).HasName("PK_tbChucDanhGiangDay");

            entity.ToTable("dmChucDanhGiangVien", "DM");

            entity.Property(e => e.IdChucDanhGiangVien).ValueGeneratedNever();
            entity.Property(e => e.ChucDanhGiangVien).HasMaxLength(200);
        });

        modelBuilder.Entity<DmChucDanhHoiDong>(entity =>
        {
            entity.HasKey(e => e.IdChucDanhHoiDong);

            entity.ToTable("dmChucDanhHoiDong", "DM");

            entity.Property(e => e.IdChucDanhHoiDong).ValueGeneratedNever();
            entity.Property(e => e.ChucDanhHoiDong).HasMaxLength(200);
        });

        modelBuilder.Entity<DmChucDanhKhoaHoc>(entity =>
        {
            entity.HasKey(e => e.IdChucDanhKhoaHoc);

            entity.ToTable("dmChucDanhKhoaHoc", "DM");

            entity.Property(e => e.IdChucDanhKhoaHoc).ValueGeneratedNever();
            entity.Property(e => e.ChucDanhKhoaHoc).HasMaxLength(200);
        });

        modelBuilder.Entity<DmChucDanhNckh>(entity =>
        {
            entity.HasKey(e => e.IdChucDanhNghienCuuKhoaHoc).HasName("PK_tbChucDanhNCKH");

            entity.ToTable("dmChucDanhNCKH", "DM");

            entity.Property(e => e.IdChucDanhNghienCuuKhoaHoc).ValueGeneratedNever();
            entity.Property(e => e.ChucDanhNghienCuuKhoaHoc).HasMaxLength(200);
        });

        modelBuilder.Entity<DmChucDanhNgheNghiep>(entity =>
        {
            entity.HasKey(e => e.IdChucDanhNgheNghiep);

            entity.ToTable("dmChucDanhNgheNghiep", "DM");

            entity.Property(e => e.IdChucDanhNgheNghiep).ValueGeneratedNever();
            entity.Property(e => e.ChucDanhNgheNghiep).HasMaxLength(200);
        });

        modelBuilder.Entity<DmChucDanhPhongBan>(entity =>
        {
            entity.HasKey(e => e.IdChucDanhPhongBan);

            entity.ToTable("dmChucDanhPhongBan", "DM");

            entity.Property(e => e.IdChucDanhPhongBan).ValueGeneratedNever();
            entity.Property(e => e.ChucDanhPhongBan).HasMaxLength(200);
        });

        modelBuilder.Entity<DmChucVu>(entity =>
        {
            entity.HasKey(e => e.IdChucVu);

            entity.ToTable("dmChucVu", "DM");

            entity.Property(e => e.IdChucVu).ValueGeneratedNever();
            entity.Property(e => e.ChucVu).HasMaxLength(200);
        });

        modelBuilder.Entity<DmChuongTrinhDaoTao>(entity =>
        {
            entity.HasKey(e => e.IdChuongTrinhDaoTao);

            entity.ToTable("dmChuongTrinhDaoTao", "DM");

            entity.Property(e => e.IdChuongTrinhDaoTao).ValueGeneratedNever();
            entity.Property(e => e.ChuongTrinhDaoTao).HasMaxLength(200);
        });

        modelBuilder.Entity<DmCoQuanBanHanh>(entity =>
        {
            entity.HasKey(e => e.IdCoQuanBanHanh);

            entity.ToTable("dmCoQuanBanHanh", "DM");

            entity.Property(e => e.IdCoQuanBanHanh).ValueGeneratedNever();
            entity.Property(e => e.CoQuanBanHanh).HasMaxLength(200);
        });

        modelBuilder.Entity<DmCoQuanChuQuan>(entity =>
        {
            entity.HasKey(e => e.IdCoQuanChuQuan);

            entity.ToTable("dmCoQuanChuQuan", "DM");

            entity.Property(e => e.IdCoQuanChuQuan).ValueGeneratedNever();
            entity.Property(e => e.CoQuanChuQuan).HasMaxLength(200);
        });

        modelBuilder.Entity<DmDanToc>(entity =>
        {
            entity.HasKey(e => e.IdDanToc);

            entity.ToTable("dmDanToc", "DM");

            entity.Property(e => e.IdDanToc).ValueGeneratedNever();
            entity.Property(e => e.DanToc).HasMaxLength(50);
        });

        modelBuilder.Entity<DmDangTaiLieu>(entity =>
        {
            entity.HasKey(e => e.IdDangTaiLieu);

            entity.ToTable("dmDangTaiLieu", "DM");

            entity.Property(e => e.IdDangTaiLieu).ValueGeneratedNever();
            entity.Property(e => e.DangTaiLieu).HasMaxLength(50);
        });

        modelBuilder.Entity<DmDanhGiaCongChucVienChuc>(entity =>
        {
            entity.HasKey(e => e.IdDanhGiaCongChucVienChuc);

            entity.ToTable("dmDanhGiaCongChucVienChuc", "DM");

            entity.Property(e => e.IdDanhGiaCongChucVienChuc).ValueGeneratedNever();
            entity.Property(e => e.DanhGiaCongChucVienChuc).HasMaxLength(200);
        });

        modelBuilder.Entity<DmDanhHieuVinhDuGiaiThuong>(entity =>
        {
            entity.HasKey(e => e.IdDanhHieuVinhDuGiaiThuong);

            entity.ToTable("dmDanhHieuVinhDuGiaiThuong", "DM");

            entity.Property(e => e.IdDanhHieuVinhDuGiaiThuong).ValueGeneratedNever();
            entity.Property(e => e.DanhHieuVinhDuGiaiThuong).HasMaxLength(200);
        });

        modelBuilder.Entity<DmDaoTaoGdqpan>(entity =>
        {
            entity.HasKey(e => e.IdDaoTaoGdqpan);

            entity.ToTable("dmDaoTaoGDQPAN", "DM");

            entity.Property(e => e.IdDaoTaoGdqpan)
                .ValueGeneratedNever()
                .HasColumnName("IdDaoTaoGDQPAN");
            entity.Property(e => e.DaoTaoGdqpan)
                .HasMaxLength(200)
                .HasColumnName("DaoTaoGDQPAN");
        });

        modelBuilder.Entity<DmDauMoiLienHe>(entity =>
        {
            entity.HasKey(e => e.IdDauMoiLienHe);

            entity.ToTable("dmDauMoiLienHe", "DM");

            entity.Property(e => e.IdDauMoiLienHe).ValueGeneratedNever();
            entity.Property(e => e.DauMoiLienHe).HasMaxLength(200);
        });

        modelBuilder.Entity<DmDoiTuongChinhSach>(entity =>
        {
            entity.HasKey(e => e.IdDoiTuongChinhSach);

            entity.ToTable("dmDoiTuongChinhSach", "DM");

            entity.Property(e => e.IdDoiTuongChinhSach).ValueGeneratedNever();
            entity.Property(e => e.DoiTuongChinhSach).HasMaxLength(200);
        });

        modelBuilder.Entity<DmDoiTuongDauVao>(entity =>
        {
            entity.HasKey(e => e.IdDoiTuongDauVao);

            entity.ToTable("dmDoiTuongDauVao", "DM");

            entity.Property(e => e.IdDoiTuongDauVao).ValueGeneratedNever();
            entity.Property(e => e.DoiTuongDauVao).HasMaxLength(200);
        });

        modelBuilder.Entity<DmDoiTuongUuTien>(entity =>
        {
            entity.HasKey(e => e.IdDoiTuongUuTien);

            entity.ToTable("dmDoiTuongUuTien", "DM");

            entity.Property(e => e.IdDoiTuongUuTien).ValueGeneratedNever();
            entity.Property(e => e.DoiTuongUuTien).HasMaxLength(50);
        });

        modelBuilder.Entity<DmDonViCapBang>(entity =>
        {
            entity.HasKey(e => e.IdDonViCapBang).HasName("PK_tbDonViCapBang");

            entity.ToTable("dmDonViCapBang", "DM");

            entity.Property(e => e.IdDonViCapBang).ValueGeneratedNever();
            entity.Property(e => e.DonViCapBang).HasMaxLength(200);
        });

        modelBuilder.Entity<DmGioiTinh>(entity =>
        {
            entity.HasKey(e => e.IdGioiTinh);

            entity.ToTable("dmGioiTinh", "DM");

            entity.Property(e => e.IdGioiTinh).ValueGeneratedNever();
            entity.Property(e => e.GioiTinh).HasMaxLength(200);
        });

        modelBuilder.Entity<DmHangThuongBinh>(entity =>
        {
            entity.HasKey(e => e.IdHangThuongBinh);

            entity.ToTable("dmHangThuongBinh", "DM");

            entity.Property(e => e.IdHangThuongBinh).ValueGeneratedNever();
            entity.Property(e => e.HangThuongBinh).HasMaxLength(50);
        });

        modelBuilder.Entity<DmHeSoLuong>(entity =>
        {
            entity.HasKey(e => e.IdHeSoLuong);

            entity.ToTable("dmHeSoLuong", "DM");

            entity.Property(e => e.IdHeSoLuong).ValueGeneratedNever();
            entity.Property(e => e.HeSoLuong).HasMaxLength(200);
        });

        modelBuilder.Entity<DmHinhThucBoNhiem>(entity =>
        {
            entity.HasKey(e => e.IdHinhThucBoNhiem);

            entity.ToTable("dmHinhThucBoNhiem", "DM");

            entity.Property(e => e.IdHinhThucBoNhiem).ValueGeneratedNever();
            entity.Property(e => e.HinhThucBoNhiem).HasMaxLength(200);
        });

        modelBuilder.Entity<DmHinhThucChuyenGiaoCongNghe>(entity =>
        {
            entity.HasKey(e => e.IdHinhThucChuyenGiaoCongNghe);

            entity.ToTable("dmHinhThucChuyenGiaoCongNghe", "DM");

            entity.Property(e => e.IdHinhThucChuyenGiaoCongNghe).ValueGeneratedNever();
            entity.Property(e => e.HinhThucChuyenGiaoCongNghe).HasMaxLength(50);
        });

        modelBuilder.Entity<DmHinhThucDaoTao>(entity =>
        {
            entity.HasKey(e => e.IdHinhThucDaoTao);

            entity.ToTable("dmHinhThucDaoTao", "DM");

            entity.Property(e => e.IdHinhThucDaoTao).ValueGeneratedNever();
            entity.Property(e => e.HinhThucDaoTao).HasMaxLength(200);
        });

        modelBuilder.Entity<DmHinhThucDaoTaoTheoChuyenNgu>(entity =>
        {
            entity.HasKey(e => e.IdHinhThucDaoTaoTheoChuyenNgu);

            entity.ToTable("dmHinhThucDaoTaoTheoChuyenNgu", "DM");

            entity.Property(e => e.IdHinhThucDaoTaoTheoChuyenNgu).ValueGeneratedNever();
            entity.Property(e => e.HinhThucDaoTaoTheoChuyenNgu).HasMaxLength(50);
        });

        modelBuilder.Entity<DmHinhThucDoanhNghiepKhcn>(entity =>
        {
            entity.HasKey(e => e.IdHinhThucDoanhNghiepKhcn);

            entity.ToTable("dmHinhThucDoanhNghiepKHCN", "DM");

            entity.Property(e => e.IdHinhThucDoanhNghiepKhcn)
                .ValueGeneratedNever()
                .HasColumnName("IdHinhThucDoanhNghiepKHCN");
            entity.Property(e => e.HinhThucDoanhNghiepKhcn)
                .HasMaxLength(50)
                .HasColumnName("HinhThucDoanhNghiepKHCN");
        });

        modelBuilder.Entity<DmHinhThucHopTac>(entity =>
        {
            entity.HasKey(e => e.IdHinhThucHopTac);

            entity.ToTable("dmHinhThucHopTac", "DM");

            entity.Property(e => e.IdHinhThucHopTac).ValueGeneratedNever();
            entity.Property(e => e.HinhThucHopTac).HasMaxLength(200);
        });

        modelBuilder.Entity<DmHinhThucSoHuu>(entity =>
        {
            entity.HasKey(e => e.IdHinhThucSoHuu);

            entity.ToTable("dmHinhThucSoHuu", "DM");

            entity.Property(e => e.IdHinhThucSoHuu).ValueGeneratedNever();
            entity.Property(e => e.HinhThucSoHuu).HasMaxLength(50);
        });

        modelBuilder.Entity<DmHinhThucThamGiaGvduocCuDiDaoTao>(entity =>
        {
            entity.HasKey(e => e.IdHinhThucThamGiaGvduocCuDiDaoTao);

            entity.ToTable("dmHinhThucThamGiaGVDuocCuDiDaoTao", "DM");

            entity.Property(e => e.IdHinhThucThamGiaGvduocCuDiDaoTao)
                .ValueGeneratedNever()
                .HasColumnName("IdHinhThucThamGiaGVDuocCuDiDaoTao");
            entity.Property(e => e.HinhThucThamGiaGvduocCuDiDaoTao)
                .HasMaxLength(200)
                .HasColumnName("HinhThucThamGiaGVDuocCuDiDaoTao");
        });

        modelBuilder.Entity<DmHinhThucThanhLap>(entity =>
        {
            entity.HasKey(e => e.IdHinhThucThanhLap);

            entity.ToTable("dmHinhThucThanhLap", "DM");

            entity.Property(e => e.IdHinhThucThanhLap).ValueGeneratedNever();
            entity.Property(e => e.HinhThucThanhLap).HasMaxLength(200);
        });

        modelBuilder.Entity<DmHinhThucTuyenDung>(entity =>
        {
            entity.HasKey(e => e.IdHinhThucTuyenDung);

            entity.ToTable("dmHinhThucTuyenDung", "DM");

            entity.Property(e => e.IdHinhThucTuyenDung).ValueGeneratedNever();
            entity.Property(e => e.HinhThucTuyenDung).HasMaxLength(50);
        });

        modelBuilder.Entity<DmHinhThucTuyenSinh>(entity =>
        {
            entity.HasKey(e => e.IdHinhThucTuyenSinh);

            entity.ToTable("dmHinhThucTuyenSinh", "DM");

            entity.Property(e => e.IdHinhThucTuyenSinh).ValueGeneratedNever();
            entity.Property(e => e.HinhThucTuyenSinh).HasMaxLength(50);
        });

        modelBuilder.Entity<DmHoGiaDinhChinhSach>(entity =>
        {
            entity.HasKey(e => e.IdHoGiaDinhChinhSach);

            entity.ToTable("dmHoGiaDinhChinhSach", "DM");

            entity.Property(e => e.IdHoGiaDinhChinhSach).ValueGeneratedNever();
            entity.Property(e => e.HoGiaDinhChinhSach).HasMaxLength(200);
        });

        modelBuilder.Entity<DmHoatDongTaiChinh>(entity =>
        {
            entity.HasKey(e => e.IdHoatDongTaiChinh);

            entity.ToTable("dmHoatDongTaiChinh", "DM");

            entity.Property(e => e.IdHoatDongTaiChinh).ValueGeneratedNever();
            entity.Property(e => e.HoatDongTaiChinh).HasMaxLength(200);
        });

        modelBuilder.Entity<DmHocCheDaoTao>(entity =>
        {
            entity.HasKey(e => e.IdHocCheDaoTao).HasName("PK_tbHocCheDaoTao");

            entity.ToTable("dmHocCheDaoTao", "DM");

            entity.Property(e => e.IdHocCheDaoTao).ValueGeneratedNever();
            entity.Property(e => e.HocCheDaoTao).HasMaxLength(200);
        });

        modelBuilder.Entity<DmHuyen>(entity =>
        {
            entity.HasKey(e => e.IdHuyen).HasName("PK_tbHuyen");

            entity.ToTable("dmHuyen", "DM");

            entity.Property(e => e.IdHuyen).ValueGeneratedNever();
            entity.Property(e => e.TenHuyen).HasMaxLength(200);

            entity.HasOne(d => d.IdTinhNavigation).WithMany(p => p.DmHuyens)
                .HasForeignKey(d => d.IdTinh)
                .HasConstraintName("FK_tbHuyen_tbTinh");
        });

        modelBuilder.Entity<DmKetQuaKiemDinh>(entity =>
        {
            entity.HasKey(e => e.IdKetQuaKiemDinh).HasName("PK_tbKetQuaKiemDinh");

            entity.ToTable("dmKetQuaKiemDinh", "DM");

            entity.Property(e => e.IdKetQuaKiemDinh).ValueGeneratedNever();
            entity.Property(e => e.KetQuaKiemDinh).HasMaxLength(200);
        });

        modelBuilder.Entity<DmKhoiNganhLinhVucDaoTao>(entity =>
        {
            entity.HasKey(e => e.IdKhoiNganhLinhVucNghienCuu).HasName("PK_dmKhoiNganhLinhVucNghienCuu");

            entity.ToTable("dmKhoiNganhLinhVucDaoTao", "DM");

            entity.Property(e => e.IdKhoiNganhLinhVucNghienCuu).ValueGeneratedNever();

            entity.HasOne(d => d.IdKhoiNganhNavigation).WithMany(p => p.DmKhoiNganhLinhVucDaoTaos)
                .HasForeignKey(d => d.IdKhoiNganh)
                .HasConstraintName("FK_dmKhoiNganhLinhVucDaoTao_dmKhoiNganh");

            entity.HasOne(d => d.IdLinhVucDaoTaoNavigation).WithMany(p => p.DmKhoiNganhLinhVucDaoTaos)
                .HasForeignKey(d => d.IdLinhVucDaoTao)
                .HasConstraintName("FK_dmKhoiNganhLinhVucDaoTao_dmLinhVucDaoTao");
        });

        modelBuilder.Entity<DmKhuVuc>(entity =>
        {
            entity.HasKey(e => e.IdKhuVuc);

            entity.ToTable("dmKhuVuc", "DM");

            entity.Property(e => e.IdKhuVuc).ValueGeneratedNever();
            entity.Property(e => e.KhuVuc).HasMaxLength(200);
        });

        modelBuilder.Entity<DmKhungNangLucNgoaiNgu>(entity =>
        {
            entity.HasKey(e => e.IdKhungNangLucNgoaiNgu);

            entity.ToTable("dmKhungNangLucNgoaiNgu", "DM");

            entity.Property(e => e.IdKhungNangLucNgoaiNgu).ValueGeneratedNever();
            entity.Property(e => e.TenKhungNangLucNgoaiNgu).HasMaxLength(50);
        });

        modelBuilder.Entity<DmLinhVucDaoTao>(entity =>
        {
            entity.HasKey(e => e.IdLinhVucDaoTao);

            entity.ToTable("dmLinhVucDaoTao", "DM");

            entity.Property(e => e.IdLinhVucDaoTao).ValueGeneratedNever();
            entity.Property(e => e.LinhVucDaoTao).HasMaxLength(200);
        });

        modelBuilder.Entity<DmLinhVucNghienCuu>(entity =>
        {
            entity.HasKey(e => e.IdLinhVucNghienCuu);

            entity.ToTable("dmLinhVucNghienCuu", "DM");

            entity.Property(e => e.IdLinhVucNghienCuu).ValueGeneratedNever();
            entity.Property(e => e.LinhVucNghienCuu).HasMaxLength(200);
        });

        modelBuilder.Entity<DmLinhVucNhomNganh>(entity =>
        {
            entity.HasKey(e => e.IdLinhVucNhomNganh);

            entity.ToTable("dmLinhVucNhomNganh", "DM");

            entity.Property(e => e.IdLinhVucNhomNganh).ValueGeneratedNever();

            entity.HasOne(d => d.IdLinhVucDaoTaoNavigation).WithMany(p => p.DmLinhVucNhomNganhs)
                .HasForeignKey(d => d.IdLinhVucDaoTao)
                .HasConstraintName("FK_dmLinhVucNhomNganh_dmLinhVucDaoTao");

            entity.HasOne(d => d.IdNhomNganhNavigation).WithMany(p => p.DmLinhVucNhomNganhs)
                .HasForeignKey(d => d.IdNhomNganh)
                .HasConstraintName("FK_dmLinhVucNhomNganh_dmNhomNganh");
        });

        modelBuilder.Entity<DmLoaiBoiDuong>(entity =>
        {
            entity.HasKey(e => e.IdLoaiBoiDuong);

            entity.ToTable("dmLoaiBoiDuong", "DM");

            entity.Property(e => e.IdLoaiBoiDuong).ValueGeneratedNever();
            entity.Property(e => e.LoaiBoiDuong).HasMaxLength(200);
        });

        modelBuilder.Entity<DmLoaiChuongTrinhDaoTao>(entity =>
        {
            entity.HasKey(e => e.IdLoaiChuongTrinhDaoTao).HasName("PK_tbLoaiChuongTrinhDaoTao");

            entity.ToTable("dmLoaiChuongTrinhDaoTao", "DM");

            entity.Property(e => e.IdLoaiChuongTrinhDaoTao).ValueGeneratedNever();
            entity.Property(e => e.LoaiChuongTrinhDaoTao).HasMaxLength(200);
        });

        modelBuilder.Entity<DmLoaiChuongTrinhLienKetDaoTao>(entity =>
        {
            entity.HasKey(e => e.IdLoaiChuongTrinhLienKetDaoTao).HasName("PK_tbLoaiChuongTrinhLienKetDaoTao");

            entity.ToTable("dmLoaiChuongTrinhLienKetDaoTao", "DM");

            entity.Property(e => e.IdLoaiChuongTrinhLienKetDaoTao).ValueGeneratedNever();
            entity.Property(e => e.LoaiChuongTrinhLienKetDaoTao).HasMaxLength(200);
        });

        modelBuilder.Entity<DmLoaiCongTrinhCoSoVatChat>(entity =>
        {
            entity.HasKey(e => e.IdLoaiCongTrinhCoSoVatChat);

            entity.ToTable("dmLoaiCongTrinhCoSoVatChat", "DM");

            entity.Property(e => e.IdLoaiCongTrinhCoSoVatChat).ValueGeneratedNever();
            entity.Property(e => e.LoaiCongTrinhCoSoVatChat).HasMaxLength(200);
        });

        modelBuilder.Entity<DmLoaiDanhHieuThiDuaGiaiThuongKhenThuong>(entity =>
        {
            entity.HasKey(e => e.IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong);

            entity.ToTable("dmLoaiDanhHieuThiDuaGiaiThuongKhenThuong", "DM");

            entity.Property(e => e.IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong).ValueGeneratedNever();
            entity.Property(e => e.LoaiDanhHieuThiDuaGiaiThuongKhenThuong).HasMaxLength(200);
        });

        modelBuilder.Entity<DmLoaiDeAnChuongTrinh>(entity =>
        {
            entity.HasKey(e => e.IdLoaiDeAnChuongTrinh);

            entity.ToTable("dmLoaiDeAnChuongTrinh", "DM");

            entity.Property(e => e.IdLoaiDeAnChuongTrinh).ValueGeneratedNever();
            entity.Property(e => e.LoaiDeAnChuongTrinh).HasMaxLength(200);
        });

        modelBuilder.Entity<DmLoaiDeTai>(entity =>
        {
            entity.HasKey(e => e.IdLoaiDeTai);

            entity.ToTable("dmLoaiDeTai", "DM");

            entity.Property(e => e.IdLoaiDeTai).ValueGeneratedNever();
            entity.Property(e => e.LoaiDeTai).HasMaxLength(200);
        });

        modelBuilder.Entity<DmLoaiGiaiThuongKhcn>(entity =>
        {
            entity.HasKey(e => e.IdLoaiGiaiThuongKhcn);

            entity.ToTable("dmLoaiGiaiThuongKHCN", "DM");

            entity.Property(e => e.IdLoaiGiaiThuongKhcn)
                .ValueGeneratedNever()
                .HasColumnName("IdLoaiGiaiThuongKHCN");
            entity.Property(e => e.LoaiGiaiThuongKhcn)
                .HasMaxLength(200)
                .HasColumnName("LoaiGiaiThuongKHCN");
        });

        modelBuilder.Entity<DmLoaiGiangVienQuocPhong>(entity =>
        {
            entity.HasKey(e => e.IdLoaiGiangVienQuocPhong);

            entity.ToTable("dmLoaiGiangVienQuocPhong", "DM");

            entity.Property(e => e.IdLoaiGiangVienQuocPhong).ValueGeneratedNever();
            entity.Property(e => e.LoaiGiangVienQuocPhong).HasMaxLength(50);
        });

        modelBuilder.Entity<DmLoaiHinhCoSoDaoTao>(entity =>
        {
            entity.HasKey(e => e.IdLoaiHinhCoSoDaoTao);

            entity.ToTable("dmLoaiHinhCoSoDaoTao", "DM");

            entity.Property(e => e.IdLoaiHinhCoSoDaoTao).ValueGeneratedNever();
            entity.Property(e => e.LoaiHinhCoSoDaoTao).HasMaxLength(200);
        });

        modelBuilder.Entity<DmLoaiHinhDaoTao>(entity =>
        {
            entity.HasKey(e => e.IdLoaiHinhDaoTao);

            entity.ToTable("dmLoaiHinhDaoTao", "DM");

            entity.Property(e => e.IdLoaiHinhDaoTao).ValueGeneratedNever();
            entity.Property(e => e.LoaiHinhDaoTao).HasMaxLength(200);
        });

        modelBuilder.Entity<DmLoaiHinhTruong>(entity =>
        {
            entity.HasKey(e => e.IdLoaiHinhTruong);

            entity.ToTable("dmLoaiHinhTruong", "DM");

            entity.Property(e => e.IdLoaiHinhTruong).ValueGeneratedNever();
            entity.Property(e => e.LoaiHinhTruong).HasMaxLength(200);
        });

        modelBuilder.Entity<DmLoaiHocBong>(entity =>
        {
            entity.HasKey(e => e.IdLoaiHocBong);

            entity.ToTable("dmLoaiHocBong", "DM");

            entity.Property(e => e.IdLoaiHocBong).ValueGeneratedNever();
            entity.Property(e => e.LoaiHocBong).HasMaxLength(200);
        });

        modelBuilder.Entity<DmLoaiHocVien>(entity =>
        {
            entity.HasKey(e => e.IdLoaiHocVien);

            entity.ToTable("dmLoaiHocVien", "DM");

            entity.Property(e => e.IdLoaiHocVien).ValueGeneratedNever();
            entity.Property(e => e.LoaiHocVien).HasMaxLength(50);
        });

        modelBuilder.Entity<DmLoaiHopDong>(entity =>
        {
            entity.HasKey(e => e.IdLoaiHopDong);

            entity.ToTable("dmLoaiHopDong", "DM");

            entity.Property(e => e.IdLoaiHopDong).ValueGeneratedNever();
            entity.Property(e => e.LoaiHopDong).HasMaxLength(200);
        });

        modelBuilder.Entity<DmLoaiKhuyetTat>(entity =>
        {
            entity.HasKey(e => e.IdLoaiKhuyetTat);

            entity.ToTable("dmLoaiKhuyetTat", "DM");

            entity.Property(e => e.IdLoaiKhuyetTat).ValueGeneratedNever();
            entity.Property(e => e.LoaiKhuyetTat).HasMaxLength(50);
        });

        modelBuilder.Entity<DmLoaiKyLuat>(entity =>
        {
            entity.HasKey(e => e.IdLoaiKyLuat);

            entity.ToTable("dmLoaiKyLuat", "DM");

            entity.Property(e => e.IdLoaiKyLuat).ValueGeneratedNever();
            entity.Property(e => e.LoaiKyLuat).HasMaxLength(200);
        });

        modelBuilder.Entity<DmLoaiLienKet>(entity =>
        {
            entity.HasKey(e => e.IdLoaiLienKet);

            entity.ToTable("dmLoaiLienKet", "DM");

            entity.Property(e => e.IdLoaiLienKet).ValueGeneratedNever();
            entity.Property(e => e.LoaiLienKet).HasMaxLength(200);
        });

        modelBuilder.Entity<DmLoaiLuuHocSinh>(entity =>
        {
            entity.HasKey(e => e.IdLoaiLuuHocSinh);

            entity.ToTable("dmLoaiLuuHocSinh", "DM");

            entity.Property(e => e.IdLoaiLuuHocSinh).ValueGeneratedNever();
            entity.Property(e => e.LoaiLuuHocSinh).HasMaxLength(200);
        });

        modelBuilder.Entity<DmLoaiNhiemVu>(entity =>
        {
            entity.HasKey(e => e.IdLoaiNhiemVu);

            entity.ToTable("dmLoaiNhiemVu", "DM");

            entity.Property(e => e.IdLoaiNhiemVu).ValueGeneratedNever();
            entity.Property(e => e.LoaiNhiemVu).HasMaxLength(50);
        });

        modelBuilder.Entity<DmLoaiNhiemVuBaoVeMoiTruong>(entity =>
        {
            entity.HasKey(e => e.IdLoaiNhiemVuBaoVeMoiTruong);

            entity.ToTable("dmLoaiNhiemVuBaoVeMoiTruong", "DM");

            entity.Property(e => e.IdLoaiNhiemVuBaoVeMoiTruong).ValueGeneratedNever();
            entity.Property(e => e.LoaiNhiemVuBaoVeMoiTruong).HasMaxLength(50);
        });

        modelBuilder.Entity<DmLoaiPhongBan>(entity =>
        {
            entity.HasKey(e => e.IdLoaiPhongBan);

            entity.ToTable("dmLoaiPhongBan", "DM");

            entity.Property(e => e.IdLoaiPhongBan).ValueGeneratedNever();
            entity.Property(e => e.LoaiPhongBan).HasMaxLength(200);
        });

        modelBuilder.Entity<DmLoaiPhongHoc>(entity =>
        {
            entity.HasKey(e => e.IdLoaiPhongHoc);

            entity.ToTable("dmLoaiPhongHoc", "DM");

            entity.Property(e => e.IdLoaiPhongHoc).ValueGeneratedNever();
            entity.Property(e => e.LoaiPhongHoc).HasMaxLength(200);
        });

        modelBuilder.Entity<DmLoaiPhongThiNghiem>(entity =>
        {
            entity.HasKey(e => e.IdLoaiPhongThiNghiem);

            entity.ToTable("dmLoaiPhongThiNghiem", "DM");

            entity.Property(e => e.IdLoaiPhongThiNghiem).ValueGeneratedNever();
            entity.Property(e => e.LoaiPhongThiNghiem).HasMaxLength(200);
        });

        modelBuilder.Entity<DmLoaiQuyetDinh>(entity =>
        {
            entity.HasKey(e => e.IdLoaiQuyetDinh);

            entity.ToTable("dmLoaiQuyetDinh", "DM");

            entity.Property(e => e.IdLoaiQuyetDinh).ValueGeneratedNever();
            entity.Property(e => e.LoaiQuyetDinh).HasMaxLength(200);
        });

        modelBuilder.Entity<DmLoaiSachTapChi>(entity =>
        {
            entity.HasKey(e => e.IdLoaiSachTapChi);

            entity.ToTable("dmLoaiSachTapChi", "DM");

            entity.Property(e => e.IdLoaiSachTapChi).ValueGeneratedNever();
            entity.Property(e => e.LoaiSachTapChi).HasMaxLength(200);
        });

        modelBuilder.Entity<DmLoaiTaiSanTriTue>(entity =>
        {
            entity.HasKey(e => e.IdLoaiTaiSanTriTue);

            entity.ToTable("dmLoaiTaiSanTriTue", "DM");

            entity.Property(e => e.IdLoaiTaiSanTriTue).ValueGeneratedNever();
            entity.Property(e => e.LoaiTaiSanTriTue).HasMaxLength(50);
        });

        modelBuilder.Entity<DmLoaiThamGium>(entity =>
        {
            entity.HasKey(e => e.IdLoaiThamGia);

            entity.ToTable("dmLoaiThamGia", "DM");

            entity.Property(e => e.IdLoaiThamGia).ValueGeneratedNever();
            entity.Property(e => e.LoaiThamGia).HasMaxLength(50);
        });

        modelBuilder.Entity<DmLoaiToChuc>(entity =>
        {
            entity.HasKey(e => e.IdLoaiToChuc);

            entity.ToTable("dmLoaiToChuc", "DM");

            entity.Property(e => e.IdLoaiToChuc).ValueGeneratedNever();
            entity.Property(e => e.LoaiToChuc).HasMaxLength(200);
        });

        modelBuilder.Entity<DmLoaiTotNghiep>(entity =>
        {
            entity.HasKey(e => e.IdLoaiTotNghiep);

            entity.ToTable("dmLoaiTotNghiep", "DM");

            entity.Property(e => e.IdLoaiTotNghiep).ValueGeneratedNever();
            entity.Property(e => e.LoaiTotNghiep).HasMaxLength(50);
        });

        modelBuilder.Entity<DmLoaiViPham>(entity =>
        {
            entity.HasKey(e => e.IdLoaiViPham);

            entity.ToTable("dmLoaiViPham", "DM");

            entity.Property(e => e.IdLoaiViPham).ValueGeneratedNever();
            entity.Property(e => e.LoaiViPham).HasMaxLength(50);
        });

        modelBuilder.Entity<DmMucDichSuDungCsvc>(entity =>
        {
            entity.HasKey(e => e.IdMucDichSuDungCsvc);

            entity.ToTable("dmMucDichSuDungCSVC", "DM");

            entity.Property(e => e.IdMucDichSuDungCsvc)
                .ValueGeneratedNever()
                .HasColumnName("IdMucDichSuDungCSVC");
            entity.Property(e => e.MucDichSuDungCsvc)
                .HasMaxLength(200)
                .HasColumnName("MucDichSuDungCSVC");
        });

        modelBuilder.Entity<DmMucGiaiThuong>(entity =>
        {
            entity.HasKey(e => e.IdMucGiaiThuong);

            entity.ToTable("dmMucGiaiThuong", "DM");

            entity.Property(e => e.IdMucGiaiThuong).ValueGeneratedNever();
            entity.Property(e => e.MucGiaiThuong).HasMaxLength(50);
        });

        modelBuilder.Entity<DmMucTieuNhiemVu>(entity =>
        {
            entity.HasKey(e => e.IdMucTieuNhiemVu);

            entity.ToTable("dmMucTieuNhiemVu", "DM");

            entity.Property(e => e.IdMucTieuNhiemVu).ValueGeneratedNever();
            entity.Property(e => e.MucTieuNhiemVu).HasMaxLength(200);
        });

        modelBuilder.Entity<DmNgach>(entity =>
        {
            entity.HasKey(e => e.IdNgach);

            entity.ToTable("dmNgach", "DM");

            entity.Property(e => e.IdNgach).ValueGeneratedNever();
            entity.Property(e => e.Ngach).HasMaxLength(200);
        });

        modelBuilder.Entity<DmNganhDaoTao>(entity =>
        {
            entity.HasKey(e => e.IdNganhDaoTao).HasName("PK_tbNganhDaoTao");

            entity.ToTable("dmNganhDaoTao", "DM");

            entity.Property(e => e.IdNganhDaoTao).ValueGeneratedNever();
            entity.Property(e => e.NganhDaoTao).HasMaxLength(200);
        });

        modelBuilder.Entity<DmNganhKinhTe>(entity =>
        {
            entity.HasKey(e => e.IdNganhKinhTe);

            entity.ToTable("dmNganhKinhTe", "DM");

            entity.Property(e => e.IdNganhKinhTe).ValueGeneratedNever();
            entity.Property(e => e.Cap1).HasMaxLength(5);
        });

        modelBuilder.Entity<DmNgoaiNgu>(entity =>
        {
            entity.HasKey(e => e.IdNgoaiNgu).HasName("PK_tbNgoaiNgu");

            entity.ToTable("dmNgoaiNgu", "DM");

            entity.Property(e => e.IdNgoaiNgu).ValueGeneratedNever();
            entity.Property(e => e.NgoaiNgu).HasMaxLength(50);
        });

        modelBuilder.Entity<DmNguonKinhPhi>(entity =>
        {
            entity.HasKey(e => e.IdNguonKinhPhi);

            entity.ToTable("dmNguonKinhPhi", "DM");

            entity.Property(e => e.IdNguonKinhPhi).ValueGeneratedNever();
            entity.Property(e => e.NguonKinhPhi).HasMaxLength(200);
        });

        modelBuilder.Entity<DmNguonKinhPhiChoDeAn>(entity =>
        {
            entity.HasKey(e => e.IdNguonKinhPhiChoDeAn);

            entity.ToTable("dmNguonKinhPhiChoDeAn", "DM");

            entity.Property(e => e.IdNguonKinhPhiChoDeAn).ValueGeneratedNever();
            entity.Property(e => e.NguonKinhPhiChoDeAn).HasMaxLength(50);
        });

        modelBuilder.Entity<DmNguonKinhPhiChoLuuHocSinh>(entity =>
        {
            entity.HasKey(e => e.IdNguonKinhPhiChoLuuHocSinh);

            entity.ToTable("dmNguonKinhPhiChoLuuHocSinh", "DM");

            entity.Property(e => e.IdNguonKinhPhiChoLuuHocSinh).ValueGeneratedNever();
            entity.Property(e => e.NguonKinhPhiChoLuuHocSinh).HasMaxLength(50);
        });

        modelBuilder.Entity<DmNguonKinhPhiCuaGvduocCuDiDaoTao>(entity =>
        {
            entity.HasKey(e => e.IdNguonKinhPhiCuaGvduocCuDiDaoTao);

            entity.ToTable("dmNguonKinhPhiCuaGVDuocCuDiDaoTao", "DM");

            entity.Property(e => e.IdNguonKinhPhiCuaGvduocCuDiDaoTao)
                .ValueGeneratedNever()
                .HasColumnName("IdNguonKinhPhiCuaGVDuocCuDiDaoTao");
            entity.Property(e => e.NguonKinhPhiCuaGvduocCuDiDaoTao)
                .HasMaxLength(50)
                .HasColumnName("NguonKinhPhiCuaGVDuocCuDiDaoTao");
        });

        modelBuilder.Entity<DmNhomNganh>(entity =>
        {
            entity.HasKey(e => e.IdNhomNganh);

            entity.ToTable("dmNhomNganh", "DM");

            entity.Property(e => e.IdNhomNganh).ValueGeneratedNever();
            entity.Property(e => e.NhomNganh).HasMaxLength(200);
        });

        modelBuilder.Entity<DmNoiDungHoatDong>(entity =>
        {
            entity.HasKey(e => e.IdNoiDungHoatDong);

            entity.ToTable("dmNoiDungHoatDong", "DM");

            entity.Property(e => e.IdNoiDungHoatDong).ValueGeneratedNever();
            entity.Property(e => e.NoiDungHoatDong).HasMaxLength(200);
        });

        modelBuilder.Entity<DmNoiDungHoatDongTaiVietNam>(entity =>
        {
            entity.HasKey(e => e.IdNoiDungHoatDongTaiVietNam);

            entity.ToTable("dmNoiDungHoatDongTaiVietNam", "DM");

            entity.Property(e => e.IdNoiDungHoatDongTaiVietNam).ValueGeneratedNever();
            entity.Property(e => e.NoiDungHoatDongTaiVietNam).HasMaxLength(200);
        });

        modelBuilder.Entity<DmPhanCapNhiemVu>(entity =>
        {
            entity.HasKey(e => e.IdPhanCapNhiemVu);

            entity.ToTable("dmPhanCapNhiemVu", "DM");

            entity.Property(e => e.IdPhanCapNhiemVu).ValueGeneratedNever();
            entity.Property(e => e.PhanCapNhiemVu).HasMaxLength(50);
        });

        modelBuilder.Entity<DmPhanLoaiCoSo>(entity =>
        {
            entity.HasKey(e => e.IdPhanLoaiCoSo);

            entity.ToTable("dmPhanLoaiCoSo", "DM");

            entity.Property(e => e.IdPhanLoaiCoSo).ValueGeneratedNever();
            entity.Property(e => e.PhanLoaiCoSo).HasMaxLength(200);
        });

        modelBuilder.Entity<DmPhanLoaiCsvc>(entity =>
        {
            entity.HasKey(e => e.IdPhanLoaiCsvc);

            entity.ToTable("dmPhanLoaiCSVC", "DM");

            entity.Property(e => e.IdPhanLoaiCsvc)
                .ValueGeneratedNever()
                .HasColumnName("IdPhanLoaiCSVC");
            entity.Property(e => e.PhanLoaiCsvc)
                .HasMaxLength(200)
                .HasColumnName("PhanLoaiCSVC");
        });

        modelBuilder.Entity<DmPhanLoaiDoanRaDoanVao>(entity =>
        {
            entity.HasKey(e => e.IdPhanLoaiDoanRaDoanVao);

            entity.ToTable("dmPhanLoaiDoanRaDoanVao", "DM");

            entity.Property(e => e.IdPhanLoaiDoanRaDoanVao).ValueGeneratedNever();
            entity.Property(e => e.PhanLoaiDoanRaDoanVao).HasMaxLength(50);
        });

        modelBuilder.Entity<DmPhanLoaiDoiNguNguoiHoc>(entity =>
        {
            entity.HasKey(e => e.IdPhanLoaiDoiNguNguoiHoc);

            entity.ToTable("dmPhanLoaiDoiNguNguoiHoc", "DM");

            entity.Property(e => e.IdPhanLoaiDoiNguNguoiHoc).ValueGeneratedNever();
            entity.Property(e => e.PhanLoaiDoiNguNguoiHoc)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<DmPhanLoaiDoiTuong>(entity =>
        {
            entity.HasKey(e => e.IdPhanLoaiDoiTuong);

            entity.ToTable("dmPhanLoaiDoiTuong", "DM");

            entity.Property(e => e.IdPhanLoaiDoiTuong).ValueGeneratedNever();
            entity.Property(e => e.PhanLoaiDoiTuong).HasMaxLength(200);
        });

        modelBuilder.Entity<DmPhanLoaiHoiNghiHoiThao>(entity =>
        {
            entity.HasKey(e => e.IdPhanLoaiHoiNghiHoiThao);

            entity.ToTable("dmPhanLoaiHoiNghiHoiThao", "DM");

            entity.Property(e => e.IdPhanLoaiHoiNghiHoiThao).ValueGeneratedNever();
            entity.Property(e => e.PhanLoaiHoiNghiHoiThao).HasMaxLength(50);
        });

        modelBuilder.Entity<DmPhanLoaiThuChi>(entity =>
        {
            entity.HasKey(e => e.IdPhanLoaiThuChi);

            entity.ToTable("dmPhanLoaiThuChi", "DM");

            entity.Property(e => e.IdPhanLoaiThuChi).ValueGeneratedNever();
            entity.Property(e => e.PhanLoaiThuChi).HasMaxLength(50);
        });

        modelBuilder.Entity<DmPhuongThucKhenThuong>(entity =>
        {
            entity.HasKey(e => e.IdPhuongThucKhenThuong).HasName("PK_dmHinhThucKhenThuong");

            entity.ToTable("dmPhuongThucKhenThuong", "DM");

            entity.Property(e => e.IdPhuongThucKhenThuong).ValueGeneratedNever();
            entity.Property(e => e.PhuongThucKhenThuong).HasMaxLength(200);
        });

        modelBuilder.Entity<DmQuanHam>(entity =>
        {
            entity.HasKey(e => e.IdQuanHam);

            entity.ToTable("dmQuanHam", "DM");

            entity.Property(e => e.IdQuanHam).ValueGeneratedNever();
            entity.Property(e => e.QuanHam).HasMaxLength(200);
        });

        modelBuilder.Entity<DmQuocTich>(entity =>
        {
            entity.HasKey(e => e.IdQuocTich).HasName("PK_tbQuocTich");

            entity.ToTable("dmQuocTich", "DM");

            entity.Property(e => e.IdQuocTich).ValueGeneratedNever();
            entity.Property(e => e.TenNuoc).HasMaxLength(200);
        });

        modelBuilder.Entity<DmQuyetDinhTuChu>(entity =>
        {
            entity.HasKey(e => e.IdQuyetDinhTuChu);

            entity.ToTable("dmQuyetDinhTuChu", "DM");

            entity.Property(e => e.IdQuyetDinhTuChu).ValueGeneratedNever();
            entity.Property(e => e.QuyetDinhTuChu).HasMaxLength(50);
        });

        modelBuilder.Entity<DmSangCheGiaiPhap>(entity =>
        {
            entity.HasKey(e => e.IdSangCheGiaiPhap);

            entity.ToTable("dmSangCheGiaiPhap", "DM");

            entity.Property(e => e.IdSangCheGiaiPhap).ValueGeneratedNever();
            entity.Property(e => e.TenLoaiGiaiPhap).HasMaxLength(50);
        });

        modelBuilder.Entity<DmSinhVienNam>(entity =>
        {
            entity.HasKey(e => e.IdSinhVienNam);

            entity.ToTable("dmSinhVienNam", "DM");

            entity.Property(e => e.IdSinhVienNam).ValueGeneratedNever();
            entity.Property(e => e.SinhVienNam).HasMaxLength(50);
        });

        modelBuilder.Entity<DmTapChiKhoaHocQuocTe>(entity =>
        {
            entity.HasKey(e => e.IdTapChiKhoaHocQuocTe);

            entity.ToTable("dmTapChiKhoaHocQuocTe", "DM");

            entity.Property(e => e.IdTapChiKhoaHocQuocTe).ValueGeneratedNever();
            entity.Property(e => e.TapChiKhoaHocQuocTe).HasMaxLength(50);
        });

        modelBuilder.Entity<DmTapChiTrongNuoc>(entity =>
        {
            entity.HasKey(e => e.IdTapChiTrongNuoc);

            entity.ToTable("dmTapChiTrongNuoc", "DM");

            entity.Property(e => e.IdTapChiTrongNuoc).ValueGeneratedNever();
            entity.Property(e => e.TapChiTrongNuoc).HasMaxLength(200);
        });

        modelBuilder.Entity<DmThiDuaGiaiThuongKhenThuong>(entity =>
        {
            entity.HasKey(e => e.IdThiDuaGiaiThuongKhenThuong);

            entity.ToTable("dmThiDuaGiaiThuongKhenThuong", "DM");

            entity.Property(e => e.IdThiDuaGiaiThuongKhenThuong).ValueGeneratedNever();
            entity.Property(e => e.ThiDuaGiaiThuongKhenThuong).HasMaxLength(200);
        });

        modelBuilder.Entity<DmTiengDanToc>(entity =>
        {
            entity.HasKey(e => e.IdTiengDanToc);

            entity.ToTable("dmTiengDanToc", "DM");

            entity.Property(e => e.IdTiengDanToc).ValueGeneratedNever();
            entity.Property(e => e.TiengDanToc).HasMaxLength(200);
        });

        modelBuilder.Entity<DmTinh>(entity =>
        {
            entity.HasKey(e => e.IdTinh).HasName("PK_tbTinh");

            entity.ToTable("dmTinh", "DM");

            entity.Property(e => e.IdTinh).ValueGeneratedNever();
            entity.Property(e => e.TenTinh).HasMaxLength(100);
        });

        modelBuilder.Entity<DmTinhTrangCoSoVatChat>(entity =>
        {
            entity.HasKey(e => e.IdTinhTrangCoSoVatChat);

            entity.ToTable("dmTinhTrangCoSoVatChat", "DM");

            entity.Property(e => e.IdTinhTrangCoSoVatChat).ValueGeneratedNever();
            entity.Property(e => e.TinhTrangCoSoVatChat).HasMaxLength(200);
        });

        modelBuilder.Entity<DmTinhTrangGiangVienDuocCuDiDaoTao>(entity =>
        {
            entity.HasKey(e => e.IdTinhTrangGiangVienDuocCuDiDaoTao);

            entity.ToTable("dmTinhTrangGiangVienDuocCuDiDaoTao", "DM");

            entity.Property(e => e.IdTinhTrangGiangVienDuocCuDiDaoTao).ValueGeneratedNever();
            entity.Property(e => e.TinhTrangGiangVienDuocCuDiDaoTao).HasMaxLength(200);
        });

        modelBuilder.Entity<DmTinhTrangHopDong>(entity =>
        {
            entity.HasKey(e => e.IdTinhTrangHopDong);

            entity.ToTable("dmTinhTrangHopDong", "DM");

            entity.Property(e => e.IdTinhTrangHopDong).ValueGeneratedNever();
            entity.Property(e => e.TinhTrangHopDong).HasMaxLength(200);
        });

        modelBuilder.Entity<DmTinhTrangNhiemVu>(entity =>
        {
            entity.HasKey(e => e.IdTinhTrangNhiemVu);

            entity.ToTable("dmTinhTrangNhiemVu", "DM");

            entity.Property(e => e.IdTinhTrangNhiemVu).ValueGeneratedNever();
            entity.Property(e => e.TinhTrangNhiemVu).HasMaxLength(50);
        });

        modelBuilder.Entity<DmTinhTrangThietBi>(entity =>
        {
            entity.HasKey(e => e.IdTinhTrangThietBi);

            entity.ToTable("dmTinhTrangThietBi", "DM");

            entity.Property(e => e.IdTinhTrangThietBi).ValueGeneratedNever();
            entity.Property(e => e.TinhTrangThietBi).HasMaxLength(50);
        });

        modelBuilder.Entity<DmToChucKiemDinh>(entity =>
        {
            entity.HasKey(e => e.IdToChucKiemDinh).HasName("PK_tbToChucKiemDinh");

            entity.ToTable("dmToChucKiemDinh", "DM");

            entity.Property(e => e.IdToChucKiemDinh).ValueGeneratedNever();
            entity.Property(e => e.ToChucKiemDinh).HasMaxLength(200);
        });

        modelBuilder.Entity<DmTonGiao>(entity =>
        {
            entity.HasKey(e => e.IdTonGiao);

            entity.ToTable("dmTonGiao", "DM");

            entity.Property(e => e.IdTonGiao).ValueGeneratedNever();
            entity.Property(e => e.TonGiao).HasMaxLength(50);
        });

        modelBuilder.Entity<DmTrangThaiCanBo>(entity =>
        {
            entity.HasKey(e => e.IdTrangThaiCanBo);

            entity.ToTable("dmTrangThaiCanBo", "DM");

            entity.Property(e => e.IdTrangThaiCanBo).ValueGeneratedNever();
            entity.Property(e => e.TrangThaiCanBo).HasMaxLength(200);
        });

        modelBuilder.Entity<DmTrangThaiChuongTrinhDaoTao>(entity =>
        {
            entity.HasKey(e => e.IdTrangThaiChuongTrinhDaoTao);

            entity.ToTable("dmTrangThaiChuongTrinhDaoTao", "DM");

            entity.Property(e => e.IdTrangThaiChuongTrinhDaoTao).ValueGeneratedNever();
            entity.Property(e => e.TrangThaiChuongTrinhDaoTao).HasMaxLength(200);
        });

        modelBuilder.Entity<DmTrangThaiCoSoGd>(entity =>
        {
            entity.HasKey(e => e.IdTrangThaiCoSoGd);

            entity.ToTable("dmTrangThaiCoSoGD", "DM");

            entity.Property(e => e.IdTrangThaiCoSoGd)
                .ValueGeneratedNever()
                .HasColumnName("IdTrangThaiCoSoGD");
            entity.Property(e => e.TrangThaiCoSoGd)
                .HasMaxLength(50)
                .HasColumnName("TrangThaiCoSoGD");
        });

        modelBuilder.Entity<DmTrangThaiDaoTao>(entity =>
        {
            entity.HasKey(e => e.IdTrangThaiDaoTao);

            entity.ToTable("dmTrangThaiDaoTao", "DM");

            entity.Property(e => e.IdTrangThaiDaoTao).ValueGeneratedNever();
            entity.Property(e => e.TrangThaiDaoTao).HasMaxLength(50);
        });

        modelBuilder.Entity<DmTrangThaiHoc>(entity =>
        {
            entity.HasKey(e => e.IdTrangThaiHoc);

            entity.ToTable("dmTrangThaiHoc", "DM");

            entity.Property(e => e.IdTrangThaiHoc).ValueGeneratedNever();
            entity.Property(e => e.TrangThaiHoc).HasMaxLength(50);
        });

        modelBuilder.Entity<DmTrangThaiHopDong>(entity =>
        {
            entity.HasKey(e => e.IdTrangThaiHopDong);

            entity.ToTable("dmTrangThaiHopDong", "DM");

            entity.Property(e => e.IdTrangThaiHopDong).ValueGeneratedNever();
            entity.Property(e => e.TrangThaiHopDong).HasMaxLength(200);
        });

        modelBuilder.Entity<DmTrangThaiThucHien>(entity =>
        {
            entity.HasKey(e => e.IdTrangThaiThucHien);

            entity.ToTable("dmTrangThaiThucHien", "DM");

            entity.Property(e => e.IdTrangThaiThucHien).ValueGeneratedNever();
            entity.Property(e => e.TrangThaiThucHien).HasMaxLength(50);
        });

        modelBuilder.Entity<DmTrinhDo>(entity =>
        {
            entity.HasKey(e => e.IdTrinhDo);

            entity.ToTable("dmTrinhDo", "DM");

            entity.Property(e => e.IdTrinhDo).ValueGeneratedNever();
            entity.Property(e => e.TrinhDo).HasMaxLength(200);
        });

        modelBuilder.Entity<DmTrinhDoDaoTao>(entity =>
        {
            entity.HasKey(e => e.IdTrinhDoDaoTao);

            entity.ToTable("dmTrinhDoDaoTao", "DM");

            entity.Property(e => e.IdTrinhDoDaoTao).ValueGeneratedNever();
            entity.Property(e => e.TrinhDoDaoTao).HasMaxLength(200);
        });

        modelBuilder.Entity<DmTrinhDoLyLuanChinhTri>(entity =>
        {
            entity.HasKey(e => e.IdTrinhDoLyLuanChinhTri);

            entity.ToTable("dmTrinhDoLyLuanChinhTri", "DM");

            entity.Property(e => e.IdTrinhDoLyLuanChinhTri).ValueGeneratedNever();
            entity.Property(e => e.TenTrinhDoLyLuanChinhTri).HasMaxLength(50);
        });

        modelBuilder.Entity<DmTrinhDoQuanLyNhaNuoc>(entity =>
        {
            entity.HasKey(e => e.IdTrinhDoQuanLyNhaNuoc).HasName("PK_TrinhDoQuanLyNhaNuoc");

            entity.ToTable("dmTrinhDoQuanLyNhaNuoc", "DM");

            entity.Property(e => e.IdTrinhDoQuanLyNhaNuoc).ValueGeneratedNever();
            entity.Property(e => e.TrinhDoQuanLyNhaNuoc).HasMaxLength(200);
        });

        modelBuilder.Entity<DmTrinhDoTinHoc>(entity =>
        {
            entity.HasKey(e => e.IdTrinhDoTinHoc);

            entity.ToTable("dmTrinhDoTinHoc", "DM");

            entity.Property(e => e.IdTrinhDoTinHoc).ValueGeneratedNever();
            entity.Property(e => e.TrinhDoTinHoc).HasMaxLength(200);
        });

        modelBuilder.Entity<DmTuChuMoNganh>(entity =>
        {
            entity.HasKey(e => e.IdTuChuMoNganh);

            entity.ToTable("dmTuChuMoNganh", "DM");

            entity.Property(e => e.IdTuChuMoNganh).ValueGeneratedNever();
            entity.Property(e => e.TuChuMoNganh).HasMaxLength(50);
        });

        modelBuilder.Entity<DmTuyChon>(entity =>
        {
            entity.HasKey(e => e.IdTuyChon);

            entity.ToTable("dmTuyChon", "DM");

            entity.Property(e => e.IdTuyChon).ValueGeneratedNever();
            entity.Property(e => e.TuyChon).HasMaxLength(50);
        });

        modelBuilder.Entity<DmVaiTroThamGium>(entity =>
        {
            entity.HasKey(e => e.IdVaiTroThamGia);

            entity.ToTable("dmVaiTroThamGia", "DM");

            entity.Property(e => e.IdVaiTroThamGia).ValueGeneratedNever();
            entity.Property(e => e.VaiTroThamGia).HasMaxLength(50);
        });

        modelBuilder.Entity<DmViTriViecLam>(entity =>
        {
            entity.HasKey(e => e.IdViTriViecLam);

            entity.ToTable("dmViTriViecLam", "DM");

            entity.Property(e => e.IdViTriViecLam).ValueGeneratedNever();
            entity.Property(e => e.ViTriViecLam).HasMaxLength(200);
        });

        modelBuilder.Entity<DmXa>(entity =>
        {
            entity.HasKey(e => e.IdXa).HasName("PK_tbXa");

            entity.ToTable("dmXa", "DM");

            entity.Property(e => e.IdXa).ValueGeneratedNever();
            entity.Property(e => e.TenXa).HasMaxLength(200);

            entity.HasOne(d => d.IdHuyenNavigation).WithMany(p => p.DmXas)
                .HasForeignKey(d => d.IdHuyen)
                .HasConstraintName("FK_tbXa_tbHuyen");
        });

        modelBuilder.Entity<DmXepHangQ>(entity =>
        {
            entity.HasKey(e => e.IdXepHangQ);

            entity.ToTable("dmXepHangQ", "DM");

            entity.Property(e => e.IdXepHangQ).ValueGeneratedNever();
            entity.Property(e => e.XepHangQ).HasMaxLength(50);
        });

        modelBuilder.Entity<TbBaiBaoKhdaCongBo>(entity =>
        {
            entity.HasKey(e => e.IdBaiBaoKhdaCongBo);

            entity.ToTable("tbBaiBaoKHDaCongBo", "KHCN");

            entity.Property(e => e.IdBaiBaoKhdaCongBo)
                .ValueGeneratedNever()
                .HasColumnName("IdBaiBaoKHDaCongBo");
            entity.Property(e => e.GhiChuDuongDanBaiBao).HasMaxLength(200);
            entity.Property(e => e.IdNhiemVuKhcn).HasColumnName("IdNhiemVuKHCN");
            entity.Property(e => e.MaBaiBaoKh)
                .HasMaxLength(50)
                .HasColumnName("MaBaiBaoKH");
            entity.Property(e => e.NamCongBo).HasColumnType("text");
            entity.Property(e => e.TenBaiBaoKh)
                .HasMaxLength(300)
                .HasColumnName("TenBaiBaoKH");
            entity.Property(e => e.TenTapChi).HasMaxLength(200);

            entity.HasOne(d => d.IdNhiemVuKhcnNavigation).WithMany(p => p.TbBaiBaoKhdaCongBos)
                .HasForeignKey(d => d.IdNhiemVuKhcn)
                .HasConstraintName("FK_tbBaiBaoKHDaCongBo_tbNhiemVuKHCN");

            entity.HasOne(d => d.IdTapChiQuocTeNavigation).WithMany(p => p.TbBaiBaoKhdaCongBos)
                .HasForeignKey(d => d.IdTapChiQuocTe)
                .HasConstraintName("FK_tbBaiBaoKHDaCongBo_dmTapChiKhoaHocQuocTe");

            entity.HasOne(d => d.IdTapChiTrongNuocNavigation).WithMany(p => p.TbBaiBaoKhdaCongBos)
                .HasForeignKey(d => d.IdTapChiTrongNuoc)
                .HasConstraintName("FK_tbBaiBaoKHDaCongBo_dmTapChiTrongNuoc");

            entity.HasOne(d => d.IdXepHangQNavigation).WithMany(p => p.TbBaiBaoKhdaCongBos)
                .HasForeignKey(d => d.IdXepHangQ)
                .HasConstraintName("FK_tbBaiBaoKHDaCongBo_dmXepHangQ");
        });

        modelBuilder.Entity<TbCanBo>(entity =>
        {
            entity.HasKey(e => e.IdCanBo);

            entity.ToTable("tbCanBo", "CB");

            entity.Property(e => e.IdCanBo).ValueGeneratedNever();
            entity.Property(e => e.CoQuanCongTac).HasMaxLength(200);
            entity.Property(e => e.DienThoai).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.GiangVienDapUngTt03).HasColumnName("GiangVienDapUngTT03");
            entity.Property(e => e.HinhThucChuyenDen).HasMaxLength(200);
            entity.Property(e => e.MaCanBo).HasMaxLength(50);
            entity.Property(e => e.SoBaoHiemXaHoi).HasMaxLength(50);
            entity.Property(e => e.SoGiayPhepLaoDong).HasMaxLength(50);
            entity.Property(e => e.SoQuyetDinhHuuNghiViec).HasMaxLength(20);
            entity.Property(e => e.TenDoanhNghiep).HasMaxLength(200);

            entity.HasOne(d => d.IdChucDanhGiangVienNavigation).WithMany(p => p.TbCanBos)
                .HasForeignKey(d => d.IdChucDanhGiangVien)
                .HasConstraintName("FK_tbCanBo_dmChucDanhGiangDay");

            entity.HasOne(d => d.IdChucDanhNgheNghiepNavigation).WithMany(p => p.TbCanBos)
                .HasForeignKey(d => d.IdChucDanhNgheNghiep)
                .HasConstraintName("FK_tbCanBo_dmChucDanhNgheNghiep");

            entity.HasOne(d => d.IdChucDanhNghienCuuKhoaHocNavigation).WithMany(p => p.TbCanBos)
                .HasForeignKey(d => d.IdChucDanhNghienCuuKhoaHoc)
                .HasConstraintName("FK_tbCanBo_dmChucDanhNCKH");

            entity.HasOne(d => d.IdChucVuCongTacNavigation).WithMany(p => p.TbCanBos)
                .HasForeignKey(d => d.IdChucVuCongTac)
                .HasConstraintName("FK_tbCanBo_dmChucVu");

            entity.HasOne(d => d.IdHuyenNavigation).WithMany(p => p.TbCanBos)
                .HasForeignKey(d => d.IdHuyen)
                .HasConstraintName("FK_tbCanBo_dmHuyen");

            entity.HasOne(d => d.IdNgachNavigation).WithMany(p => p.TbCanBos)
                .HasForeignKey(d => d.IdNgach)
                .HasConstraintName("FK_tbCanBo_dmNgach");

            entity.HasOne(d => d.IdNguoiNavigation).WithMany(p => p.TbCanBos)
                .HasForeignKey(d => d.IdNguoi)
                .HasConstraintName("FK_tbCanBo_tbNguoi");

            entity.HasOne(d => d.IdTinhNavigation).WithMany(p => p.TbCanBos)
                .HasForeignKey(d => d.IdTinh)
                .HasConstraintName("FK_tbCanBo_dmTinh");

            entity.HasOne(d => d.IdTrangThaiLamViecNavigation).WithMany(p => p.TbCanBos)
                .HasForeignKey(d => d.IdTrangThaiLamViec)
                .HasConstraintName("FK_tbCanBo_dmTrangThaiCanBo");

            entity.HasOne(d => d.IdXaNavigation).WithMany(p => p.TbCanBos)
                .HasForeignKey(d => d.IdXa)
                .HasConstraintName("FK_tbCanBo_dmXa");
        });

        modelBuilder.Entity<TbCanBoHuongDanThanhCongSinhVien>(entity =>
        {
            entity.HasKey(e => e.IdCanBoHuongDanThanhCongSinhVien);

            entity.ToTable("tbCanBoHuongDanThanhCongSinhVien", "CB");

            entity.Property(e => e.IdCanBoHuongDanThanhCongSinhVien).ValueGeneratedNever();
            entity.Property(e => e.TrachNhiemHuongDan).HasMaxLength(200);

            entity.HasOne(d => d.IdCanBoNavigation).WithMany(p => p.TbCanBoHuongDanThanhCongSinhViens)
                .HasForeignKey(d => d.IdCanBo)
                .HasConstraintName("FK_tbCanBoHuongDanThanhCongSinhVien_tbCanBo");
        });

        modelBuilder.Entity<TbChiTietTaiSanDonVi>(entity =>
        {
            entity.HasKey(e => e.IdChiTietTaiSanDonVi);

            entity.ToTable("tbChiTietTaiSanDonVi", "TCTS");

            entity.Property(e => e.IdChiTietTaiSanDonVi).ValueGeneratedNever();
            entity.Property(e => e.MaTaiSan).HasMaxLength(50);
            entity.Property(e => e.TenTaiSan).HasMaxLength(200);

            entity.HasOne(d => d.IdChuSoHuuNavigation).WithMany(p => p.TbChiTietTaiSanDonVis)
                .HasForeignKey(d => d.IdChuSoHuu)
                .HasConstraintName("FK_tbChiTietTaiSanDonVi_dmChuSoHuu");

            entity.HasOne(d => d.IdTaiSanDonViNavigation).WithMany(p => p.TbChiTietTaiSanDonVis)
                .HasForeignKey(d => d.IdTaiSanDonVi)
                .HasConstraintName("FK_tbChiTietTaiSanDonVi_tbTaiSanDonVi");

            entity.HasOne(d => d.IdTinhTrangThietBiNavigation).WithMany(p => p.TbChiTietTaiSanDonVis)
                .HasForeignKey(d => d.IdTinhTrangThietBi)
                .HasConstraintName("FK_tbChiTietTaiSanDonVi_dmTinhTrangThietBi");
        });

        modelBuilder.Entity<TbChiTietThuChi>(entity =>
        {
            entity.HasKey(e => e.IdChiTietThuChi);

            entity.ToTable("tbChiTietThuChi", "TCTS");

            entity.Property(e => e.IdChiTietThuChi).ValueGeneratedNever();
            entity.Property(e => e.NamTaiChinh).HasColumnType("text");
            entity.Property(e => e.TenKhoanThuChi).HasMaxLength(200);

            entity.HasOne(d => d.IdLoaiThuChiNavigation).WithMany(p => p.TbChiTietThuChis)
                .HasForeignKey(d => d.IdLoaiThuChi)
                .HasConstraintName("FK_tbChiTietThuChi_tbLoaiThuChi");
        });

        modelBuilder.Entity<TbChiTieuTuyenSinhTheoNganh>(entity =>
        {
            entity.HasKey(e => e.IdChiTieuTuyenSinhTheoNganh);

            entity.ToTable("tbChiTieuTuyenSinhTheoNganh", "TS");

            entity.Property(e => e.IdChiTieuTuyenSinhTheoNganh).ValueGeneratedNever();
            entity.Property(e => e.Nam).HasColumnType("text");

            entity.HasOne(d => d.IdLoaiHinhDaoTaoNavigation).WithMany(p => p.TbChiTieuTuyenSinhTheoNganhs)
                .HasForeignKey(d => d.IdLoaiHinhDaoTao)
                .HasConstraintName("FK_tbChiTieuTuyenSinhTheoNganh_dmLoaiHinhDaoTao");

            entity.HasOne(d => d.IdNganhDaoTaoNavigation).WithMany(p => p.TbChiTieuTuyenSinhTheoNganhs)
                .HasForeignKey(d => d.IdNganhDaoTao)
                .HasConstraintName("FK_tbChiTieuTuyenSinhTheoNganh_dmNganhDaoTao");
        });

        modelBuilder.Entity<TbChucDanhKhoaHocCuaCanBo>(entity =>
        {
            entity.HasKey(e => e.IdChucDanhKhoaHocCuaCanBo);

            entity.ToTable("tbChucDanhKhoaHocCuaCanBo", "CB");

            entity.Property(e => e.IdChucDanhKhoaHocCuaCanBo).ValueGeneratedNever();
            entity.Property(e => e.SoQuyetDinh).HasMaxLength(200);

            entity.HasOne(d => d.IdCanBoNavigation).WithMany(p => p.TbChucDanhKhoaHocCuaCanBos)
                .HasForeignKey(d => d.IdCanBo)
                .HasConstraintName("FK_tbChucDanhKhoaHocCuaCanBo_tbCanBo");

            entity.HasOne(d => d.IdChucDanhKhoaHocNavigation).WithMany(p => p.TbChucDanhKhoaHocCuaCanBos)
                .HasForeignKey(d => d.IdChucDanhKhoaHoc)
                .HasConstraintName("FK_tbChucDanhKhoaHocCuaCanBo_dmChucDanhKhoaHoc");

            entity.HasOne(d => d.IdThamQuyenQuyetDinhNavigation).WithMany(p => p.TbChucDanhKhoaHocCuaCanBos)
                .HasForeignKey(d => d.IdThamQuyenQuyetDinh)
                .HasConstraintName("FK_tbChucDanhKhoaHocCuaCanBo_dmLoaiQuyetDinh");
        });

        modelBuilder.Entity<TbChuongTrinhDaoTao>(entity =>
        {
            entity.HasKey(e => e.IdChuongTrinhDaoTao);

            entity.ToTable("tbChuongTrinhDaoTao", "CTDT");

            entity.Property(e => e.IdChuongTrinhDaoTao).ValueGeneratedNever();
            entity.Property(e => e.ChuanDauRa).HasMaxLength(200);
            entity.Property(e => e.ChuanDauRaVeNgoaiNgu).HasMaxLength(200);
            entity.Property(e => e.ChuanDauRaVeTinHoc).HasMaxLength(200);
            entity.Property(e => e.DiaDiemDaoTao).HasMaxLength(200);
            entity.Property(e => e.DonViThucHienChuongTrinh).HasMaxLength(200);
            entity.Property(e => e.LoaiChungChiDuocChapThuan).HasMaxLength(200);
            entity.Property(e => e.MaChuongTrinhDaoTao).HasMaxLength(200);
            entity.Property(e => e.TenChuongTrinh).HasMaxLength(200);
            entity.Property(e => e.TenChuongTrinhBangTiengAnh).HasMaxLength(200);
            entity.Property(e => e.TenCoSoDaoTaoNuocNgoai).HasMaxLength(200);

            entity.HasOne(d => d.IdDonViCapBangNavigation).WithMany(p => p.TbChuongTrinhDaoTaos)
                .HasForeignKey(d => d.IdDonViCapBang)
                .HasConstraintName("FK_tbChuongTrinhDaoTao_dmDonViCapBang");

            entity.HasOne(d => d.IdHocCheDaoTaoNavigation).WithMany(p => p.TbChuongTrinhDaoTaos)
                .HasForeignKey(d => d.IdHocCheDaoTao)
                .HasConstraintName("FK_tbChuongTrinhDaoTao_dmHocCheDaoTao");

            entity.HasOne(d => d.IdLoaiChuongTrinhDaoTaoNavigation).WithMany(p => p.TbChuongTrinhDaoTaos)
                .HasForeignKey(d => d.IdLoaiChuongTrinhDaoTao)
                .HasConstraintName("FK_tbChuongTrinhDaoTao_dmLoaiChuongTrinhDaoTao");

            entity.HasOne(d => d.IdLoaiChuongTrinhLienKetDaoTaoNavigation).WithMany(p => p.TbChuongTrinhDaoTaos)
                .HasForeignKey(d => d.IdLoaiChuongTrinhLienKetDaoTao)
                .HasConstraintName("FK_tbChuongTrinhDaoTao_dmLoaiChuongTrinhLienKetDaoTao");

            entity.HasOne(d => d.IdNganhDaoTaoNavigation).WithMany(p => p.TbChuongTrinhDaoTaos)
                .HasForeignKey(d => d.IdNganhDaoTao)
                .HasConstraintName("FK_tbChuongTrinhDaoTao_dmNganhDaoTao");

            entity.HasOne(d => d.IdQuocGiaCuaTruSoChinhNavigation).WithMany(p => p.TbChuongTrinhDaoTaos)
                .HasForeignKey(d => d.IdQuocGiaCuaTruSoChinh)
                .HasConstraintName("FK_tbChuongTrinhDaoTao_dmQuocTich");

            entity.HasOne(d => d.IdTrangThaiCuaChuongTrinhNavigation).WithMany(p => p.TbChuongTrinhDaoTaos)
                .HasForeignKey(d => d.IdTrangThaiCuaChuongTrinh)
                .HasConstraintName("FK_tbChuongTrinhDaoTao_dmTrangThaiChuongTrinhDaoTao");

            entity.HasOne(d => d.IdTrinhDoDaoTaoNavigation).WithMany(p => p.TbChuongTrinhDaoTaos)
                .HasForeignKey(d => d.IdTrinhDoDaoTao)
                .HasConstraintName("FK_tbChuongTrinhDaoTao_dmTrinhDoDaoTao");
        });

        modelBuilder.Entity<TbChuyenGiaoCongNgheVaDaoTao>(entity =>
        {
            entity.HasKey(e => e.IdChuyenGiaoCongNgheVaDaoTao);

            entity.ToTable("tbChuyenGiaoCongNgheVaDaoTao", "KHCN");

            entity.Property(e => e.IdChuyenGiaoCongNgheVaDaoTao).ValueGeneratedNever();
            entity.Property(e => e.ChuSoHuu).HasMaxLength(50);
            entity.Property(e => e.DonViChuTri).HasMaxLength(50);
            entity.Property(e => e.DonViNhanChuyenGiao).HasMaxLength(50);
            entity.Property(e => e.DonViPhoiHop).HasMaxLength(50);
            entity.Property(e => e.IdNhiemVuKhcn).HasColumnName("IdNhiemVuKHCN");
            entity.Property(e => e.MaSoHopDong).HasMaxLength(50);
            entity.Property(e => e.PhuongThucChuyenGiaoCongNghe).HasMaxLength(50);
            entity.Property(e => e.SoNguoiDuocDaoTaoChuyenGiaoCn).HasColumnName("SoNguoiDuocDaoTaoChuyenGiaoCN");
            entity.Property(e => e.Ten).HasMaxLength(50);
            entity.Property(e => e.TenDuAn).HasMaxLength(50);
            entity.Property(e => e.TomTat).HasMaxLength(200);

            entity.HasOne(d => d.IdHinhThucChuyenGiaoCongNgheNavigation).WithMany(p => p.TbChuyenGiaoCongNgheVaDaoTaos)
                .HasForeignKey(d => d.IdHinhThucChuyenGiaoCongNghe)
                .HasConstraintName("FK_tbChuyenGiaoCongNgheVaDaoTao_dmHinhThucChuyenGiaoCongNghe");

            entity.HasOne(d => d.IdLinhVucNghienCuuNavigation).WithMany(p => p.TbChuyenGiaoCongNgheVaDaoTaos)
                .HasForeignKey(d => d.IdLinhVucNghienCuu)
                .HasConstraintName("FK_tbChuyenGiaoCongNgheVaDaoTao_dmLinhVucNghienCuu");

            entity.HasOne(d => d.IdNganhKinhTeNavigation).WithMany(p => p.TbChuyenGiaoCongNgheVaDaoTaos)
                .HasForeignKey(d => d.IdNganhKinhTe)
                .HasConstraintName("FK_tbChuyenGiaoCongNgheVaDaoTao_dmNganhKinhTe");

            entity.HasOne(d => d.IdNhiemVuKhcnNavigation).WithMany(p => p.TbChuyenGiaoCongNgheVaDaoTaos)
                .HasForeignKey(d => d.IdNhiemVuKhcn)
                .HasConstraintName("FK_tbChuyenGiaoCongNgheVaDaoTao_tbNhiemVuKHCN");

            entity.HasOne(d => d.IdTrangThaiHopDongNavigation).WithMany(p => p.TbChuyenGiaoCongNgheVaDaoTaos)
                .HasForeignKey(d => d.IdTrangThaiHopDong)
                .HasConstraintName("FK_tbChuyenGiaoCongNgheVaDaoTao_dmTinhTrangHopDong");
        });

        modelBuilder.Entity<TbCoCauToChuc>(entity =>
        {
            entity.HasKey(e => e.IdCoCauToChuc);

            entity.ToTable("tbCoCauToChuc", "CSGD");

            entity.Property(e => e.IdCoCauToChuc).ValueGeneratedNever();
            entity.Property(e => e.MaPhongBanDonVi).HasMaxLength(200);
            entity.Property(e => e.MaPhongBanDonViCha).HasMaxLength(200);
            entity.Property(e => e.NgayRaQuyetDinh).HasMaxLength(200);
            entity.Property(e => e.SoQuyetDinhThanhLap).HasMaxLength(200);
            entity.Property(e => e.TenPhongBanDonVi).HasMaxLength(200);

            entity.HasOne(d => d.IdLoaiPhongBanNavigation).WithMany(p => p.TbCoCauToChucs)
                .HasForeignKey(d => d.IdLoaiPhongBan)
                .HasConstraintName("FK_tbCoCauToChuc_dmLoaiPhongBan");

            entity.HasOne(d => d.IdTrangThaiNavigation).WithMany(p => p.TbCoCauToChucs)
                .HasForeignKey(d => d.IdTrangThai)
                .HasConstraintName("FK_tbCoCauToChuc_dmTrangThaiCoSoGD");
        });

        modelBuilder.Entity<TbCoSoGiaoDuc>(entity =>
        {
            entity.HasKey(e => e.IdCoSoGiaoDuc);

            entity.ToTable("tbCoSoGiaoDuc", "CSGD");

            entity.Property(e => e.IdCoSoGiaoDuc).ValueGeneratedNever();
            entity.Property(e => e.DaoTaoSvgdqpan1nam).HasColumnName("DaoTaoSVGDQPAN_1Nam");
            entity.Property(e => e.DiaChi).HasMaxLength(200);
            entity.Property(e => e.DiaChiWebsite).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Fax).HasMaxLength(50);
            entity.Property(e => e.MaDonVi).HasMaxLength(50);
            entity.Property(e => e.SoDienThoai).HasMaxLength(50);
            entity.Property(e => e.SoGiaoVienGdtc).HasColumnName("SoGiaoVienGDTC");
            entity.Property(e => e.SoQuyetDinhBanHanhQuyCheTaiChinh).HasMaxLength(200);
            entity.Property(e => e.SoQuyetDinhCapPhepHoatDong).HasMaxLength(200);
            entity.Property(e => e.SoQuyetDinhChuyenDoiLoaiHinh).HasMaxLength(200);
            entity.Property(e => e.SoQuyetDinhGiaoTuChu).HasMaxLength(200);
            entity.Property(e => e.SoQuyetDinhThanhLap).HasMaxLength(200);
            entity.Property(e => e.TenDaiHocTrucThuoc).HasMaxLength(200);
            entity.Property(e => e.TenDonVi).HasMaxLength(200);
            entity.Property(e => e.TenTiengAnh).HasMaxLength(200);
            entity.Property(e => e.TuChuGiaoDucQpan).HasColumnName("TuChuGiaoDucQPAN");

            entity.HasOne(d => d.HoatDongKhongLoiNhuanNavigation).WithMany(p => p.TbCoSoGiaoDucHoatDongKhongLoiNhuanNavigations)
                .HasForeignKey(d => d.HoatDongKhongLoiNhuan)
                .HasConstraintName("FK_tbCoSoGiaoDuc_dmTuyChon");

            entity.HasOne(d => d.IdCoQuanChuQuanNavigation).WithMany(p => p.TbCoSoGiaoDucs)
                .HasForeignKey(d => d.IdCoQuanChuQuan)
                .HasConstraintName("FK_tbCoSoGiaoDuc_dmCoQuanChuQuan");

            entity.HasOne(d => d.IdHinhThucThanhLapNavigation).WithMany(p => p.TbCoSoGiaoDucs)
                .HasForeignKey(d => d.IdHinhThucThanhLap)
                .HasConstraintName("FK_tbCoSoGiaoDuc_dmHinhThucThanhLap");

            entity.HasOne(d => d.IdHuyenNavigation).WithMany(p => p.TbCoSoGiaoDucs)
                .HasForeignKey(d => d.IdHuyen)
                .HasConstraintName("FK_tbCoSoGiaoDuc_dmHuyen");

            entity.HasOne(d => d.IdLoaiHinhCoSoDaoTaoNavigation).WithMany(p => p.TbCoSoGiaoDucs)
                .HasForeignKey(d => d.IdLoaiHinhCoSoDaoTao)
                .HasConstraintName("FK_tbCoSoGiaoDuc_dmLoaiHinhCoSoDaoTao");

            entity.HasOne(d => d.IdLoaiHinhTruongNavigation).WithMany(p => p.TbCoSoGiaoDucs)
                .HasForeignKey(d => d.IdLoaiHinhTruong)
                .HasConstraintName("FK_tbCoSoGiaoDuc_dmLoaiHinhTruong");

            entity.HasOne(d => d.IdPhanLoaiCoSoNavigation).WithMany(p => p.TbCoSoGiaoDucs)
                .HasForeignKey(d => d.IdPhanLoaiCoSo)
                .HasConstraintName("FK_tbCoSoGiaoDuc_dmPhanLoaiCoSo");

            entity.HasOne(d => d.IdTinhNavigation).WithMany(p => p.TbCoSoGiaoDucs)
                .HasForeignKey(d => d.IdTinh)
                .HasConstraintName("FK_tbCoSoGiaoDuc_dmTinh");

            entity.HasOne(d => d.IdXaNavigation).WithMany(p => p.TbCoSoGiaoDucs)
                .HasForeignKey(d => d.IdXa)
                .HasConstraintName("FK_tbCoSoGiaoDuc_dmXa");

            entity.HasOne(d => d.TuChuGiaoDucQpanNavigation).WithMany(p => p.TbCoSoGiaoDucTuChuGiaoDucQpanNavigations)
                .HasForeignKey(d => d.TuChuGiaoDucQpan)
                .HasConstraintName("FK_tbCoSoGiaoDuc_dmTuyChon1");
        });

        modelBuilder.Entity<TbCongTrinhCoSoVatChat>(entity =>
        {
            entity.HasKey(e => e.IdCongTrinhCoSoVatChat);

            entity.ToTable("tbCongTrinhCoSoVatChat", "CSVC");

            entity.Property(e => e.IdCongTrinhCoSoVatChat).ValueGeneratedNever();
            entity.Property(e => e.CongTrinhCsvctrongNha).HasColumnName("CongTrinhCSVCTrongNha");
            entity.Property(e => e.DoiTuongSuDung).HasMaxLength(200);
            entity.Property(e => e.IdTinhTrangCsvc).HasColumnName("IdTinhTrangCSVC");
            entity.Property(e => e.MaCongTrinh).HasMaxLength(50);
            entity.Property(e => e.NamDuaVaoSuDung).HasColumnType("text");
            entity.Property(e => e.SoChoOchoCanBoGiangDay).HasColumnName("SoChoOChoCanBoGiangDay");
            entity.Property(e => e.SoPhongOcongVu).HasColumnName("SoPhongOCongVu");
            entity.Property(e => e.TenCongTrinh).HasMaxLength(200);

            entity.HasOne(d => d.CongTrinhCsvctrongNhaNavigation).WithMany(p => p.TbCongTrinhCoSoVatChats)
                .HasForeignKey(d => d.CongTrinhCsvctrongNha)
                .HasConstraintName("FK_tbCongTrinhCoSoVatChat_dmTuyChon");

            entity.HasOne(d => d.IdHinhThucSoHuuNavigation).WithMany(p => p.TbCongTrinhCoSoVatChats)
                .HasForeignKey(d => d.IdHinhThucSoHuu)
                .HasConstraintName("FK_tbCongTrinhCoSoVatChat_dmHinhThucSoHuu");

            entity.HasOne(d => d.IdLoaiCongTrinhNavigation).WithMany(p => p.TbCongTrinhCoSoVatChats)
                .HasForeignKey(d => d.IdLoaiCongTrinh)
                .HasConstraintName("FK_tbCongTrinhCoSoVatChat_dmLoaiCongTrinhCoSoVatChat");

            entity.HasOne(d => d.IdMucDichSuDungNavigation).WithMany(p => p.TbCongTrinhCoSoVatChats)
                .HasForeignKey(d => d.IdMucDichSuDung)
                .HasConstraintName("FK_tbCongTrinhCoSoVatChat_dmMucDichSuDungCSVC");

            entity.HasOne(d => d.IdTinhTrangCsvcNavigation).WithMany(p => p.TbCongTrinhCoSoVatChats)
                .HasForeignKey(d => d.IdTinhTrangCsvc)
                .HasConstraintName("FK_tbCongTrinhCoSoVatChat_dmTinhTrangCoSoVatChat");
        });

        modelBuilder.Entity<TbDanhGiaXepLoaiCanBo>(entity =>
        {
            entity.HasKey(e => e.IdDanhGiaXepLoaiCanBo);

            entity.ToTable("tbDanhGiaXepLoaiCanBo", "CB");

            entity.Property(e => e.IdDanhGiaXepLoaiCanBo).ValueGeneratedNever();
            entity.Property(e => e.NganhDuocKhenThuong).HasMaxLength(200);

            entity.HasOne(d => d.IdCanBoNavigation).WithMany(p => p.TbDanhGiaXepLoaiCanBos)
                .HasForeignKey(d => d.IdCanBo)
                .HasConstraintName("FK_tbDanhGiaXepLoaiCanBo_tbCanBo");

            entity.HasOne(d => d.IdDanhGiaNavigation).WithMany(p => p.TbDanhGiaXepLoaiCanBos)
                .HasForeignKey(d => d.IdDanhGia)
                .HasConstraintName("FK_tbDanhGiaXepLoaiCanBo_dmDanhGiaCongChucVienChuc");
        });

        modelBuilder.Entity<TbDanhHieuThiDuaGiaiThuongKhenThuongCanBo>(entity =>
        {
            entity.HasKey(e => e.IdDanhHieuThiDuaGiaiThuongKhenThuongCanBo);

            entity.ToTable("tbDanhHieuThiDuaGiaiThuongKhenThuongCanBo", "CB");

            entity.Property(e => e.IdDanhHieuThiDuaGiaiThuongKhenThuongCanBo).ValueGeneratedNever();

            entity.HasOne(d => d.IdCanBoNavigation).WithMany(p => p.TbDanhHieuThiDuaGiaiThuongKhenThuongCanBos)
                .HasForeignKey(d => d.IdCanBo)
                .HasConstraintName("FK_tbDanhHieuThiDuaGiaiThuongKhenThuongCanBo_tbCanBo");

            entity.HasOne(d => d.IdCapKhenThuongNavigation).WithMany(p => p.TbDanhHieuThiDuaGiaiThuongKhenThuongCanBos)
                .HasForeignKey(d => d.IdCapKhenThuong)
                .HasConstraintName("FK_tbDanhHieuThiDuaGiaiThuongKhenThuongCanBo_dmCapKhenThuong");

            entity.HasOne(d => d.IdLoaiDanhHieuThiDuaGiaiThuongKhenThuongNavigation).WithMany(p => p.TbDanhHieuThiDuaGiaiThuongKhenThuongCanBos)
                .HasForeignKey(d => d.IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong)
                .HasConstraintName("FK_tbDanhHieuThiDuaGiaiThuongKhenThuongCanBo_dmLoaiDanhHieuThiDuaGiaiThuongKhenThuong");

            entity.HasOne(d => d.IdPhuongThucKhenThuongNavigation).WithMany(p => p.TbDanhHieuThiDuaGiaiThuongKhenThuongCanBos)
                .HasForeignKey(d => d.IdPhuongThucKhenThuong)
                .HasConstraintName("FK_tbDanhHieuThiDuaGiaiThuongKhenThuongCanBo_dmPhuongThucKhenThuong");

            entity.HasOne(d => d.IdThiDuaGiaiThuongKhenThuongNavigation).WithMany(p => p.TbDanhHieuThiDuaGiaiThuongKhenThuongCanBos)
                .HasForeignKey(d => d.IdThiDuaGiaiThuongKhenThuong)
                .HasConstraintName("FK_tbDanhHieuThiDuaGiaiThuongKhenThuongCanBo_dmThiDuaGiaiThuongKhenThuong");
        });

        modelBuilder.Entity<TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd>(entity =>
        {
            entity.HasKey(e => e.IdDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd);

            entity.ToTable("tbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGD", "CSGD");

            entity.Property(e => e.IdDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd)
                .ValueGeneratedNever()
                .HasColumnName("IdDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGD");
            entity.Property(e => e.NamKhenThuong).HasColumnType("text");
            entity.Property(e => e.SoQuyetDinhKhenThuong).HasMaxLength(200);

            entity.HasOne(d => d.IdCapKhenThuongNavigation).WithMany(p => p.TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGds)
                .HasForeignKey(d => d.IdCapKhenThuong)
                .HasConstraintName("FK_tbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGD_dmCapKhenThuong");

            entity.HasOne(d => d.IdDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGdNavigation).WithOne(p => p.TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd)
                .HasForeignKey<TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd>(d => d.IdDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGD_dmThiDuaGiaiThuongKhenThuong");

            entity.HasOne(d => d.IdLoaiDanhHieuThiDuaGiaiThuongKhenThuongNavigation).WithMany(p => p.TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGds)
                .HasForeignKey(d => d.IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong)
                .HasConstraintName("FK_tbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGD_dmLoaiDanhHieuThiDuaGiaiThuongKhenThuong");

            entity.HasOne(d => d.IdPhuongThucKhenThuongNavigation).WithMany(p => p.TbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGds)
                .HasForeignKey(d => d.IdPhuongThucKhenThuong)
                .HasConstraintName("FK_tbDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGD_dmPhuongThucKhenThuong");
        });

        modelBuilder.Entity<TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc>(entity =>
        {
            entity.HasKey(e => e.IdDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc);

            entity.ToTable("tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc", "NH");

            entity.Property(e => e.IdDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc).ValueGeneratedNever();
            entity.Property(e => e.NamKhenThuong).HasColumnType("text");
            entity.Property(e => e.SoQuyetDinhKhenThuong).HasMaxLength(50);

            entity.HasOne(d => d.IdCapKhenThuongNavigation).WithMany(p => p.TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocs)
                .HasForeignKey(d => d.IdCapKhenThuong)
                .HasConstraintName("FK_tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc_dmCapKhenThuong");

            entity.HasOne(d => d.IdDanhHieuThiDuaGiaiThuongKhenThuongNavigation).WithMany(p => p.TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocs)
                .HasForeignKey(d => d.IdDanhHieuThiDuaGiaiThuongKhenThuong)
                .HasConstraintName("FK_tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc_dmThiDuaGiaiThuongKhenThuong");

            entity.HasOne(d => d.IdHocVienNavigation).WithMany(p => p.TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocs)
                .HasForeignKey(d => d.IdHocVien)
                .HasConstraintName("FK_tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc_tbHocVien");

            entity.HasOne(d => d.IdLoaiDanhHieuThiDuaGiaiThuongKhenThuongNavigation).WithMany(p => p.TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocs)
                .HasForeignKey(d => d.IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong)
                .HasConstraintName("FK_tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc_dmLoaiDanhHieuThiDuaGiaiThuongKhenThuong");

            entity.HasOne(d => d.IdPhuongThucKhenThuongNavigation).WithMany(p => p.TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHocs)
                .HasForeignKey(d => d.IdPhuongThucKhenThuong)
                .HasConstraintName("FK_tbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc_dmPhuongThucKhenThuong");
        });

        modelBuilder.Entity<TbDanhSachNganhDaoTao>(entity =>
        {
            entity.HasKey(e => e.IdDanhSachNganhDaoTao);

            entity.ToTable("tbDanhSachNganhDaoTao", "NDT");

            entity.Property(e => e.IdDanhSachNganhDaoTao).ValueGeneratedNever();
            entity.Property(e => e.CoQuanBanHanh).HasMaxLength(50);
            entity.Property(e => e.MaNganhMoLanDau).HasMaxLength(50);
            entity.Property(e => e.NamBatDauDaoTao).HasColumnType("text");
            entity.Property(e => e.NamBatDauDaoTaoTuXa).HasColumnType("text");
            entity.Property(e => e.NamBatDauThucHienUuTienDaoTaoNhanLucDuLichCntt)
                .HasColumnType("text")
                .HasColumnName("NamBatDauThucHienUuTienDaoTaoNhanLucDuLichCNTT");
            entity.Property(e => e.NamTuyenSinhVaDaoTaoGanNhat).HasColumnType("text");
            entity.Property(e => e.NguoiKy).HasMaxLength(50);
            entity.Property(e => e.SoNamDaoTaoThSts).HasColumnName("SoNamDaoTaoThSTS");
            entity.Property(e => e.SoQuyetDinhChoPhepDoiTenNganh).HasMaxLength(50);
            entity.Property(e => e.SoQuyetDinhChoPhepMoNganh).HasMaxLength(50);
            entity.Property(e => e.SoQuyetDinhDaoTaoTuXa).HasMaxLength(50);
            entity.Property(e => e.TenNganhMoLanDau).HasMaxLength(200);
            entity.Property(e => e.UuTienDaoTaoNhanLucDuLichCntt).HasColumnName("UuTienDaoTaoNhanLucDuLichCNTT");

            entity.HasOne(d => d.HinhThucDaoTaoTheoChuyenNguNavigation).WithMany(p => p.TbDanhSachNganhDaoTaoHinhThucDaoTaoTheoChuyenNguNavigations)
                .HasForeignKey(d => d.HinhThucDaoTaoTheoChuyenNgu)
                .HasConstraintName("FK_tbDanhSachNganhDaoTao_dmTuyChon");

            entity.HasOne(d => d.IdNganhDaoTaoNavigation).WithMany(p => p.TbDanhSachNganhDaoTaos)
                .HasForeignKey(d => d.IdNganhDaoTao)
                .HasConstraintName("FK_tbDanhSachNganhDaoTao_dmNganhDaoTao");

            entity.HasOne(d => d.IdQuyetDinhTuChuNavigation).WithMany(p => p.TbDanhSachNganhDaoTaos)
                .HasForeignKey(d => d.IdQuyetDinhTuChu)
                .HasConstraintName("FK_tbDanhSachNganhDaoTao_dmQuyetDinhTuChu");

            entity.HasOne(d => d.IdTrangThaiDaoTaoNavigation).WithMany(p => p.TbDanhSachNganhDaoTaos)
                .HasForeignKey(d => d.IdTrangThaiDaoTao)
                .HasConstraintName("FK_tbDanhSachNganhDaoTao_dmTrangThaiDaoTao");

            entity.HasOne(d => d.IdTuChuMoNganhNavigation).WithMany(p => p.TbDanhSachNganhDaoTaos)
                .HasForeignKey(d => d.IdTuChuMoNganh)
                .HasConstraintName("FK_tbDanhSachNganhDaoTao_dmTuChuMoNganh");

            entity.HasOne(d => d.NganhDaoTaoLienKetNuocNgoaiNavigation).WithMany(p => p.TbDanhSachNganhDaoTaoNganhDaoTaoLienKetNuocNgoaiNavigations)
                .HasForeignKey(d => d.NganhDaoTaoLienKetNuocNgoai)
                .HasConstraintName("FK_tbDanhSachNganhDaoTao_dmTuyChon2");

            entity.HasOne(d => d.UuTienDaoTaoNhanLucDuLichCnttNavigation).WithMany(p => p.TbDanhSachNganhDaoTaoUuTienDaoTaoNhanLucDuLichCnttNavigations)
                .HasForeignKey(d => d.UuTienDaoTaoNhanLucDuLichCntt)
                .HasConstraintName("FK_tbDanhSachNganhDaoTao_dmTuyChon1");
        });

        modelBuilder.Entity<TbDanhSachVanBangChungChi>(entity =>
        {
            entity.HasKey(e => e.IdDanhSachVanBangChungChi);

            entity.ToTable("tbDanhSachVanBangChungChi", "VB");

            entity.Property(e => e.IdDanhSachVanBangChungChi).ValueGeneratedNever();
            entity.Property(e => e.LinkFileScan).HasColumnType("text");
            entity.Property(e => e.NamTotNghiep).HasColumnType("text");
            entity.Property(e => e.SoHieuVanBang).HasMaxLength(50);
            entity.Property(e => e.SoQuyetDinhCongNhanTotNghiep).HasMaxLength(50);
            entity.Property(e => e.SoQuyetDinhThanhLapHoiDongDanhGiaLuanVan).HasMaxLength(50);
            entity.Property(e => e.SoVaoSoGocCapVanBang).HasMaxLength(50);
            entity.Property(e => e.TenDonViBangCap).HasMaxLength(200);
            entity.Property(e => e.TenVanBang).HasMaxLength(200);

            entity.HasOne(d => d.IdHocVienNavigation).WithMany(p => p.TbDanhSachVanBangChungChis)
                .HasForeignKey(d => d.IdHocVien)
                .HasConstraintName("FK_tbDanhSachVanBangChungChi_tbHocVien");

            entity.HasOne(d => d.IdLoaiTotNghiepNavigation).WithMany(p => p.TbDanhSachVanBangChungChis)
                .HasForeignKey(d => d.IdLoaiTotNghiep)
                .HasConstraintName("FK_tbDanhSachVanBangChungChi_dmLoaiTotNghiep");
        });

        modelBuilder.Entity<TbDatDai>(entity =>
        {
            entity.HasKey(e => e.IdDatDai);

            entity.ToTable("tbDatDai", "CSVC");

            entity.Property(e => e.IdDatDai).ValueGeneratedNever();
            entity.Property(e => e.MaGiayChungNhanQuyenSoHuu).HasMaxLength(200);
            entity.Property(e => e.MinhChungQuyenSoHuuDatDai).HasMaxLength(200);
            entity.Property(e => e.MucDichSuDungDat).HasMaxLength(200);
            entity.Property(e => e.NamBatDauSuDungDat).HasColumnType("text");
            entity.Property(e => e.TenDonViSoHuu).HasMaxLength(200);

            entity.HasOne(d => d.IdHinhThucSoHuuNavigation).WithMany(p => p.TbDatDais)
                .HasForeignKey(d => d.IdHinhThucSoHuu)
                .HasConstraintName("FK_tbDatDai_dmHinhThucSoHuu");
        });

        modelBuilder.Entity<TbDauMoiLienHe>(entity =>
        {
            entity.HasKey(e => e.IdDauMoiLienHe);

            entity.ToTable("tbDauMoiLienHe", "CSGD");

            entity.Property(e => e.IdDauMoiLienHe).ValueGeneratedNever();
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.SoDienThoai).HasMaxLength(50);

            entity.HasOne(d => d.IdLoaiDauMoiLienHeNavigation).WithMany(p => p.TbDauMoiLienHes)
                .HasForeignKey(d => d.IdLoaiDauMoiLienHe)
                .HasConstraintName("FK_tbDauMoiLienHe_dmDauMoiLienHe");
        });

        modelBuilder.Entity<TbDeAnDuAnChuongTrinh>(entity =>
        {
            entity.HasKey(e => e.IdDeAnDuAnChuongTrinh);

            entity.ToTable("tbDeAnDuAnChuongTrinh", "HTQT");

            entity.Property(e => e.IdDeAnDuAnChuongTrinh).ValueGeneratedNever();
            entity.Property(e => e.MaDeAnDuAnChuongTrinh).HasMaxLength(50);
            entity.Property(e => e.TenDeAnDuAnChuongTrinh).HasMaxLength(200);

            entity.HasOne(d => d.IdNguonKinhPhiDeAnDuAnChuongTrinhNavigation).WithMany(p => p.TbDeAnDuAnChuongTrinhs)
                .HasForeignKey(d => d.IdNguonKinhPhiDeAnDuAnChuongTrinh)
                .HasConstraintName("FK_tbDeAnDuAnChuongTrinh_dmNguonKinhPhiChoDeAn");
        });

        modelBuilder.Entity<TbDienBienLuong>(entity =>
        {
            entity.HasKey(e => e.IdDienBienLuong);

            entity.ToTable("tbDienBienLuong", "CB");

            entity.Property(e => e.IdDienBienLuong).ValueGeneratedNever();

            entity.HasOne(d => d.IdBacLuongNavigation).WithMany(p => p.TbDienBienLuongs)
                .HasForeignKey(d => d.IdBacLuong)
                .HasConstraintName("FK_tbDienBienLuong_dmBacLuong");

            entity.HasOne(d => d.IdCanBoNavigation).WithMany(p => p.TbDienBienLuongs)
                .HasForeignKey(d => d.IdCanBo)
                .HasConstraintName("FK_tbDienBienLuong_tbCanBo");

            entity.HasOne(d => d.IdHeSoLuongNavigation).WithMany(p => p.TbDienBienLuongs)
                .HasForeignKey(d => d.IdHeSoLuong)
                .HasConstraintName("FK_tbDienBienLuong_dmHeSoLuong");

            entity.HasOne(d => d.IdTrinhDoDaoTaoNavigation).WithMany(p => p.TbDienBienLuongs)
                .HasForeignKey(d => d.IdTrinhDoDaoTao)
                .HasConstraintName("FK_tbDienBienLuong_dmTrinhDoDaoTao");
        });

        modelBuilder.Entity<TbDoanCongTac>(entity =>
        {
            entity.HasKey(e => e.IdDoanCongTac);

            entity.ToTable("tbDoanCongTac", "HTQT");

            entity.Property(e => e.IdDoanCongTac).ValueGeneratedNever();
            entity.Property(e => e.KetQuaCongTac).HasMaxLength(200);
            entity.Property(e => e.MaDoanCongTac).HasMaxLength(50);
            entity.Property(e => e.SoQuyetDinh).HasMaxLength(50);
            entity.Property(e => e.TenDoanCongTac).HasMaxLength(200);

            entity.HasOne(d => d.IdPhanLoaiDoanRaDoanVaoNavigation).WithMany(p => p.TbDoanCongTacs)
                .HasForeignKey(d => d.IdPhanLoaiDoanRaDoanVao)
                .HasConstraintName("FK_tbDoanCongTac_dmPhanLoaiDoanRaDoanVao");

            entity.HasOne(d => d.IdQuocGiaDoanNavigation).WithMany(p => p.TbDoanCongTacs)
                .HasForeignKey(d => d.IdQuocGiaDoan)
                .HasConstraintName("FK_tbDoanCongTac_dmQuocTich");
        });

        modelBuilder.Entity<TbDoanhNghiepKhcn>(entity =>
        {
            entity.HasKey(e => e.IdDoanhNghiepKhcn);

            entity.ToTable("tbDoanhNghiepKHCN", "KHCN");

            entity.Property(e => e.IdDoanhNghiepKhcn)
                .ValueGeneratedNever()
                .HasColumnName("IdDoanhNghiepKHCN");
            entity.Property(e => e.DiaDiemThanhLap).HasMaxLength(200);
            entity.Property(e => e.IdHinhThucDoanhNghiepKhcn).HasColumnName("IdHinhThucDoanhNghiepKHCN");
            entity.Property(e => e.KinhPhiGopVonTuTaiSanTriTue).HasMaxLength(50);
            entity.Property(e => e.MaDoanhNghiep).HasMaxLength(50);
            entity.Property(e => e.TenDoanhNghiep).HasMaxLength(300);
            entity.Property(e => e.TyLeGopVonCuaCsgddh).HasColumnName("TyLeGopVonCuaCSGDDH");

            entity.HasOne(d => d.IdHinhThucDoanhNghiepKhcnNavigation).WithMany(p => p.TbDoanhNghiepKhcns)
                .HasForeignKey(d => d.IdHinhThucDoanhNghiepKhcn)
                .HasConstraintName("FK_tbDoanhNghiepKHCN_dmHinhThucDoanhNghiepKHCN");
        });

        modelBuilder.Entity<TbDoiTuongChinhSachCanBo>(entity =>
        {
            entity.HasKey(e => e.IdDoiTuongChinhSachCanBo);

            entity.ToTable("tbDoiTuongChinhSachCanBo", "CB");

            entity.Property(e => e.IdDoiTuongChinhSachCanBo).ValueGeneratedNever();

            entity.HasOne(d => d.IdCanBoNavigation).WithMany(p => p.TbDoiTuongChinhSachCanBos)
                .HasForeignKey(d => d.IdCanBo)
                .HasConstraintName("FK_tbDoiTuongChinhSachCanBo_tbCanBo");

            entity.HasOne(d => d.IdDoiTuongChinhSachNavigation).WithMany(p => p.TbDoiTuongChinhSachCanBos)
                .HasForeignKey(d => d.IdDoiTuongChinhSach)
                .HasConstraintName("FK_tbDoiTuongChinhSachCanBo_dmDoiTuongChinhSach");
        });

        modelBuilder.Entity<TbDoiTuongThamGium>(entity =>
        {
            entity.HasKey(e => e.IdDoiTuongThamGia);

            entity.ToTable("tbDoiTuongThamGia", "KHCN");

            entity.Property(e => e.IdDoiTuongThamGia).ValueGeneratedNever();
            entity.Property(e => e.MaLoaiThamGia).HasMaxLength(50);

            entity.HasOne(d => d.IdLoaiThamGiaNavigation).WithMany(p => p.TbDoiTuongThamGia)
                .HasForeignKey(d => d.IdLoaiThamGia)
                .HasConstraintName("FK_tbDoiTuongThamGia_dmLoaiThamGia");

            entity.HasOne(d => d.IdNguoiNavigation).WithMany(p => p.TbDoiTuongThamGia)
                .HasForeignKey(d => d.IdNguoi)
                .HasConstraintName("FK_tbDoiTuongThamGia_tbNguoi");

            entity.HasOne(d => d.IdPhanLoaiNavigation).WithMany(p => p.TbDoiTuongThamGia)
                .HasForeignKey(d => d.IdPhanLoai)
                .HasConstraintName("FK_tbDoiTuongThamGia_dmPhanLoaiDoiNguNguoiHoc");

            entity.HasOne(d => d.IdVaiTroNavigation).WithMany(p => p.TbDoiTuongThamGia)
                .HasForeignKey(d => d.IdVaiTro)
                .HasConstraintName("FK_tbDoiTuongThamGia_dmVaiTroThamGia");
        });

        modelBuilder.Entity<TbDonViCongTacCuaCanBo>(entity =>
        {
            entity.HasKey(e => e.IdDvct).HasName("PK_tbDVCT");

            entity.ToTable("tbDonViCongTacCuaCanBo", "CB");

            entity.Property(e => e.IdDvct)
                .ValueGeneratedNever()
                .HasColumnName("IdDVCT");
            entity.Property(e => e.MaPhongBanDonVi).HasMaxLength(200);
            entity.Property(e => e.SoQuyetDinh).HasMaxLength(50);

            entity.HasOne(d => d.IdCanBoNavigation).WithMany(p => p.TbDonViCongTacCuaCanBos)
                .HasForeignKey(d => d.IdCanBo)
                .HasConstraintName("FK_tbDonViCongTacCuaCanBo_tbCanBo");

            entity.HasOne(d => d.IdChucVuNavigation).WithMany(p => p.TbDonViCongTacCuaCanBos)
                .HasForeignKey(d => d.IdChucVu)
                .HasConstraintName("FK_tbDonViCongTacCuaCanBo_dmChucVu");

            entity.HasOne(d => d.IdHinhThucBoNhiemNavigation).WithMany(p => p.TbDonViCongTacCuaCanBos)
                .HasForeignKey(d => d.IdHinhThucBoNhiem)
                .HasConstraintName("FK_tbDonViCongTacCuaCanBo_dmHinhThucBoNhiem");
        });

        modelBuilder.Entity<TbDonViLienKetDaoTaoGiaoDuc>(entity =>
        {
            entity.HasKey(e => e.IdDonViLienKetDaoTaoGiaoDuc);

            entity.ToTable("tbDonViLienKetDaoTaoGiaoDuc", "CSGD");

            entity.Property(e => e.IdDonViLienKetDaoTaoGiaoDuc).ValueGeneratedNever();
            entity.Property(e => e.DiaChi).HasMaxLength(200);
            entity.Property(e => e.DienThoai).HasMaxLength(50);

            entity.HasOne(d => d.IdCoSoGiaoDucNavigation).WithMany(p => p.TbDonViLienKetDaoTaoGiaoDucs)
                .HasForeignKey(d => d.IdCoSoGiaoDuc)
                .HasConstraintName("FK_tbDonViLienKetDaoTaoGiaoDuc_tbCoSoGiaoDuc");

            entity.HasOne(d => d.IdLoaiLienKetNavigation).WithMany(p => p.TbDonViLienKetDaoTaoGiaoDucs)
                .HasForeignKey(d => d.IdLoaiLienKet)
                .HasConstraintName("FK_tbDonViLienKetDaoTaoGiaoDuc_tbDonViLienKetDaoTaoGiaoDuc");
        });

        modelBuilder.Entity<TbDonViThinhGiangCuaCanBo>(entity =>
        {
            entity.HasKey(e => e.IdDonViThinhGiangCuaCanBo);

            entity.ToTable("tbDonViThinhGiangCuaCanBo", "CB");

            entity.Property(e => e.IdDonViThinhGiangCuaCanBo).ValueGeneratedNever();
            entity.Property(e => e.DonViThinhGiang).HasMaxLength(200);
            entity.Property(e => e.SoHopDongThinhGiang).HasMaxLength(200);

            entity.HasOne(d => d.IdCanBoNavigation).WithMany(p => p.TbDonViThinhGiangCuaCanBos)
                .HasForeignKey(d => d.IdCanBo)
                .HasConstraintName("FK_tbDonViThinhGiangCuaCanBo_tbCanBo");
        });

        modelBuilder.Entity<TbDuLieuTrungTuyen>(entity =>
        {
            entity.HasKey(e => e.IdDuLieuTrungTuyen);

            entity.ToTable("tbDuLieuTrungTuyen", "TS");

            entity.Property(e => e.IdDuLieuTrungTuyen).ValueGeneratedNever();
            entity.Property(e => e.Cccd)
                .HasMaxLength(50)
                .HasColumnName("CCCD");
            entity.Property(e => e.ChuongTrinhDaoTaoDaTotNghiepTrinhDoDaiHoc).HasMaxLength(50);
            entity.Property(e => e.ChuongTrinhDaoTaoDaTotNghiepTrinhDoThacSi).HasMaxLength(50);
            entity.Property(e => e.HoVaTen).HasMaxLength(50);
            entity.Property(e => e.KhoaDaoTaoTrungTuyen).HasMaxLength(50);
            entity.Property(e => e.MaTuyenSinh).HasMaxLength(50);
            entity.Property(e => e.NganhDaTotNghiepTrinhDoDaiHoc).HasMaxLength(50);
            entity.Property(e => e.NganhDaTotNghiepTrinhDoThacSi).HasMaxLength(50);
            entity.Property(e => e.SoQuyetDinhTrungTuyen).HasMaxLength(50);
            entity.Property(e => e.ToHopMonTrungTuyen).HasMaxLength(200);
            entity.Property(e => e.TruongThpt)
                .HasMaxLength(200)
                .HasColumnName("TruongTHPT");

            entity.HasOne(d => d.IdDoiTuongDauVaoNavigation).WithMany(p => p.TbDuLieuTrungTuyens)
                .HasForeignKey(d => d.IdDoiTuongDauVao)
                .HasConstraintName("FK_tbDuLieuTrungTuyen_dmDoiTuongDauVao");

            entity.HasOne(d => d.IdDoiTuongUuTienNavigation).WithMany(p => p.TbDuLieuTrungTuyens)
                .HasForeignKey(d => d.IdDoiTuongUuTien)
                .HasConstraintName("FK_tbDuLieuTrungTuyen_dmDoiTuongUuTien");

            entity.HasOne(d => d.IdHinhThucTuyenSinhNavigation).WithMany(p => p.TbDuLieuTrungTuyens)
                .HasForeignKey(d => d.IdHinhThucTuyenSinh)
                .HasConstraintName("FK_tbDuLieuTrungTuyen_dmHinhThucTuyenSinh");

            entity.HasOne(d => d.IdKhuVucNavigation).WithMany(p => p.TbDuLieuTrungTuyens)
                .HasForeignKey(d => d.IdKhuVuc)
                .HasConstraintName("FK_tbDuLieuTrungTuyen_dmKhuVuc");
        });

        modelBuilder.Entity<TbGiaHanChuongTrinhDaoTao>(entity =>
        {
            entity.HasKey(e => e.IdGiaHanChuongTrinhDaoTao);

            entity.ToTable("tbGiaHanChuongTrinhDaoTao", "CTDT");

            entity.Property(e => e.IdGiaHanChuongTrinhDaoTao).ValueGeneratedNever();
            entity.Property(e => e.SoQuyetDinhGiaHan).HasMaxLength(200);

            entity.HasOne(d => d.IdChuongTrinhDaoTaoNavigation).WithMany(p => p.TbGiaHanChuongTrinhDaoTaos)
                .HasForeignKey(d => d.IdChuongTrinhDaoTao)
                .HasConstraintName("FK_tbGiaHanChuongTrinhDaoTao_tbChuongTrinhDaoTao");
        });

        modelBuilder.Entity<TbGiaiThuongKhoaHoc>(entity =>
        {
            entity.HasKey(e => e.IdGiaiThuongKhoaHoc);

            entity.ToTable("tbGiaiThuongKhoaHoc", "KHCN");

            entity.Property(e => e.IdGiaiThuongKhoaHoc).ValueGeneratedNever();
            entity.Property(e => e.CoQuanBanHanhQuyetDinh).HasMaxLength(50);
            entity.Property(e => e.CoQuanToChucGiaiThuong).HasMaxLength(50);
            entity.Property(e => e.MaGiaiThuong).HasMaxLength(50);
            entity.Property(e => e.QuyetDinhCapBangKhen).HasMaxLength(50);
            entity.Property(e => e.TenDeTaiDuocTraoGiai).HasMaxLength(50);
            entity.Property(e => e.TenDonViDuocTraoGiai).HasMaxLength(50);

            entity.HasOne(d => d.IdLoaiGiaiThuongNavigation).WithMany(p => p.TbGiaiThuongKhoaHocs)
                .HasForeignKey(d => d.IdLoaiGiaiThuong)
                .HasConstraintName("FK_tbGiaiThuongKhoaHoc_dmLoaiGiaiThuongKHCN");

            entity.HasOne(d => d.IdMucGiaiThuongNavigation).WithMany(p => p.TbGiaiThuongKhoaHocs)
                .HasForeignKey(d => d.IdMucGiaiThuong)
                .HasConstraintName("FK_tbGiaiThuongKhoaHoc_dmMucGiaiThuong");
        });

        modelBuilder.Entity<TbGiangVienNn>(entity =>
        {
            entity.HasKey(e => e.IdGvnn);

            entity.ToTable("tbGiangVienNN", "CB");

            entity.Property(e => e.IdGvnn)
                .ValueGeneratedNever()
                .HasColumnName("IdGVNN");
            entity.Property(e => e.CoQuanChuQuanOnuocNgoai)
                .HasMaxLength(200)
                .HasColumnName("CoQuanChuQuanONuocNgoai");

            entity.HasOne(d => d.IdCanBoNavigation).WithMany(p => p.TbGiangVienNns)
                .HasForeignKey(d => d.IdCanBo)
                .HasConstraintName("FK_tbGiangVienNN_tbCanBo");

            entity.HasOne(d => d.IdNoiDungHoatDongTaiVietNamNavigation).WithMany(p => p.TbGiangVienNns)
                .HasForeignKey(d => d.IdNoiDungHoatDongTaiVietNam)
                .HasConstraintName("FK_tbGiangVienNN_dmNoiDungHoatDongTaiVietNam");
        });

        modelBuilder.Entity<TbGiaoVienQpan>(entity =>
        {
            entity.HasKey(e => e.IdGiaoVienQpan);

            entity.ToTable("tbGiaoVienQPAN", "CB");

            entity.Property(e => e.IdGiaoVienQpan)
                .ValueGeneratedNever()
                .HasColumnName("IdGiaoVienQPAN");
            entity.Property(e => e.DaoTaoGdqpan)
                .HasMaxLength(200)
                .HasColumnName("DaoTaoGDQPAN");
            entity.Property(e => e.IdLoaiGiangVienQp).HasColumnName("IdLoaiGiangVienQP");
            entity.Property(e => e.SoTruongCongTac).HasMaxLength(200);

            entity.HasOne(d => d.IdCanBoNavigation).WithMany(p => p.TbGiaoVienQpans)
                .HasForeignKey(d => d.IdCanBo)
                .HasConstraintName("FK_tbGiaoVienQPAN_tbCanBo");

            entity.HasOne(d => d.IdLoaiGiangVienQpNavigation).WithMany(p => p.TbGiaoVienQpans)
                .HasForeignKey(d => d.IdLoaiGiangVienQp)
                .HasConstraintName("FK_tbGiaoVienQPAN_dmLoaiGiangVienQuocPhong");

            entity.HasOne(d => d.IdQuanHamNavigation).WithMany(p => p.TbGiaoVienQpans)
                .HasForeignKey(d => d.IdQuanHam)
                .HasConstraintName("FK_tbGiaoVienQPAN_dmQuanHam");
        });

        modelBuilder.Entity<TbGvduocCuDiDaoTao>(entity =>
        {
            entity.HasKey(e => e.IdGvduocCuDiDaoTao);

            entity.ToTable("tbGVDuocCuDiDaoTao", "HTQT");

            entity.Property(e => e.IdGvduocCuDiDaoTao)
                .ValueGeneratedNever()
                .HasColumnName("IdGVDuocCuDiDaoTao");
            entity.Property(e => e.IdHinhThucThamGiaGvduocCuDiDaoTao).HasColumnName("IdHinhThucThamGiaGVDuocCuDiDaoTao");
            entity.Property(e => e.IdNguonKinhPhiCuaGv).HasColumnName("IdNguonKinhPhiCuaGV");
            entity.Property(e => e.IdTinhTrangGvduocCuDiDaoTao).HasColumnName("IdTinhTrangGVDuocCuDiDaoTao");
            entity.Property(e => e.TenCoSoGiaoDucThamGiaOnn)
                .HasMaxLength(200)
                .HasColumnName("TenCoSoGiaoDucThamGiaONN");

            entity.HasOne(d => d.IdCanBoNavigation).WithMany(p => p.TbGvduocCuDiDaoTaos)
                .HasForeignKey(d => d.IdCanBo)
                .HasConstraintName("FK_tbGVDuocCuDiDaoTao_tbCanBo");

            entity.HasOne(d => d.IdHinhThucThamGiaGvduocCuDiDaoTaoNavigation).WithMany(p => p.TbGvduocCuDiDaoTaos)
                .HasForeignKey(d => d.IdHinhThucThamGiaGvduocCuDiDaoTao)
                .HasConstraintName("FK_tbGVDuocCuDiDaoTao_dmHinhThucThamGiaGVDuocCuDiDaoTao");

            entity.HasOne(d => d.IdNguonKinhPhiCuaGvNavigation).WithMany(p => p.TbGvduocCuDiDaoTaos)
                .HasForeignKey(d => d.IdNguonKinhPhiCuaGv)
                .HasConstraintName("FK_tbGVDuocCuDiDaoTao_dmNguonKinhPhiCuaGVDuocCuDiDaoTao");

            entity.HasOne(d => d.IdQuocGiaDenNavigation).WithMany(p => p.TbGvduocCuDiDaoTaos)
                .HasForeignKey(d => d.IdQuocGiaDen)
                .HasConstraintName("FK_tbGVDuocCuDiDaoTao_dmQuocTich");

            entity.HasOne(d => d.IdTinhTrangGvduocCuDiDaoTaoNavigation).WithMany(p => p.TbGvduocCuDiDaoTaos)
                .HasForeignKey(d => d.IdTinhTrangGvduocCuDiDaoTao)
                .HasConstraintName("FK_tbGVDuocCuDiDaoTao_dmTinhTrangGiangVienDuocCuDiDaoTao");
        });

        modelBuilder.Entity<TbHinhThucDaoTaoCuaNganh>(entity =>
        {
            entity.HasKey(e => e.IdHinhThucDaoTaoCuaNganh);

            entity.ToTable("tbHinhThucDaoTaoCuaNganh", "NDT");

            entity.Property(e => e.IdHinhThucDaoTaoCuaNganh).ValueGeneratedNever();

            entity.HasOne(d => d.IdHinhThucDaoTaoNavigation).WithMany(p => p.TbHinhThucDaoTaoCuaNganhs)
                .HasForeignKey(d => d.IdHinhThucDaoTao)
                .HasConstraintName("FK_tbHinhThucDaoTaoCuaNganh_dmHinhThucDaoTao");

            entity.HasOne(d => d.IdNganhDaoTaoNavigation).WithMany(p => p.TbHinhThucDaoTaoCuaNganhs)
                .HasForeignKey(d => d.IdNganhDaoTao)
                .HasConstraintName("FK_tbHinhThucDaoTaoCuaNganh_dmNganhDaoTao");
        });

        modelBuilder.Entity<TbHoatDongBaoVeMoiTruong>(entity =>
        {
            entity.HasKey(e => e.IdHoatDongBaoVeMoiTruong);

            entity.ToTable("tbHoatDongBaoVeMoiTruong", "KHCN");

            entity.Property(e => e.IdHoatDongBaoVeMoiTruong).ValueGeneratedNever();
            entity.Property(e => e.CoQuanChuTri).HasMaxLength(50);
            entity.Property(e => e.DanhGiaKetQuaNhiemVu).HasMaxLength(50);
            entity.Property(e => e.DonViThucHienLuuTruSanPham).HasMaxLength(50);
            entity.Property(e => e.IdNhiemVuKhcn).HasColumnName("IdNhiemVuKHCN");
            entity.Property(e => e.SanPhamChinhCuaNhiemVu).HasMaxLength(50);
            entity.Property(e => e.TenNhiemVuBvmt)
                .HasMaxLength(300)
                .HasColumnName("TenNhiemVuBVMT");

            entity.HasOne(d => d.IdCapQuanLyNhiemVuNavigation).WithMany(p => p.TbHoatDongBaoVeMoiTruongs)
                .HasForeignKey(d => d.IdCapQuanLyNhiemVu)
                .HasConstraintName("FK_tbHoatDongBaoVeMoiTruong_dmPhanCapNhiemVu");

            entity.HasOne(d => d.IdCoQuanChuQuanNavigation).WithMany(p => p.TbHoatDongBaoVeMoiTruongs)
                .HasForeignKey(d => d.IdCoQuanChuQuan)
                .HasConstraintName("FK_tbHoatDongBaoVeMoiTruong_dmCoQuanChuQuan");

            entity.HasOne(d => d.IdLoaiNhiemVuBaoVeMoiTruongNavigation).WithMany(p => p.TbHoatDongBaoVeMoiTruongs)
                .HasForeignKey(d => d.IdLoaiNhiemVuBaoVeMoiTruong)
                .HasConstraintName("FK_tbHoatDongBaoVeMoiTruong_dmLoaiNhiemVuBaoVeMoiTruong");

            entity.HasOne(d => d.IdNguonKinhPhiNavigation).WithMany(p => p.TbHoatDongBaoVeMoiTruongs)
                .HasForeignKey(d => d.IdNguonKinhPhi)
                .HasConstraintName("FK_tbHoatDongBaoVeMoiTruong_dmNguonKinhPhi");

            entity.HasOne(d => d.IdNhiemVuKhcnNavigation).WithMany(p => p.TbHoatDongBaoVeMoiTruongs)
                .HasForeignKey(d => d.IdNhiemVuKhcn)
                .HasConstraintName("FK_tbHoatDongBaoVeMoiTruong_tbNhiemVuKHCN");

            entity.HasOne(d => d.IdTinhTrangNhiemVuNavigation).WithMany(p => p.TbHoatDongBaoVeMoiTruongs)
                .HasForeignKey(d => d.IdTinhTrangNhiemVu)
                .HasConstraintName("FK_tbHoatDongBaoVeMoiTruong_dmTinhTrangNhiemVu");
        });

        modelBuilder.Entity<TbHoatDongTaiChinh>(entity =>
        {
            entity.HasKey(e => e.IdHoatDongTaiChinh);

            entity.ToTable("tbHoatDongTaiChinh", "TCTS");

            entity.Property(e => e.IdHoatDongTaiChinh).ValueGeneratedNever();
            entity.Property(e => e.NamTaiChinh).HasColumnType("text");
            entity.Property(e => e.NoiDung).HasColumnType("ntext");

            entity.HasOne(d => d.IdLoaiHoatDongTaiChinhNavigation).WithMany(p => p.TbHoatDongTaiChinhs)
                .HasForeignKey(d => d.IdLoaiHoatDongTaiChinh)
                .HasConstraintName("FK_tbHoatDongTaiChinh_dmHoatDongTaiChinh");
        });

        modelBuilder.Entity<TbHocVien>(entity =>
        {
            entity.HasKey(e => e.IdHocVien);

            entity.ToTable("tbHocVien", "NH");

            entity.Property(e => e.IdHocVien).ValueGeneratedNever();
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.MaHocVien).HasMaxLength(50);
            entity.Property(e => e.NoiSinh).HasMaxLength(200);
            entity.Property(e => e.QueQuan).HasMaxLength(200);
            entity.Property(e => e.Sdt).HasMaxLength(50);
            entity.Property(e => e.SoSoBaoHiem).HasMaxLength(50);

            entity.HasOne(d => d.IdHuyenNavigation).WithMany(p => p.TbHocViens)
                .HasForeignKey(d => d.IdHuyen)
                .HasConstraintName("FK_tbHocVien_dmHuyen");

            entity.HasOne(d => d.IdLoaiKhuyetTatNavigation).WithMany(p => p.TbHocViens)
                .HasForeignKey(d => d.IdLoaiKhuyetTat)
                .HasConstraintName("FK_tbHocVien_dmLoaiKhuyetTat");

            entity.HasOne(d => d.IdNguoiNavigation).WithMany(p => p.TbHocViens)
                .HasForeignKey(d => d.IdNguoi)
                .HasConstraintName("FK_tbHocVien_tbNguoi");

            entity.HasOne(d => d.IdTinhNavigation).WithMany(p => p.TbHocViens)
                .HasForeignKey(d => d.IdTinh)
                .HasConstraintName("FK_tbHocVien_dmTinh");

            entity.HasOne(d => d.IdXaNavigation).WithMany(p => p.TbHocViens)
                .HasForeignKey(d => d.IdXa)
                .HasConstraintName("FK_tbHocVien_dmXa");
        });

        modelBuilder.Entity<TbHoiThaoHoiNghi>(entity =>
        {
            entity.HasKey(e => e.IdHoiThaoHoiNghi);

            entity.ToTable("tbHoiThaoHoiNghi", "HTQT");

            entity.Property(e => e.IdHoiThaoHoiNghi).ValueGeneratedNever();
            entity.Property(e => e.CoQuanCoThamQuyenCapPhep).HasMaxLength(200);
            entity.Property(e => e.DonViChuTri).HasMaxLength(200);
            entity.Property(e => e.MaHoiThaoHoiNghi).HasMaxLength(50);
            entity.Property(e => e.MucTieu).HasMaxLength(200);
            entity.Property(e => e.TenHoiThaoHoiNghi).HasMaxLength(200);

            entity.HasOne(d => d.IdNguonKinhPhiHoiThaoNavigation).WithMany(p => p.TbHoiThaoHoiNghis)
                .HasForeignKey(d => d.IdNguonKinhPhiHoiThao)
                .HasConstraintName("FK_tbHoiThaoHoiNghi_dmNguonKinhPhi");
        });

        modelBuilder.Entity<TbHopDong>(entity =>
        {
            entity.HasKey(e => e.IdHopDong);

            entity.ToTable("tbHopDong", "CB");

            entity.Property(e => e.IdHopDong).ValueGeneratedNever();
            entity.Property(e => e.SoHopDong).HasMaxLength(200);
            entity.Property(e => e.SoQuyetDinh).HasMaxLength(200);

            entity.HasOne(d => d.IdCanBoNavigation).WithMany(p => p.TbHopDongs)
                .HasForeignKey(d => d.IdCanBo)
                .HasConstraintName("FK_tbHopDong_tbCanBo");

            entity.HasOne(d => d.IdLoaiHopDongNavigation).WithMany(p => p.TbHopDongs)
                .HasForeignKey(d => d.IdLoaiHopDong)
                .HasConstraintName("FK_tbHopDong_dmLoaiHopDong");

            entity.HasOne(d => d.IdTinhTrangHopDongNavigation).WithMany(p => p.TbHopDongs)
                .HasForeignKey(d => d.IdTinhTrangHopDong)
                .HasConstraintName("FK_tbHopDong_dmTinhTrangHopDong");
        });

        modelBuilder.Entity<TbHopDongThinhGiang>(entity =>
        {
            entity.HasKey(e => e.IdHopDongThinhGiang);

            entity.ToTable("tbHopDongThinhGiang", "CB");

            entity.Property(e => e.IdHopDongThinhGiang).ValueGeneratedNever();
            entity.Property(e => e.MaHopDongThinhGiang).HasMaxLength(200);
            entity.Property(e => e.NoiCapSoLaoDong).HasMaxLength(200);
            entity.Property(e => e.SoSoLaoDong).HasMaxLength(200);

            entity.HasOne(d => d.IdCanBoNavigation).WithMany(p => p.TbHopDongThinhGiangs)
                .HasForeignKey(d => d.IdCanBo)
                .HasConstraintName("FK_tbHopDongThinhGiang_tbCanBo");

            entity.HasOne(d => d.IdTrangThaiHopDongNavigation).WithMany(p => p.TbHopDongThinhGiangs)
                .HasForeignKey(d => d.IdTrangThaiHopDong)
                .HasConstraintName("FK_tbHopDongThinhGiang_dmTrangThaiHopDong");
        });

        modelBuilder.Entity<TbKhoaBoiDuongTapHuanThamGiaCuaCanBo>(entity =>
        {
            entity.HasKey(e => e.IdKhoaBoiDuongTapHuanThamGiaCuaCanBo);

            entity.ToTable("tbKhoaBoiDuongTapHuanThamGiaCuaCanBo", "CB");

            entity.Property(e => e.IdKhoaBoiDuongTapHuanThamGiaCuaCanBo).ValueGeneratedNever();
            entity.Property(e => e.ChungChi).HasMaxLength(200);
            entity.Property(e => e.DiaDiemToChuc).HasMaxLength(200);
            entity.Property(e => e.DonViToChuc).HasMaxLength(200);
            entity.Property(e => e.TenKhoaBoiDuongTapHuan).HasMaxLength(200);

            entity.HasOne(d => d.IdCanBoNavigation).WithMany(p => p.TbKhoaBoiDuongTapHuanThamGiaCuaCanBos)
                .HasForeignKey(d => d.IdCanBo)
                .HasConstraintName("FK_tbKhoaBoiDuongTapHuanThamGiaCuaCanBo_tbCanBo");

            entity.HasOne(d => d.IdLoaiBoiDuongNavigation).WithMany(p => p.TbKhoaBoiDuongTapHuanThamGiaCuaCanBos)
                .HasForeignKey(d => d.IdLoaiBoiDuong)
                .HasConstraintName("FK_tbKhoaBoiDuongTapHuanThamGiaCuaCanBo_dmLoaiBoiDuong");

            entity.HasOne(d => d.IdNguonKinhPhiNavigation).WithMany(p => p.TbKhoaBoiDuongTapHuanThamGiaCuaCanBos)
                .HasForeignKey(d => d.IdNguonKinhPhi)
                .HasConstraintName("FK_tbKhoaBoiDuongTapHuanThamGiaCuaCanBo_dmNguonKinhPhi");
        });

        modelBuilder.Entity<TbKhoaHoc>(entity =>
        {
            entity.HasKey(e => e.IdKhoaHoc);

            entity.ToTable("tbKhoaHoc", "CSGD");

            entity.Property(e => e.IdKhoaHoc).ValueGeneratedNever();
            entity.Property(e => e.DenNam).HasColumnType("text");
            entity.Property(e => e.TuNam).HasColumnType("text");
        });

        modelBuilder.Entity<TbKhoanNopNganSach>(entity =>
        {
            entity.HasKey(e => e.IdKhoanNopNganSach);

            entity.ToTable("tbKhoanNopNganSach", "TCTS");

            entity.Property(e => e.IdKhoanNopNganSach).ValueGeneratedNever();
            entity.Property(e => e.MaKhoanNop).HasMaxLength(50);
            entity.Property(e => e.NamTaiChinh).HasColumnType("text");
            entity.Property(e => e.TenKhoanNopNganSach).HasMaxLength(200);
        });

        modelBuilder.Entity<TbKhoanTrichLapQuy>(entity =>
        {
            entity.HasKey(e => e.IdKhoanTrichLapQuy);

            entity.ToTable("tbKhoanTrichLapQuy", "TCTS");

            entity.Property(e => e.IdKhoanTrichLapQuy).ValueGeneratedNever();
            entity.Property(e => e.MaKhoanTrichLapQuy).HasMaxLength(50);
            entity.Property(e => e.NamTaiChinh).HasColumnType("text");
            entity.Property(e => e.TenKhoanTrichLapQuy).HasMaxLength(200);
        });

        modelBuilder.Entity<TbKhoiNganhDaoTao>(entity =>
        {
            entity.HasKey(e => e.IdKhoiNganhDaoTao).HasName("PK_dmKhoiNganh");

            entity.ToTable("tbKhoiNganhDaoTao", "NDT");

            entity.Property(e => e.IdKhoiNganhDaoTao).ValueGeneratedNever();
            entity.Property(e => e.KhoiNganhDaoTao).HasMaxLength(50);
        });

        modelBuilder.Entity<TbKiTucXa>(entity =>
        {
            entity.HasKey(e => e.IdKiTucXa);

            entity.ToTable("tbKiTucXa", "CSVC");

            entity.Property(e => e.IdKiTucXa).ValueGeneratedNever();
            entity.Property(e => e.IdTinhTrangCsvc).HasColumnName("IdTinhTrangCSVC");
            entity.Property(e => e.MaKyTucxa).HasMaxLength(50);
            entity.Property(e => e.NamDuaVaoSuDung).HasColumnType("text");

            entity.HasOne(d => d.IdHinhThucSoHuuNavigation).WithMany(p => p.TbKiTucXas)
                .HasForeignKey(d => d.IdHinhThucSoHuu)
                .HasConstraintName("FK_tbKiTucXa_dmHinhThucSoHuu");

            entity.HasOne(d => d.IdTinhTrangCsvcNavigation).WithMany(p => p.TbKiTucXas)
                .HasForeignKey(d => d.IdTinhTrangCsvc)
                .HasConstraintName("FK_tbKiTucXa_dmTinhTrangCoSoVatChat");
        });

        modelBuilder.Entity<TbKyLuatCanBo>(entity =>
        {
            entity.HasKey(e => e.IdKyLuatCanBo);

            entity.ToTable("tbKyLuatCanBo", "CB");

            entity.Property(e => e.IdKyLuatCanBo).ValueGeneratedNever();
            entity.Property(e => e.LyDo).HasMaxLength(200);
            entity.Property(e => e.SoQuyetDinh).HasMaxLength(200);

            entity.HasOne(d => d.IdCanBoNavigation).WithMany(p => p.TbKyLuatCanBos)
                .HasForeignKey(d => d.IdCanBo)
                .HasConstraintName("FK_tbKyLuatCanBo_tbCanBo");

            entity.HasOne(d => d.IdCapQuyetDinhNavigation).WithMany(p => p.TbKyLuatCanBos)
                .HasForeignKey(d => d.IdCapQuyetDinh)
                .HasConstraintName("FK_tbKyLuatCanBo_dmCapKhenThuong");

            entity.HasOne(d => d.IdLoaiKyLuatNavigation).WithMany(p => p.TbKyLuatCanBos)
                .HasForeignKey(d => d.IdLoaiKyLuat)
                .HasConstraintName("FK_tbKyLuatCanBo_dmLoaiKyLuat");
        });

        modelBuilder.Entity<TbKyLuatNguoiHoc>(entity =>
        {
            entity.HasKey(e => e.IdKyLuatNguoiHoc);

            entity.ToTable("tbKyLuatNguoiHoc", "NH");

            entity.Property(e => e.IdKyLuatNguoiHoc).ValueGeneratedNever();
            entity.Property(e => e.LyDo).HasColumnType("ntext");
            entity.Property(e => e.NamBiKyLuat).HasColumnType("text");
            entity.Property(e => e.SoQuyetDinh).HasMaxLength(50);

            entity.HasOne(d => d.IdCapQuyetDinhNavigation).WithMany(p => p.TbKyLuatNguoiHocs)
                .HasForeignKey(d => d.IdCapQuyetDinh)
                .HasConstraintName("FK_tbKyLuatNguoiHoc_dmCapKhenThuong");

            entity.HasOne(d => d.IdHocVienNavigation).WithMany(p => p.TbKyLuatNguoiHocs)
                .HasForeignKey(d => d.IdHocVien)
                .HasConstraintName("FK_tbKyLuatNguoiHoc_tbHocVien");

            entity.HasOne(d => d.IdLoaiKyLuatNavigation).WithMany(p => p.TbKyLuatNguoiHocs)
                .HasForeignKey(d => d.IdLoaiKyLuat)
                .HasConstraintName("FK_tbKyLuatNguoiHoc_dmLoaiKyLuat");
        });

        modelBuilder.Entity<TbLichSuDoiTenTruong>(entity =>
        {
            entity.HasKey(e => e.IdLichSuDoiTenTruong);

            entity.ToTable("tbLichSuDoiTenTruong", "CSGD");

            entity.Property(e => e.IdLichSuDoiTenTruong).ValueGeneratedNever();
            entity.Property(e => e.SoQuyetDinhDoiTen).HasMaxLength(200);
            entity.Property(e => e.TenTruongCu).HasMaxLength(200);
            entity.Property(e => e.TenTruongCuTiengAnh).HasMaxLength(200);
        });

        modelBuilder.Entity<TbLinhVucNghienCuuCuaCanBo>(entity =>
        {
            entity.HasKey(e => e.IdLinhVucNghienCuuCuaCanBo);

            entity.ToTable("tbLinhVucNghienCuuCuaCanBo", "CB");

            entity.Property(e => e.IdLinhVucNghienCuuCuaCanBo).ValueGeneratedNever();

            entity.HasOne(d => d.IdCanBoNavigation).WithMany(p => p.TbLinhVucNghienCuuCuaCanBos)
                .HasForeignKey(d => d.IdCanBo)
                .HasConstraintName("FK_tbLinhVucNghienCuuCuaCanBo_tbCanBo");

            entity.HasOne(d => d.IdLinhVucNghienCuuNavigation).WithMany(p => p.TbLinhVucNghienCuuCuaCanBos)
                .HasForeignKey(d => d.IdLinhVucNghienCuu)
                .HasConstraintName("FK_tbLinhVucNghienCuuCuaCanBo_dmLinhVucNghienCuu");
        });

        modelBuilder.Entity<TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh>(entity =>
        {
            entity.HasKey(e => e.IdLoaiHinhDaoTaoKhacDuocChoPhepMoNganh);

            entity.ToTable("tbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh", "NDT");

            entity.Property(e => e.IdLoaiHinhDaoTaoKhacDuocChoPhepMoNganh).ValueGeneratedNever();
            entity.Property(e => e.SoQuyetDinhChoPhep).HasMaxLength(50);

            entity.HasOne(d => d.IdLoaiHinhDaoTaoNavigation).WithMany(p => p.TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganhs)
                .HasForeignKey(d => d.IdLoaiHinhDaoTao)
                .HasConstraintName("FK_tbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh_dmLoaiHinhDaoTao");

            entity.HasOne(d => d.IdNganhDaoTaoNavigation).WithMany(p => p.TbLoaiHinhDaoTaoKhacDuocChoPhepMoNganhs)
                .HasForeignKey(d => d.IdNganhDaoTao)
                .HasConstraintName("FK_tbLoaiHinhDaoTaoKhacDuocChoPhepMoNganh_dmNganhDaoTao");
        });

        modelBuilder.Entity<TbLoaiThuChi>(entity =>
        {
            entity.HasKey(e => e.IdLoaiThuChi);

            entity.ToTable("tbLoaiThuChi", "TCTS");

            entity.Property(e => e.IdLoaiThuChi).ValueGeneratedNever();
            entity.Property(e => e.MaLoaiThuChi).HasMaxLength(50);
            entity.Property(e => e.MoTa).HasColumnType("ntext");
            entity.Property(e => e.TenLoaiThuChi).HasMaxLength(200);

            entity.HasOne(d => d.IdPhanLoaiThuChiNavigation).WithMany(p => p.TbLoaiThuChis)
                .HasForeignKey(d => d.IdPhanLoaiThuChi)
                .HasConstraintName("FK_tbLoaiThuChi_dmPhanLoaiThuChi");
        });

        modelBuilder.Entity<TbLuuHocSinhSinhVienNn>(entity =>
        {
            entity.HasKey(e => e.IdLuuHocSinhSinhVienNn);

            entity.ToTable("tbLuuHocSinhSinhVienNN", "HTQT");

            entity.Property(e => e.IdLuuHocSinhSinhVienNn)
                .ValueGeneratedNever()
                .HasColumnName("IdLuuHocSinhSinhVienNN");

            entity.HasOne(d => d.IdLoaiLuuHocSinhNavigation).WithMany(p => p.TbLuuHocSinhSinhVienNns)
                .HasForeignKey(d => d.IdLoaiLuuHocSinh)
                .HasConstraintName("FK_tbLuuHocSinhSinhVienNN_dmLoaiLuuHocSinh");

            entity.HasOne(d => d.IdNguonKinhPhiLuuHocSinhNavigation).WithMany(p => p.TbLuuHocSinhSinhVienNns)
                .HasForeignKey(d => d.IdNguonKinhPhiLuuHocSinh)
                .HasConstraintName("FK_tbLuuHocSinhSinhVienNN_dmNguonKinhPhiChoLuuHocSinh");
        });

        modelBuilder.Entity<TbNamApDungChuongTrinh>(entity =>
        {
            entity.HasKey(e => e.IdNamApDungChuongTrinh);

            entity.ToTable("tbNamApDungChuongTrinh", "CTDT");

            entity.Property(e => e.IdNamApDungChuongTrinh).ValueGeneratedNever();

            entity.HasOne(d => d.IdChuongTrinhDaoTaoNavigation).WithMany(p => p.TbNamApDungChuongTrinhs)
                .HasForeignKey(d => d.IdChuongTrinhDaoTao)
                .HasConstraintName("FK_tbNamApDungChuongTrinh_tbNamApDungChuongTrinh");
        });

        modelBuilder.Entity<TbNganhDungTenGiangDay>(entity =>
        {
            entity.HasKey(e => e.IdNganhDungTenGiangDay);

            entity.ToTable("tbNganhDungTenGiangDay", "CB");

            entity.Property(e => e.IdNganhDungTenGiangDay).ValueGeneratedNever();

            entity.HasOne(d => d.IdCanBoNavigation).WithMany(p => p.TbNganhDungTenGiangDays)
                .HasForeignKey(d => d.IdCanBo)
                .HasConstraintName("FK_tbNganhDungTenGiangDay_tbCanBo");

            entity.HasOne(d => d.IdNganhDaoTaoNavigation).WithMany(p => p.TbNganhDungTenGiangDays)
                .HasForeignKey(d => d.IdNganhDaoTao)
                .HasConstraintName("FK_tbNganhDungTenGiangDay_dmNganhDaoTao");
        });

        modelBuilder.Entity<TbNganhGiangDayCuaCanBo>(entity =>
        {
            entity.HasKey(e => e.IdNganhGiangDayCuaCanBo);

            entity.ToTable("tbNganhGiangDayCuaCanBo", "CB");

            entity.Property(e => e.IdNganhGiangDayCuaCanBo).ValueGeneratedNever();
            entity.Property(e => e.DonViThinhGiang).HasMaxLength(200);

            entity.HasOne(d => d.IdCanBoNavigation).WithMany(p => p.TbNganhGiangDayCuaCanBos)
                .HasForeignKey(d => d.IdCanBo)
                .HasConstraintName("FK_tbNganhGiangDayCuaCanBo_tbCanBo");

            entity.HasOne(d => d.IdNganhNavigation).WithMany(p => p.TbNganhGiangDayCuaCanBos)
                .HasForeignKey(d => d.IdNganh)
                .HasConstraintName("FK_tbNganhGiangDayCuaCanBo_dmNganhDaoTao");

            entity.HasOne(d => d.IdTrinhDoDaoTaoNavigation).WithMany(p => p.TbNganhGiangDayCuaCanBos)
                .HasForeignKey(d => d.IdTrinhDoDaoTao)
                .HasConstraintName("FK_tbNganhGiangDayCuaCanBo_dmTrinhDoDaoTao");
        });

        modelBuilder.Entity<TbNgonNguGiangDay>(entity =>
        {
            entity.HasKey(e => e.IdNgonNguGiangDay);

            entity.ToTable("tbNgonNguGiangDay", "CTDT");

            entity.Property(e => e.IdNgonNguGiangDay).ValueGeneratedNever();

            entity.HasOne(d => d.IdChuongTrinhDaoTaoNavigation).WithMany(p => p.TbNgonNguGiangDays)
                .HasForeignKey(d => d.IdChuongTrinhDaoTao)
                .HasConstraintName("FK_tbNgonNguGiangDay_tbChuongTrinhDaoTao");

            entity.HasOne(d => d.IdNgonNguNavigation).WithMany(p => p.TbNgonNguGiangDays)
                .HasForeignKey(d => d.IdNgonNgu)
                .HasConstraintName("FK_tbNgonNguGiangDay_dmNgoaiNgu");

            entity.HasOne(d => d.IdTrinhDoNgonNguDauVaoNavigation).WithMany(p => p.TbNgonNguGiangDays)
                .HasForeignKey(d => d.IdTrinhDoNgonNguDauVao)
                .HasConstraintName("FK_tbNgonNguGiangDay_dmKhungNangLucNgoaiNgu");
        });

        modelBuilder.Entity<TbNguoi>(entity =>
        {
            entity.HasKey(e => e.IdNguoi);

            entity.ToTable("tbNguoi");

            entity.Property(e => e.IdNguoi).ValueGeneratedNever();
            entity.Property(e => e.Ho).HasMaxLength(50);
            entity.Property(e => e.NgayCapCccd).HasColumnName("NgayCapCCCD");
            entity.Property(e => e.NoiCapCccd)
                .HasMaxLength(50)
                .HasColumnName("NoiCapCCCD");
            entity.Property(e => e.SoCccd)
                .HasMaxLength(50)
                .HasColumnName("SoCCCD");
            entity.Property(e => e.Ten).HasMaxLength(50);

            entity.HasOne(d => d.IdChucDanhKhoaHocNavigation).WithMany(p => p.TbNguois)
                .HasForeignKey(d => d.IdChucDanhKhoaHoc)
                .HasConstraintName("FK_tbNguoi_dmChucDanhKhoaHoc");

            entity.HasOne(d => d.IdChuyenMonDaoTaoNavigation).WithMany(p => p.TbNguois)
                .HasForeignKey(d => d.IdChuyenMonDaoTao)
                .HasConstraintName("FK_tbNguoi_dmNganhDaoTao");

            entity.HasOne(d => d.IdDanTocNavigation).WithMany(p => p.TbNguois)
                .HasForeignKey(d => d.IdDanToc)
                .HasConstraintName("FK_tbNguoi_dmDanToc");

            entity.HasOne(d => d.IdTonGiaoNavigation).WithMany(p => p.TbNguois)
                .HasForeignKey(d => d.IdTonGiao)
                .HasConstraintName("FK_tbNguoi_dmTonGiao");

            entity.HasOne(d => d.IdGiaDinhChinhSachNavigation).WithMany(p => p.TbNguois)
                .HasForeignKey(d => d.IdGiaDinhChinhSach)
                .HasConstraintName("FK_tbNguoi_dmHoGiaDinhChinhSach");

            entity.HasOne(d => d.IdGioiTinhNavigation).WithMany(p => p.TbNguois)
                .HasForeignKey(d => d.IdGioiTinh)
                .HasConstraintName("FK_tbNguoi_dmGioiTinh");

            entity.HasOne(d => d.IdKhungNangLucNgoaiNgucNavigation).WithMany(p => p.TbNguois)
                .HasForeignKey(d => d.IdKhungNangLucNgoaiNguc)
                .HasConstraintName("FK_tbNguoi_dmKhungNangLucNgoaiNgu");

            entity.HasOne(d => d.IdNgoaiNguNavigation).WithMany(p => p.TbNguois)
                .HasForeignKey(d => d.IdNgoaiNgu)
                .HasConstraintName("FK_tbNguoi_dmNgoaiNgu");

            entity.HasOne(d => d.IdQuocTichNavigation).WithMany(p => p.TbNguois)
                .HasForeignKey(d => d.IdQuocTich)
                .HasConstraintName("FK_tbNguoi_dmQuocTich");

            entity.HasOne(d => d.IdThuongBinhHangNavigation).WithMany(p => p.TbNguois)
                .HasForeignKey(d => d.IdThuongBinhHang)
                .HasConstraintName("FK_tbNguoi_dmHangThuongBinh");

            entity.HasOne(d => d.IdTrinhDoDaoTaoNavigation).WithMany(p => p.TbNguois)
                .HasForeignKey(d => d.IdTrinhDoDaoTao)
                .HasConstraintName("FK_tbNguoi_dmTrinhDoDaoTao");

            entity.HasOne(d => d.IdTrinhDoLyLuanChinhTriNavigation).WithMany(p => p.TbNguois)
                .HasForeignKey(d => d.IdTrinhDoLyLuanChinhTri)
                .HasConstraintName("FK_tbNguoi_dmTrinhDoLyLuanChinhTri");

            entity.HasOne(d => d.IdTrinhDoQuanLyNhaNuocNavigation).WithMany(p => p.TbNguois)
                .HasForeignKey(d => d.IdTrinhDoQuanLyNhaNuoc)
                .HasConstraintName("FK_tbNguoi_dmTrinhDoQuanLyNhaNuoc");

            entity.HasOne(d => d.IdTrinhDoTinHocNavigation).WithMany(p => p.TbNguois)
                .HasForeignKey(d => d.IdTrinhDoTinHoc)
                .HasConstraintName("FK_tbNguoi_dmTrinhDoTinHoc");
        });

        modelBuilder.Entity<TbNguoiHocVayTinDung>(entity =>
        {
            entity.HasKey(e => e.IdNguoiHocVayTinDung);

            entity.ToTable("tbNguoiHocVayTinDung", "NH");

            entity.Property(e => e.IdNguoiHocVayTinDung).ValueGeneratedNever();
            entity.Property(e => e.DiaChi).HasColumnType("text");
            entity.Property(e => e.TenToChucTinDung).HasColumnType("text");

            entity.HasOne(d => d.IdHocVienNavigation).WithMany(p => p.TbNguoiHocVayTinDungs)
                .HasForeignKey(d => d.IdHocVien)
                .HasConstraintName("FK_tbNguoiHocVayTinDung_tbHocVien");

            entity.HasOne(d => d.TinhTrangVayNavigation).WithMany(p => p.TbNguoiHocVayTinDungs)
                .HasForeignKey(d => d.TinhTrangVay)
                .HasConstraintName("FK_tbNguoiHocVayTinDung_dmTuyChon");
        });

        modelBuilder.Entity<TbNhiemVuKhcn>(entity =>
        {
            entity.HasKey(e => e.IdNhiemVuKhcn);

            entity.ToTable("tbNhiemVuKHCN", "KHCN");

            entity.Property(e => e.IdNhiemVuKhcn)
                .ValueGeneratedNever()
                .HasColumnName("IdNhiemVuKHCN");
            entity.Property(e => e.CoQuanChuTri).HasMaxLength(200);
            entity.Property(e => e.DanhGiaKetQuaNhiemVu).HasMaxLength(200);
            entity.Property(e => e.MaNhiemVu).HasMaxLength(50);
            entity.Property(e => e.NguoiChuTri).HasMaxLength(200);
            entity.Property(e => e.SanPhamChinhCuaNhiemVu).HasMaxLength(200);
            entity.Property(e => e.TenNhiemVu).HasMaxLength(300);
            entity.Property(e => e.TongKinhPhiCuaNhiemVu).HasColumnType("text");

            entity.HasOne(d => d.IdCapQuanLyNhiemVuNavigation).WithMany(p => p.TbNhiemVuKhcns)
                .HasForeignKey(d => d.IdCapQuanLyNhiemVu)
                .HasConstraintName("FK_tbNhiemVuKHCN_dmPhanCapNhiemVu");

            entity.HasOne(d => d.IdCoQuanChuQuanNavigation).WithMany(p => p.TbNhiemVuKhcns)
                .HasForeignKey(d => d.IdCoQuanChuQuan)
                .HasConstraintName("FK_tbNhiemVuKHCN_dmCoQuanChuQuan");

            entity.HasOne(d => d.IdLinhVucNghienCuuNavigation).WithMany(p => p.TbNhiemVuKhcns)
                .HasForeignKey(d => d.IdLinhVucNghienCuu)
                .HasConstraintName("FK_tbNhiemVuKHCN_dmLinhVucNghienCuu");

            entity.HasOne(d => d.IdNguonKinhPhiNavigation).WithMany(p => p.TbNhiemVuKhcns)
                .HasForeignKey(d => d.IdNguonKinhPhi)
                .HasConstraintName("FK_tbNhiemVuKHCN_dmNguonKinhPhi");

            entity.HasOne(d => d.IdPhanLoaiNhiemVuNavigation).WithMany(p => p.TbNhiemVuKhcns)
                .HasForeignKey(d => d.IdPhanLoaiNhiemVu)
                .HasConstraintName("FK_tbNhiemVuKHCN_dmLoaiNhiemVu");

            entity.HasOne(d => d.IdTinhTrangNhiemVuNavigation).WithMany(p => p.TbNhiemVuKhcns)
                .HasForeignKey(d => d.IdTinhTrangNhiemVu)
                .HasConstraintName("FK_tbNhiemVuKHCN_dmTinhTrangNhiemVu");
        });

        modelBuilder.Entity<TbNhomNganhDaoTao>(entity =>
        {
            entity.HasKey(e => e.IdNhomNganhDaoTao).HasName("PK_dmLinhVucNganhDaoTaoNhomNganh");

            entity.ToTable("tbNhomNganhDaoTao", "NDT");

            entity.Property(e => e.IdNhomNganhDaoTao).ValueGeneratedNever();

            entity.HasOne(d => d.IdLinhVucDaoTaoNavigation).WithMany(p => p.TbNhomNganhDaoTaos)
                .HasForeignKey(d => d.IdLinhVucDaoTao)
                .HasConstraintName("FK_dmLinhVucNganhDaoTaoNhomNganh_dmLinhVucDaoTao");

            entity.HasOne(d => d.IdNganhDaoTaoNavigation).WithMany(p => p.TbNhomNganhDaoTaos)
                .HasForeignKey(d => d.IdNganhDaoTao)
                .HasConstraintName("FK_dmLinhVucNganhDaoTaoNhomNganh_dmNganhDaoTao");

            entity.HasOne(d => d.IdNhomNganhNavigation).WithMany(p => p.TbNhomNganhDaoTaos)
                .HasForeignKey(d => d.IdNhomNganh)
                .HasConstraintName("FK_dmLinhVucNganhDaoTaoNhomNganh_dmNhomNganh");
        });

        modelBuilder.Entity<TbNhomNghienCuuManh>(entity =>
        {
            entity.HasKey(e => e.IdNhomNghienCuuManh);

            entity.ToTable("tbNhomNghienCuuManh", "KHCN");

            entity.Property(e => e.IdNhomNghienCuuManh).ValueGeneratedNever();
            entity.Property(e => e.CacNhiemVuNckh)
                .HasMaxLength(50)
                .HasColumnName("CacNhiemVuNCKH");
            entity.Property(e => e.MaNhomNghienCuuManh).HasMaxLength(50);
            entity.Property(e => e.SoQuyetDinhThanhLap).HasMaxLength(50);
            entity.Property(e => e.TenNhomNghienCuuManh).HasMaxLength(300);
            entity.Property(e => e.ToChucBanHanhQuyetDinh).HasMaxLength(50);
        });

        modelBuilder.Entity<TbPhongHocGiangDuongHoiTruong>(entity =>
        {
            entity.HasKey(e => e.IdPhongHocGiangDuongHoiTruong);

            entity.ToTable("tbPhongHocGiangDuongHoiTruong", "CSVC");

            entity.Property(e => e.IdPhongHocGiangDuongHoiTruong).ValueGeneratedNever();
            entity.Property(e => e.IdPhanLoaiCsvc).HasColumnName("IdPhanLoaiCSVC");
            entity.Property(e => e.MaPhongHocGiangDuongHoiTruong).HasMaxLength(50);
            entity.Property(e => e.NamDuaVaoSuDung).HasColumnType("text");
            entity.Property(e => e.TenPhongHocGiangDuongHoiTruong)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.IdHinhThucSoHuuNavigation).WithMany(p => p.TbPhongHocGiangDuongHoiTruongs)
                .HasForeignKey(d => d.IdHinhThucSoHuu)
                .HasConstraintName("FK_tbPhongHocGiangDuongHoiTruong_dmHinhThucSoHuu");

            entity.HasOne(d => d.IdLoaiDeAnNavigation).WithMany(p => p.TbPhongHocGiangDuongHoiTruongs)
                .HasForeignKey(d => d.IdLoaiDeAn)
                .HasConstraintName("FK_tbPhongHocGiangDuongHoiTruong_dmLoaiDeAnChuongTrinh");

            entity.HasOne(d => d.IdLoaiPhongHocNavigation).WithMany(p => p.TbPhongHocGiangDuongHoiTruongs)
                .HasForeignKey(d => d.IdLoaiPhongHoc)
                .HasConstraintName("FK_tbPhongHocGiangDuongHoiTruong_dmLoaiPhongHoc");

            entity.HasOne(d => d.IdPhanLoaiCsvcNavigation).WithMany(p => p.TbPhongHocGiangDuongHoiTruongs)
                .HasForeignKey(d => d.IdPhanLoaiCsvc)
                .HasConstraintName("FK_tbPhongHocGiangDuongHoiTruong_dmPhanLoaiCSVC");

            entity.HasOne(d => d.IdTinhTrangCoSoVatChatNavigation).WithMany(p => p.TbPhongHocGiangDuongHoiTruongs)
                .HasForeignKey(d => d.IdTinhTrangCoSoVatChat)
                .HasConstraintName("FK_tbPhongHocGiangDuongHoiTruong_dmTinhTrangCoSoVatChat");
        });

        modelBuilder.Entity<TbPhongThiNghiem>(entity =>
        {
            entity.HasKey(e => e.IdPhongThiNghiem);

            entity.ToTable("tbPhongThiNghiem", "CSVC");

            entity.Property(e => e.IdPhongThiNghiem).ValueGeneratedNever();
            entity.Property(e => e.IdCongTrinhCsvc).HasColumnName("IdCongTrinhCSVC");
            entity.Property(e => e.MucDoDapUngNhuCauNckh)
                .HasMaxLength(200)
                .HasColumnName("MucDoDapUngNhuCauNCKH");
            entity.Property(e => e.NamDuaVaoSuDung).HasColumnType("text");

            entity.HasOne(d => d.IdCongTrinhCsvcNavigation).WithMany(p => p.TbPhongThiNghiems)
                .HasForeignKey(d => d.IdCongTrinhCsvc)
                .HasConstraintName("FK_tbPhongThiNghiem_tbCongTrinhCoSoVatChat");

            entity.HasOne(d => d.IdLinhVucNavigation).WithMany(p => p.TbPhongThiNghiems)
                .HasForeignKey(d => d.IdLinhVuc)
                .HasConstraintName("FK_tbPhongThiNghiem_dmLinhVucNghienCuu");

            entity.HasOne(d => d.IdLoaiPhongThiNghiemNavigation).WithMany(p => p.TbPhongThiNghiems)
                .HasForeignKey(d => d.IdLoaiPhongThiNghiem)
                .HasConstraintName("FK_tbPhongThiNghiem_dmLoaiPhongThiNghiem");
        });

        modelBuilder.Entity<TbPhongThucHanh>(entity =>
        {
            entity.HasKey(e => e.IdPhongThucHanh);

            entity.ToTable("tbPhongThucHanh", "CSVC");

            entity.Property(e => e.IdPhongThucHanh).ValueGeneratedNever();
            entity.Property(e => e.IdCongTrinhCsvc).HasColumnName("IdCongTrinhCSVC");
            entity.Property(e => e.MucDoDapUngNhuCauNckh)
                .HasMaxLength(200)
                .HasColumnName("MucDoDapUngNhuCauNCKH");
            entity.Property(e => e.NamDuaVaoSuDung).HasColumnType("text");

            entity.HasOne(d => d.IdCongTrinhCsvcNavigation).WithMany(p => p.TbPhongThucHanhs)
                .HasForeignKey(d => d.IdCongTrinhCsvc)
                .HasConstraintName("FK_tbPhongThucHanh_tbCongTrinhCoSoVatChat");

            entity.HasOne(d => d.IdLinhVucNavigation).WithMany(p => p.TbPhongThucHanhs)
                .HasForeignKey(d => d.IdLinhVuc)
                .HasConstraintName("FK_tbPhongThucHanh_dmLinhVucNghienCuu");
        });

        modelBuilder.Entity<TbPhuCap>(entity =>
        {
            entity.HasKey(e => e.IdPhuCap);

            entity.ToTable("tbPhuCap", "CB");

            entity.Property(e => e.IdPhuCap).ValueGeneratedNever();

            entity.HasOne(d => d.IdBacLuongNavigation).WithMany(p => p.TbPhuCaps)
                .HasForeignKey(d => d.IdBacLuong)
                .HasConstraintName("FK_tbPhuCap_dmBacLuong");

            entity.HasOne(d => d.IdCanBoNavigation).WithMany(p => p.TbPhuCaps)
                .HasForeignKey(d => d.IdCanBo)
                .HasConstraintName("FK_tbPhuCap_tbCanBo");

            entity.HasOne(d => d.IdHeSoLuongNavigation).WithMany(p => p.TbPhuCaps)
                .HasForeignKey(d => d.IdHeSoLuong)
                .HasConstraintName("FK_tbPhuCap_dmHeSoLuong");
        });

        modelBuilder.Entity<TbQuaTrinhCongTacCuaCanBo>(entity =>
        {
            entity.HasKey(e => e.IdQuaTrinhCongTacCuaCanBo);

            entity.ToTable("tbQuaTrinhCongTacCuaCanBo", "CB");

            entity.Property(e => e.IdQuaTrinhCongTacCuaCanBo).ValueGeneratedNever();
            entity.Property(e => e.DonViCongTac).HasMaxLength(200);

            entity.HasOne(d => d.IdCanBoNavigation).WithMany(p => p.TbQuaTrinhCongTacCuaCanBos)
                .HasForeignKey(d => d.IdCanBo)
                .HasConstraintName("FK_tbQuaTrinhCongTacCuaCanBo_tbCanBo");

            entity.HasOne(d => d.IdChucDanhGiangVienNavigation).WithMany(p => p.TbQuaTrinhCongTacCuaCanBos)
                .HasForeignKey(d => d.IdChucDanhGiangVien)
                .HasConstraintName("FK_tbQuaTrinhCongTacCuaCanBo_dmChucDanhGiangVien");

            entity.HasOne(d => d.IdChucVuNavigation).WithMany(p => p.TbQuaTrinhCongTacCuaCanBos)
                .HasForeignKey(d => d.IdChucVu)
                .HasConstraintName("FK_tbQuaTrinhCongTacCuaCanBo_dmChucVu");
        });

        modelBuilder.Entity<TbQuaTrinhDaoTaoCuaCanBo>(entity =>
        {
            entity.HasKey(e => e.IdQuaTrinhDaoTaoCuaCanBo);

            entity.ToTable("tbQuaTrinhDaoTaoCuaCanBo", "CB");

            entity.Property(e => e.IdQuaTrinhDaoTaoCuaCanBo).ValueGeneratedNever();
            entity.Property(e => e.CoSoDaoTao).HasMaxLength(200);

            entity.HasOne(d => d.IdCanBoNavigation).WithMany(p => p.TbQuaTrinhDaoTaoCuaCanBos)
                .HasForeignKey(d => d.IdCanBo)
                .HasConstraintName("FK_tbQuaTrinhDaoTaoCuaCanBo_tbCanBo");

            entity.HasOne(d => d.IdLoaiHinhDaoTaoNavigation).WithMany(p => p.TbQuaTrinhDaoTaoCuaCanBos)
                .HasForeignKey(d => d.IdLoaiHinhDaoTao)
                .HasConstraintName("FK_tbQuaTrinhDaoTaoCuaCanBo_dmLoaiHinhDaoTao");

            entity.HasOne(d => d.IdNganhDaoTaoNavigation).WithMany(p => p.TbQuaTrinhDaoTaoCuaCanBos)
                .HasForeignKey(d => d.IdNganhDaoTao)
                .HasConstraintName("FK_tbQuaTrinhDaoTaoCuaCanBo_dmNganhDaoTao");

            entity.HasOne(d => d.IdQuocGiaDaoTaoNavigation).WithMany(p => p.TbQuaTrinhDaoTaoCuaCanBos)
                .HasForeignKey(d => d.IdQuocGiaDaoTao)
                .HasConstraintName("FK_tbQuaTrinhDaoTaoCuaCanBo_dmQuocTich");

            entity.HasOne(d => d.IdTrinhDoDaoTaoNavigation).WithMany(p => p.TbQuaTrinhDaoTaoCuaCanBos)
                .HasForeignKey(d => d.IdTrinhDoDaoTao)
                .HasConstraintName("FK_tbQuaTrinhDaoTaoCuaCanBo_dmTrinhDoDaoTao");
        });

        modelBuilder.Entity<TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai>(entity =>
        {
            entity.HasKey(e => e.IdQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai);

            entity.ToTable("tbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai", "CTDT");

            entity.Property(e => e.IdQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai).ValueGeneratedNever();
            entity.Property(e => e.SoQuyetDinh).HasMaxLength(200);

            entity.HasOne(d => d.IdChuongTrinhDaoTaoNavigation).WithMany(p => p.TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoais)
                .HasForeignKey(d => d.IdChuongTrinhDaoTao)
                .HasConstraintName("FK_tbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai_tbChuongTrinhDaoTao");

            entity.HasOne(d => d.IdHinhThucDaoTaoNavigation).WithMany(p => p.TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoais)
                .HasForeignKey(d => d.IdHinhThucDaoTao)
                .HasConstraintName("FK_tbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai_dmHinhThucDaoTao");

            entity.HasOne(d => d.IdLoaiQuyetDinhNavigation).WithMany(p => p.TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoais)
                .HasForeignKey(d => d.IdLoaiQuyetDinh)
                .HasConstraintName("FK_tbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai_dmLoaiQuyetDinh");
        });

        modelBuilder.Entity<TbSachDaXuatBan>(entity =>
        {
            entity.HasKey(e => e.IdSachDaXuatBan);

            entity.ToTable("tbSachDaXuatBan", "KHCN");

            entity.Property(e => e.IdSachDaXuatBan).ValueGeneratedNever();
            entity.Property(e => e.IdNhiemVuKhcn).HasColumnName("IdNhiemVuKHCN");
            entity.Property(e => e.MaChuanIsbn)
                .HasMaxLength(50)
                .HasColumnName("MaChuanISBN");
            entity.Property(e => e.MaSach).HasMaxLength(50);
            entity.Property(e => e.NamViet).HasColumnType("text");
            entity.Property(e => e.NamXuatBan).HasColumnType("text");
            entity.Property(e => e.Nxb)
                .HasMaxLength(50)
                .HasColumnName("NXB");
            entity.Property(e => e.TenSach).HasMaxLength(300);

            entity.HasOne(d => d.IdDangTaiLieuNavigation).WithMany(p => p.TbSachDaXuatBans)
                .HasForeignKey(d => d.IdDangTaiLieu)
                .HasConstraintName("FK_tbSachDaXuatBan_dmDangTaiLieu");

            entity.HasOne(d => d.IdLoaiSachTapChiNavigation).WithMany(p => p.TbSachDaXuatBans)
                .HasForeignKey(d => d.IdLoaiSachTapChi)
                .HasConstraintName("FK_tbSachDaXuatBan_dmLoaiSachTapChi");

            entity.HasOne(d => d.IdNhiemVuKhcnNavigation).WithMany(p => p.TbSachDaXuatBans)
                .HasForeignKey(d => d.IdNhiemVuKhcn)
                .HasConstraintName("FK_tbSachDaXuatBan_tbNhiemVuKHCN");
        });

        modelBuilder.Entity<TbTaiSanDonVi>(entity =>
        {
            entity.HasKey(e => e.IdTaiSanDonVi);

            entity.ToTable("tbTaiSanDonVi", "TCTS");

            entity.Property(e => e.IdTaiSanDonVi).ValueGeneratedNever();
            entity.Property(e => e.MaLoaiTaiSan).HasMaxLength(50);
            entity.Property(e => e.MoTa).HasColumnType("text");
            entity.Property(e => e.NamTaiChinh).HasColumnType("text");
            entity.Property(e => e.TenLoaiTaiSan).HasMaxLength(200);
        });

        modelBuilder.Entity<TbTaiSanTriTue>(entity =>
        {
            entity.HasKey(e => e.IdTaiSanTriTue);

            entity.ToTable("tbTaiSanTriTue", "KHCN");

            entity.Property(e => e.IdTaiSanTriTue).ValueGeneratedNever();
            entity.Property(e => e.ChuSoHuu).HasMaxLength(50);
            entity.Property(e => e.CongBoBang).HasMaxLength(50);
            entity.Property(e => e.IdNhiemVuKhcn).HasColumnName("IdNhiemVuKHCN");
            entity.Property(e => e.Ipc)
                .HasMaxLength(50)
                .HasColumnName("IPC");
            entity.Property(e => e.MaGiaiPhapSangChe).HasMaxLength(50);
            entity.Property(e => e.NamDuocChapNhanDonHopLe).HasColumnType("text");
            entity.Property(e => e.NguoiChuTri).HasMaxLength(50);
            entity.Property(e => e.QuyetDinhCapBangGiayChungNhan).HasMaxLength(200);
            entity.Property(e => e.TacGiaSangCheGiaiPhap).HasMaxLength(50);
            entity.Property(e => e.TenTaiSanTriTue).HasMaxLength(300);
            entity.Property(e => e.ToChucCapBang).HasMaxLength(200);
            entity.Property(e => e.ToChucCapBangGiayChungNhan).HasMaxLength(200);

            entity.HasOne(d => d.IdLoaiTaiSanTriTueNavigation).WithMany(p => p.TbTaiSanTriTues)
                .HasForeignKey(d => d.IdLoaiTaiSanTriTue)
                .HasConstraintName("FK_tbTaiSanTriTue_dmLoaiTaiSanTriTue");

            entity.HasOne(d => d.IdNhiemVuKhcnNavigation).WithMany(p => p.TbTaiSanTriTues)
                .HasForeignKey(d => d.IdNhiemVuKhcn)
                .HasConstraintName("FK_tbTaiSanTriTue_tbNhiemVuKHCN");
        });

        modelBuilder.Entity<TbTapChiKhoaHoc>(entity =>
        {
            entity.HasKey(e => e.IdTapChiKhoaHoc);

            entity.ToTable("tbTapChiKhoaHoc", "KHCN");

            entity.Property(e => e.IdTapChiKhoaHoc).ValueGeneratedNever();
            entity.Property(e => e.MaChuanIssn)
                .HasMaxLength(50)
                .HasColumnName("MaChuanISSN");
            entity.Property(e => e.MaTapChi).HasMaxLength(50);
            entity.Property(e => e.TenTapChiTiengAnh).HasMaxLength(300);
            entity.Property(e => e.TenTapChiTiengViet).HasMaxLength(300);

            entity.HasOne(d => d.IdLinhVucXuatBanNavigation).WithMany(p => p.TbTapChiKhoaHocs)
                .HasForeignKey(d => d.IdLinhVucXuatBan)
                .HasConstraintName("FK_tbTapChiKhoaHoc_dmLinhVucNghienCuu");

            entity.HasOne(d => d.IdXepLoaiTapChiNavigation).WithMany(p => p.TbTapChiKhoaHocs)
                .HasForeignKey(d => d.IdXepLoaiTapChi)
                .HasConstraintName("FK_tbTapChiKhoaHoc_dmTapChiTrongNuoc");
        });

        modelBuilder.Entity<TbThanhPhanThamGiaDoanCongTac>(entity =>
        {
            entity.HasKey(e => e.IdThanhPhanThamGiaDoanCongTac);

            entity.ToTable("tbThanhPhanThamGiaDoanCongTac", "HTQT");

            entity.Property(e => e.IdThanhPhanThamGiaDoanCongTac).ValueGeneratedNever();

            entity.HasOne(d => d.IdCanBoNavigation).WithMany(p => p.TbThanhPhanThamGiaDoanCongTacs)
                .HasForeignKey(d => d.IdCanBo)
                .HasConstraintName("FK_tbThanhPhanThamGiaDoanCongTac_tbCanBo");

            entity.HasOne(d => d.IdDoanCongTacNavigation).WithMany(p => p.TbThanhPhanThamGiaDoanCongTacs)
                .HasForeignKey(d => d.IdDoanCongTac)
                .HasConstraintName("FK_tbThanhPhanThamGiaDoanCongTac_tbDoanCongTac");

            entity.HasOne(d => d.IdVaiTroThamGiaNavigation).WithMany(p => p.TbThanhPhanThamGiaDoanCongTacs)
                .HasForeignKey(d => d.IdVaiTroThamGia)
                .HasConstraintName("FK_tbThanhPhanThamGiaDoanCongTac_dmVaiTroThamGia");
        });

        modelBuilder.Entity<TbThietBiPtnThtren500Tr>(entity =>
        {
            entity.HasKey(e => e.IdThietBiPtnTh);

            entity.ToTable("tbThietBiPTN_THTren500Tr", "CSVC");

            entity.Property(e => e.IdThietBiPtnTh)
                .ValueGeneratedNever()
                .HasColumnName("IdThietBiPTN_TH");
            entity.Property(e => e.HangSanXuat).HasMaxLength(200);
            entity.Property(e => e.IdCongTrinhCsvc).HasColumnName("IdCongTrinhCSVC");
            entity.Property(e => e.MaThietBi).HasMaxLength(50);
            entity.Property(e => e.NamDuaVaoSuDung).HasColumnType("text");
            entity.Property(e => e.NamSanXuat).HasColumnType("text");
            entity.Property(e => e.TenThietBi).HasMaxLength(200);

            entity.HasOne(d => d.IdCongTrinhCsvcNavigation).WithMany(p => p.TbThietBiPtnThtren500Trs)
                .HasForeignKey(d => d.IdCongTrinhCsvc)
                .HasConstraintName("FK_tbThietBiPTN_THTren500Tr_tbCongTrinhCoSoVatChat");

            entity.HasOne(d => d.IdQuocGiaXuatXuNavigation).WithMany(p => p.TbThietBiPtnThtren500Trs)
                .HasForeignKey(d => d.IdQuocGiaXuatXu)
                .HasConstraintName("FK_tbThietBiPTN_THTren500Tr_dmQuocTich");
        });

        modelBuilder.Entity<TbThoaThuanHopTacQuocTe>(entity =>
        {
            entity.HasKey(e => e.IdThoaThuanHopTacQuocTe);
            entity.ToTable("tbThoaThuanHopTacQuocTe", "HTQT");

            entity.Property(e => e.IdThoaThuanHopTacQuocTe).ValueGeneratedNever();
            entity.Property(e => e.MaThoaThuan).HasMaxLength(50);
            entity.Property(e => e.SoVanBanKyKet).HasMaxLength(50);
            entity.Property(e => e.TenThoaThuan).HasMaxLength(200);
            entity.Property(e => e.TenToChuc).HasMaxLength(200);

            entity.HasOne(d => d.IdQuocGiaNavigation).WithMany()
                .HasForeignKey(d => d.IdQuocGia)
                .HasConstraintName("FK_tbThoaThuanHopTacQuocTe_dmQuocTich");
        });

        modelBuilder.Entity<TbThongTinHocBong>(entity =>
        {
            entity.HasKey(e => e.IdThongTinHocBong);

            entity.ToTable("tbThongTinHocBong", "NH");

            entity.Property(e => e.IdThongTinHocBong).ValueGeneratedNever();
            entity.Property(e => e.DonViTaiTro).HasColumnType("text");
            entity.Property(e => e.TenHocBong).HasColumnType("text");

            entity.HasOne(d => d.IdHocVienNavigation).WithMany(p => p.TbThongTinHocBongs)
                .HasForeignKey(d => d.IdHocVien)
                .HasConstraintName("FK_tbThongTinHocBong_tbHocVien");

            entity.HasOne(d => d.IdLoaiHocBongNavigation).WithMany(p => p.TbThongTinHocBongs)
                .HasForeignKey(d => d.IdLoaiHocBong)
                .HasConstraintName("FK_tbThongTinHocBong_dmLoaiHocBong");
        });

        modelBuilder.Entity<TbThongTinHocTapNghienCuuSinh>(entity =>
        {
            entity.HasKey(e => e.IdThongTinHocTapNghienCuuSinh);

            entity.ToTable("tbThongTinHocTapNghienCuuSinh", "NH");

            entity.Property(e => e.IdThongTinHocTapNghienCuuSinh).ValueGeneratedNever();
            entity.Property(e => e.QuyChuanNguoiHuongDan).HasColumnType("ntext");
            entity.Property(e => e.SoQuyetDinhCongNhan).HasMaxLength(50);
            entity.Property(e => e.SoQuyetDinhThanhLapHoiDongBaoVeCapCoSo).HasMaxLength(50);
            entity.Property(e => e.SoQuyetDinhThanhLapHoiDongBaoVeCapTruong).HasMaxLength(50);
            entity.Property(e => e.SoQuyetDinhThoiHoc).HasMaxLength(50);
            entity.Property(e => e.TenLuanVan).HasColumnType("ntext");

            entity.HasOne(d => d.IdChuongTrinhDaoTaoNavigation).WithMany(p => p.TbThongTinHocTapNghienCuuSinhs)
                .HasForeignKey(d => d.IdChuongTrinhDaoTao)
                .HasConstraintName("FK_tbThongTinHocTapNghienCuuSinh_dmChuongTrinhDaoTao");

            entity.HasOne(d => d.IdDoiTuongDauVaoNavigation).WithMany(p => p.TbThongTinHocTapNghienCuuSinhs)
                .HasForeignKey(d => d.IdDoiTuongDauVao)
                .HasConstraintName("FK_tbThongTinHocTapNghienCuuSinh_dmDoiTuongDauVao");

            entity.HasOne(d => d.IdHocVienNavigation).WithMany(p => p.TbThongTinHocTapNghienCuuSinhs)
                .HasForeignKey(d => d.IdHocVien)
                .HasConstraintName("FK_tbThongTinHocTapNghienCuuSinh_tbHocVien");

            entity.HasOne(d => d.IdLoaiHinhDaoTaoNavigation).WithMany(p => p.TbThongTinHocTapNghienCuuSinhs)
                .HasForeignKey(d => d.IdLoaiHinhDaoTao)
                .HasConstraintName("FK_tbThongTinHocTapNghienCuuSinh_dmLoaiHinhDaoTao");

            entity.HasOne(d => d.IdLoaiTotNghiepNavigation).WithMany(p => p.TbThongTinHocTapNghienCuuSinhs)
                .HasForeignKey(d => d.IdLoaiTotNghiep)
                .HasConstraintName("FK_tbThongTinHocTapNghienCuuSinh_dmLoaiTotNghiep");

            entity.HasOne(d => d.IdNguoiHuongDanChinhNavigation).WithMany(p => p.TbThongTinHocTapNghienCuuSinhIdNguoiHuongDanChinhNavigations)
                .HasForeignKey(d => d.IdNguoiHuongDanChinh)
                .HasConstraintName("FK_tbThongTinHocTapNghienCuuSinh_tbCanBo");

            entity.HasOne(d => d.IdNguoiHuongDanPhuNavigation).WithMany(p => p.TbThongTinHocTapNghienCuuSinhIdNguoiHuongDanPhuNavigations)
                .HasForeignKey(d => d.IdNguoiHuongDanPhu)
                .HasConstraintName("FK_tbThongTinHocTapNghienCuuSinh_tbCanBo1");

            entity.HasOne(d => d.IdSinhVienNamNavigation).WithMany(p => p.TbThongTinHocTapNghienCuuSinhs)
                .HasForeignKey(d => d.IdSinhVienNam)
                .HasConstraintName("FK_tbThongTinHocTapNghienCuuSinh_dmSinhVienNam");

            entity.HasOne(d => d.IdTrangThaiHocNavigation).WithMany(p => p.TbThongTinHocTapNghienCuuSinhs)
                .HasForeignKey(d => d.IdTrangThaiHoc)
                .HasConstraintName("FK_tbThongTinHocTapNghienCuuSinh_dmTrangThaiHoc");
        });

        modelBuilder.Entity<TbThongTinHocTapSinhVien>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tbThongTinHocTapSinhVien", "NH");

            entity.Property(e => e.DangOnoiTru).HasColumnName("DangONoiTru");
            entity.Property(e => e.KetQuaTuyenSinh).HasColumnType("text");
            entity.Property(e => e.Khoa).HasMaxLength(200);
            entity.Property(e => e.Lop).HasMaxLength(50);
            entity.Property(e => e.SoQuyetDinhThoiHoc).HasMaxLength(50);
            entity.Property(e => e.SoQuyetDinhTotNghiep).HasMaxLength(50);
            entity.Property(e => e.SoQuyetDinhTrungTuyen).HasMaxLength(50);

            entity.HasOne(d => d.BangTotNghiepLienThongNavigation).WithMany()
                .HasForeignKey(d => d.BangTotNghiepLienThong)
                .HasConstraintName("FK_tbThongTinHocTapHocVien_dmTuyChon");

            entity.HasOne(d => d.DangOnoiTruNavigation).WithMany()
                .HasForeignKey(d => d.DangOnoiTru)
                .HasConstraintName("FK_tbThongTinHocTapHocVien_dmTuyChon1");

            entity.HasOne(d => d.IdChuongTrinhDaoTaoNavigation).WithMany()
                .HasForeignKey(d => d.IdChuongTrinhDaoTao)
                .HasConstraintName("FK_tbThongTinHocTapHocVien_dmChuongTrinhDaoTao");

            entity.HasOne(d => d.IdDoiTuongDauVaoNavigation).WithMany()
                .HasForeignKey(d => d.IdDoiTuongDauVao)
                .HasConstraintName("FK_tbThongTinHocTapHocVien_dmDoiTuongDauVao");

            entity.HasOne(d => d.IdHocVienNavigation).WithMany()
                .HasForeignKey(d => d.IdHocVien)
                .HasConstraintName("FK_tbThongTinHocTapHocVien_tbHocVien");

            entity.HasOne(d => d.IdLoaiHinhDaoTaoNavigation).WithMany()
                .HasForeignKey(d => d.IdLoaiHinhDaoTao)
                .HasConstraintName("FK_tbThongTinHocTapHocVien_dmLoaiHinhDaoTao");

            entity.HasOne(d => d.IdLoaiTotNghiepNavigation).WithMany()
                .HasForeignKey(d => d.IdLoaiTotNghiep)
                .HasConstraintName("FK_tbThongTinHocTapHocVien_dmLoaiTotNghiep");

            entity.HasOne(d => d.IdSinhVienNamNavigation).WithMany()
                .HasForeignKey(d => d.IdSinhVienNam)
                .HasConstraintName("FK_tbThongTinHocTapHocVien_dmSinhVienNam");

            entity.HasOne(d => d.IdTrangThaiHocNavigation).WithMany()
                .HasForeignKey(d => d.IdTrangThaiHoc)
                .HasConstraintName("FK_tbThongTinHocTapHocVien_dmTrangThaiHoc");
        });

        modelBuilder.Entity<TbThongTinHopTac>(entity =>
        {
            entity.HasKey(e => e.IdThongTinHopTac);

            entity.ToTable("tbThongTinHopTac", "HTQT");

            entity.Property(e => e.IdThongTinHopTac).ValueGeneratedNever();
            entity.Property(e => e.DonViTrienKhai).HasMaxLength(200);
            entity.Property(e => e.SanPhamChinh).HasMaxLength(200);
            entity.Property(e => e.TenThoaThuan).HasMaxLength(200);

            entity.HasOne(d => d.IdHinhThucHopTacNavigation).WithMany(p => p.TbThongTinHopTacs)
                .HasForeignKey(d => d.IdHinhThucHopTac)
                .HasConstraintName("FK_tbThongTinHopTac_dmHinhThucHopTac");

            entity.HasOne(d => d.IdToChucHopTacNavigation).WithMany(p => p.TbThongTinHopTacs)
                .HasForeignKey(d => d.IdToChucHopTac)
                .HasConstraintName("FK_tbThongTinHopTac_tbToChucHopTacQuocTe");
        });

        modelBuilder.Entity<TbThongTinKiemDinhCuaChuongTrinh>(entity =>
        {
            entity.HasKey(e => e.IdThongTinKiemDinhCuaChuongTrinh);

            entity.ToTable("tbThongTinKiemDinhCuaChuongTrinh", "CTDT");

            entity.Property(e => e.IdThongTinKiemDinhCuaChuongTrinh).ValueGeneratedNever();
            entity.Property(e => e.SoQuyetDinh).HasMaxLength(200);

            entity.HasOne(d => d.IdChuongTrinhDaoTaoNavigation).WithMany(p => p.TbThongTinKiemDinhCuaChuongTrinhs)
                .HasForeignKey(d => d.IdChuongTrinhDaoTao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbThongTinKiemDinhCuaChuongTrinh_tbChuongTrinhDaoTao");

            entity.HasOne(d => d.IdKetQuaKiemDinhNavigation).WithMany(p => p.TbThongTinKiemDinhCuaChuongTrinhs)
                .HasForeignKey(d => d.IdKetQuaKiemDinh)
                .HasConstraintName("FK_tbThongTinKiemDinhCuaChuongTrinh_dmKetQuaKiemDinh");

            entity.HasOne(d => d.IdToChucKiemDinhNavigation).WithMany(p => p.TbThongTinKiemDinhCuaChuongTrinhs)
                .HasForeignKey(d => d.IdToChucKiemDinh)
                .HasConstraintName("FK_tbThongTinKiemDinhCuaChuongTrinh_dmToChucKiemDinh");
        });

        modelBuilder.Entity<TbThongTinLinhVucDaoTao>(entity =>
        {
            entity.HasKey(e => e.IdThongTinLinhVucDaoTao).HasName("PK_dmThongTinLinhVucDaoTao");

            entity.ToTable("tbThongTinLinhVucDaoTao", "NDT");

            entity.Property(e => e.IdThongTinLinhVucDaoTao).ValueGeneratedNever();

            entity.HasOne(d => d.IdKhoiNganhNavigation).WithMany(p => p.TbThongTinLinhVucDaoTaos)
                .HasForeignKey(d => d.IdKhoiNganh)
                .HasConstraintName("FK_dmThongTinLinhVucDaoTao_tbKhoiNganhDaoTao");

            entity.HasOne(d => d.IdLinhVucDaoTaoNavigation).WithMany(p => p.TbThongTinLinhVucDaoTaos)
                .HasForeignKey(d => d.IdLinhVucDaoTao)
                .HasConstraintName("FK_dmThongTinLinhVucDaoTao_dmLinhVucDaoTao");
        });

        modelBuilder.Entity<TbThongTinNguoiHocGdtc>(entity =>
        {
            entity.HasKey(e => e.IdThongTinNguoiHocGdtc);

            entity.ToTable("tbThongTinNguoiHocGDTC", "NH");

            entity.Property(e => e.IdThongTinNguoiHocGdtc)
                .ValueGeneratedNever()
                .HasColumnName("IdThongTinNguoiHocGDTC");
            entity.Property(e => e.KetQuaHocTap).HasColumnType("text");
            entity.Property(e => e.TieuChuanDanhGiaXepLoaiTheLuc).HasColumnType("text");

            entity.HasOne(d => d.IdHocVienNavigation).WithMany(p => p.TbThongTinNguoiHocGdtcs)
                .HasForeignKey(d => d.IdHocVien)
                .HasConstraintName("FK_tbThongTinNguoiHocGDTC_tbHocVien");
        });

        modelBuilder.Entity<TbThongTinViPham>(entity =>
        {
            entity.HasKey(e => e.IdThongTinViPham);

            entity.ToTable("tbThongTinViPham", "NH");

            entity.Property(e => e.IdThongTinViPham).ValueGeneratedNever();
            entity.Property(e => e.HinhThucXuLy).HasColumnType("text");
            entity.Property(e => e.NoiDungViPham).HasColumnType("text");

            entity.HasOne(d => d.IdHocVienNavigation).WithMany(p => p.TbThongTinViPhams)
                .HasForeignKey(d => d.IdHocVien)
                .HasConstraintName("FK_tbThongTinViPham_tbHocVien");

            entity.HasOne(d => d.IdLoaiViPhamNavigation).WithMany(p => p.TbThongTinViPhams)
                .HasForeignKey(d => d.IdLoaiViPham)
                .HasConstraintName("FK_tbThongTinViPham_dmLoaiViPham");
        });

        modelBuilder.Entity<TbThongTinViecLamSauTotNghiep>(entity =>
        {
            entity.HasKey(e => e.IdThongTinViecLamSauTotNghiep);

            entity.ToTable("tbThongTinViecLamSauTotNghiep", "NH");

            entity.Property(e => e.IdThongTinViecLamSauTotNghiep).ValueGeneratedNever();
            entity.Property(e => e.DonViTuyenDung).HasColumnType("text");
            entity.Property(e => e.TenDonViCapBang).HasColumnType("text");

            entity.HasOne(d => d.IdHinhThucTuyenDungNavigation).WithMany(p => p.TbThongTinViecLamSauTotNghieps)
                .HasForeignKey(d => d.IdHinhThucTuyenDung)
                .HasConstraintName("FK_tbThongTinViecLamSauTotNghiep_dmHinhThucTuyenDung");

            entity.HasOne(d => d.IdHocVienNavigation).WithMany(p => p.TbThongTinViecLamSauTotNghieps)
                .HasForeignKey(d => d.IdHocVien)
                .HasConstraintName("FK_tbThongTinViecLamSauTotNghiep_tbHocVien");

            entity.HasOne(d => d.IdViTriViecLamNavigation).WithMany(p => p.TbThongTinViecLamSauTotNghieps)
                .HasForeignKey(d => d.IdViTriViecLam)
                .HasConstraintName("FK_tbThongTinViecLamSauTotNghiep_dmViTriViecLam");
        });
        modelBuilder.Entity<TbThuVienTrungTamHocLieu>(entity =>
        {
            entity.HasKey(e => e.IdThuVienTrungTamHocLieu);
            entity.ToTable("tbThuVienTrungTamHocLieu", "CSVC");

            entity.Property(e => e.IdThuVienTrungTamHocLieu).ValueGeneratedNever();
            entity.Property(e => e.TenThuVienTrungTamHocLieu).HasColumnType("nvarchar(max)");
            entity.Property(e => e.NamDuaVaoSuDung).HasMaxLength(2000000);
            entity.Property(e => e.DienTich).HasMaxLength(2000000);
            entity.Property(e => e.DienTichPhongDoc).HasMaxLength(2000000);
            entity.Property(e => e.SoPhongDoc).HasMaxLength(2000000);
            entity.Property(e => e.SoLuongMayTinh).HasMaxLength(2000000);
            entity.Property(e => e.SoLuongChoNgoi).HasMaxLength(2000000);
            entity.Property(e => e.SoLuongSach).HasMaxLength(2000000);
            entity.Property(e => e.SoLuongTapChi).HasMaxLength(2000000);
            entity.Property(e => e.SoLuongSachDienTu).HasMaxLength(2000000);
            entity.Property(e => e.SoLuongTapChiDienTu).HasMaxLength(2000000);
            entity.Property(e => e.SoLuonngThuVienDienTuLienKetNn).HasMaxLength(2000000);

            entity.HasOne(d => d.IdHinhThucSoHuuNavigation).WithMany(p => p.TbThuVienTrungTamHocLieus)
                 .HasForeignKey(d => d.IdHinhThucSoHuu)
                 .HasConstraintName("FK_tbThuVienTrungTamHocLieu_dmHinhThucSoHuu");

            entity.HasOne(d => d.IdTinhTrangCsvcNavigation).WithMany(p => p.TbThuVienTrungTamHocLieus)
                .HasForeignKey(d => d.IdTinhTrangCsvc)
                .HasConstraintName("FK_tbThuVienTrungTamHocLieu_dmTinhTrangCoSoVatChat");





            entity.Property(e => e.SoLuongDauSach).HasMaxLength(2000000);
            entity.Property(e => e.SoLuongDauTapChi).HasMaxLength(2000000);
            entity.Property(e => e.SoLuongDauSachDienTu).HasMaxLength(2000000);
            entity.Property(e => e.SoLuongDauTapChiDienTu).HasMaxLength(2000000);
        });

        modelBuilder.Entity<TbToChucHopTacDoanhNghiep>(entity =>
        {
            entity.HasKey(e => e.IdToChucHopTacDoanhNghiep);

            entity.ToTable("tbToChucHopTacDoanhNghiep", "HTDN");

            entity.Property(e => e.IdToChucHopTacDoanhNghiep).ValueGeneratedNever();
            entity.Property(e => e.KetQuaHopTac).HasMaxLength(50);
            entity.Property(e => e.MaToChucHopTacDoanhNghiep).HasMaxLength(50);
            entity.Property(e => e.NoiDungHopTac).HasMaxLength(200);
            entity.Property(e => e.TenToChucHopTacDoanhNghiep).HasMaxLength(200);

            entity.HasOne(d => d.IdLoaiDeAnNavigation).WithMany(p => p.TbToChucHopTacDoanhNghieps)
                .HasForeignKey(d => d.IdLoaiDeAn)
                .HasConstraintName("FK_tbToChucHopTacDoanhNghiep_dmLoaiDeAnChuongTrinh");
        });

        modelBuilder.Entity<TbToChucHopTacQuocTe>(entity =>
        {
            entity.HasKey(e => e.IdToChucHopTacQuocTe);

            entity.ToTable("tbToChucHopTacQuocTe", "HTQT");

            entity.Property(e => e.IdToChucHopTacQuocTe).ValueGeneratedNever();
            entity.Property(e => e.KetQuaHopTac).HasMaxLength(200);
            entity.Property(e => e.LoaiToChuc).HasMaxLength(200);
            entity.Property(e => e.MaHopTac).HasMaxLength(50);
            entity.Property(e => e.TenToChuc).HasMaxLength(200);

            entity.HasOne(d => d.IdQuocGiaNavigation).WithMany(p => p.TbToChucHopTacQuocTes)
                .HasForeignKey(d => d.IdQuocGia)
                .HasConstraintName("FK_tbToChucHopTacQuocTe_dmQuocTich");
        });

        modelBuilder.Entity<TbToChucKiemDinh>(entity =>
        {
            entity.HasKey(e => e.IdToChucKiemDinhCsdg).HasName("PK_tbToChucKiemDinh_1");

            entity.ToTable("tbToChucKiemDinh", "CSGD");

            entity.Property(e => e.IdToChucKiemDinhCsdg)
                .ValueGeneratedNever()
                .HasColumnName("IdToChucKiemDinhCSDG");
            entity.Property(e => e.SoQuyetDinhKiemDinh).HasMaxLength(200);

            entity.HasOne(d => d.IdKetQuaNavigation).WithMany(p => p.TbToChucKiemDinhs)
                .HasForeignKey(d => d.IdKetQua)
                .HasConstraintName("FK_tbToChucKiemDinh_dmKetQuaKiemDinh");

            entity.HasOne(d => d.IdToChucKiemDinhNavigation).WithMany(p => p.TbToChucKiemDinhs)
                .HasForeignKey(d => d.IdToChucKiemDinh)
                .HasConstraintName("FK_tbToChucKiemDinh_dmToChucKiemDinh");
        });

        modelBuilder.Entity<TbTrinhDoTiengDanToc>(entity =>
        {
            entity.HasKey(e => e.IdTrinhDoTiengDanToc);

            entity.ToTable("tbTrinhDoTiengDanToc", "CB");

            entity.Property(e => e.IdTrinhDoTiengDanToc).ValueGeneratedNever();

            entity.HasOne(d => d.IdCanBoNavigation).WithMany(p => p.TbTrinhDoTiengDanTocs)
                .HasForeignKey(d => d.IdCanBo)
                .HasConstraintName("FK_tbTrinhDoTiengDanToc_tbCanBo");

            entity.HasOne(d => d.IdKhungNangLucNgoaiNguNavigation).WithMany(p => p.TbTrinhDoTiengDanTocs)
                .HasForeignKey(d => d.IdKhungNangLucNgoaiNgu)
                .HasConstraintName("FK_tbTrinhDoTiengDanToc_dmKhungNangLucNgoaiNgu");

            entity.HasOne(d => d.IdTiengDanTocNavigation).WithMany(p => p.TbTrinhDoTiengDanTocs)
                .HasForeignKey(d => d.IdTiengDanToc)
                .HasConstraintName("FK_tbTrinhDoTiengDanToc_dmTiengDanToc");
        });

        modelBuilder.Entity<TbVanBanTuChu>(entity =>
        {
            entity.HasKey(e => e.IdVanBanTuChu);

            entity.ToTable("tbVanBanTuChu", "CSGD");

            entity.Property(e => e.IdVanBanTuChu).ValueGeneratedNever();
            entity.Property(e => e.CoQuanQuyetDinhBanHanh).HasMaxLength(200);
            entity.Property(e => e.LoaiVanBan).HasMaxLength(200);
            entity.Property(e => e.QuyetDinhBanHanh).HasMaxLength(200);
        });

        modelBuilder.Entity<VBaiBaoKhdaCongBo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vBaiBaoKHDaCongBo", "KHCN");

            entity.Property(e => e.GhiChuDuongDanBaiBao).HasMaxLength(200);
            entity.Property(e => e.MaBaiBaoKh)
                .HasMaxLength(50)
                .HasColumnName("MaBaiBaoKH");
            entity.Property(e => e.MaNhiemVu).HasMaxLength(50);
            entity.Property(e => e.NamCongBo).HasColumnType("text");
            entity.Property(e => e.TapChiKhoaHocQuocTe).HasMaxLength(50);
            entity.Property(e => e.TapChiTrongNuoc).HasMaxLength(200);
            entity.Property(e => e.TenBaiBaoKh)
                .HasMaxLength(300)
                .HasColumnName("TenBaiBaoKH");
            entity.Property(e => e.TenTapChi).HasMaxLength(200);
            entity.Property(e => e.XepHangQ).HasMaxLength(50);
        });

        modelBuilder.Entity<VChiTietTaiSanDonVi>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vChiTietTaiSanDonVi", "TCTS");

            entity.Property(e => e.ChuSoHuu).HasMaxLength(50);
            entity.Property(e => e.MaLoaiTaiSan).HasMaxLength(50);
            entity.Property(e => e.MaTaiSan).HasMaxLength(50);
            entity.Property(e => e.TenTaiSan).HasMaxLength(200);
            entity.Property(e => e.TinhTrangThietBi).HasMaxLength(50);
        });

        modelBuilder.Entity<VChiTietThuChi>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vChiTietThuChi", "TCTS");

            entity.Property(e => e.MaLoaiThuChi).HasMaxLength(50);
            entity.Property(e => e.NamTaiChinh).HasColumnType("text");
            entity.Property(e => e.TenKhoanThuChi).HasMaxLength(200);
        });

        modelBuilder.Entity<VChiTieuTuyenSinhTheoNganh>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vChiTieuTuyenSinhTheoNganh", "TS");

            entity.Property(e => e.LoaiHinhDaoTao).HasMaxLength(200);
            entity.Property(e => e.Nam).HasColumnType("text");
            entity.Property(e => e.NganhDaoTao).HasMaxLength(200);
        });

        modelBuilder.Entity<VChuongTrinhDaoTao>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vChuongTrinhDaoTao", "CTDT");

            entity.Property(e => e.ChuanDauRa).HasMaxLength(200);
            entity.Property(e => e.ChuanDauRaVeNgoaiNgu).HasMaxLength(200);
            entity.Property(e => e.ChuanDauRaVeTinHoc).HasMaxLength(200);
            entity.Property(e => e.DiaDiemDaoTao).HasMaxLength(200);
            entity.Property(e => e.DonViCapBang).HasMaxLength(200);
            entity.Property(e => e.DonViThucHienChuongTrinh).HasMaxLength(200);
            entity.Property(e => e.HocCheDaoTao).HasMaxLength(200);
            entity.Property(e => e.LoaiChungChiDuocChapThuan).HasMaxLength(200);
            entity.Property(e => e.LoaiChuongTrinhDaoTao).HasMaxLength(200);
            entity.Property(e => e.LoaiChuongTrinhLienKetDaoTao).HasMaxLength(200);
            entity.Property(e => e.MaChuongTrinhDaoTao).HasMaxLength(200);
            entity.Property(e => e.NganhDaoTao).HasMaxLength(200);
            entity.Property(e => e.TenChuongTrinh).HasMaxLength(200);
            entity.Property(e => e.TenChuongTrinhBangTiengAnh).HasMaxLength(200);
            entity.Property(e => e.TenCoSoDaoTaoNuocNgoai).HasMaxLength(200);
            entity.Property(e => e.TenNuoc).HasMaxLength(200);
            entity.Property(e => e.TrangThaiChuongTrinhDaoTao).HasMaxLength(200);
            entity.Property(e => e.TrinhDoDaoTao).HasMaxLength(200);
        });

        modelBuilder.Entity<VChuyenGiaoCongNgheVaDaoTao>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vChuyenGiaoCongNgheVaDaoTao", "KHCN");

            entity.Property(e => e.ChuSoHuu).HasMaxLength(50);
            entity.Property(e => e.DonViChuTri).HasMaxLength(50);
            entity.Property(e => e.DonViNhanChuyenGiao).HasMaxLength(50);
            entity.Property(e => e.DonViPhoiHop).HasMaxLength(50);
            entity.Property(e => e.HinhThucChuyenGiaoCongNghe).HasMaxLength(50);
            entity.Property(e => e.LinhVucNghienCuu).HasMaxLength(200);
            entity.Property(e => e.MaNhiemVu).HasMaxLength(50);
            entity.Property(e => e.MaSoHopDong).HasMaxLength(50);
            entity.Property(e => e.PhuongThucChuyenGiaoCongNghe).HasMaxLength(50);
            entity.Property(e => e.SoNguoiDuocDaoTaoChuyenGiaoCn).HasColumnName("SoNguoiDuocDaoTaoChuyenGiaoCN");
            entity.Property(e => e.Ten).HasMaxLength(50);
            entity.Property(e => e.TenDuAn).HasMaxLength(50);
            entity.Property(e => e.TomTat).HasMaxLength(200);
            entity.Property(e => e.TrangThaiHopDong).HasMaxLength(200);
        });

        modelBuilder.Entity<VCoCauToChuc>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vCoCauToChuc", "CSGD");

            entity.Property(e => e.LoaiPhongBan).HasMaxLength(200);
            entity.Property(e => e.MaPhongBanDonVi).HasMaxLength(200);
            entity.Property(e => e.MaPhongBanDonViCha).HasMaxLength(200);
            entity.Property(e => e.NgayRaQuyetDinh).HasMaxLength(200);
            entity.Property(e => e.SoQuyetDinhThanhLap).HasMaxLength(200);
            entity.Property(e => e.TenPhongBanDonVi).HasMaxLength(200);
            entity.Property(e => e.TrangThaiCoSoGd)
                .HasMaxLength(50)
                .HasColumnName("TrangThaiCoSoGD");
        });

        modelBuilder.Entity<VCoSoGiaoDuc>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vCoSoGiaoDuc", "CSGD");

            entity.Property(e => e.CoQuanChuQuan).HasMaxLength(200);
            entity.Property(e => e.DaoTaoSvgdqpan1nam).HasColumnName("DaoTaoSVGDQPAN_1Nam");
            entity.Property(e => e.DiaChi).HasMaxLength(200);
            entity.Property(e => e.DiaChiWebsite).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Fax).HasMaxLength(50);
            entity.Property(e => e.HinhThucThanhLap).HasMaxLength(200);
            entity.Property(e => e.HoatDongKhongLoiNhuan).HasMaxLength(50);
            entity.Property(e => e.LoaiHinhCoSoDaoTao).HasMaxLength(200);
            entity.Property(e => e.LoaiHinhTruong).HasMaxLength(200);
            entity.Property(e => e.MaDonVi).HasMaxLength(50);
            entity.Property(e => e.PhanLoaiCoSo).HasMaxLength(200);
            entity.Property(e => e.SoDienThoai).HasMaxLength(50);
            entity.Property(e => e.SoGiaoVienGdtc).HasColumnName("SoGiaoVienGDTC");
            entity.Property(e => e.SoQuyetDinhBanHanhQuyCheTaiChinh).HasMaxLength(200);
            entity.Property(e => e.SoQuyetDinhCapPhepHoatDong).HasMaxLength(200);
            entity.Property(e => e.SoQuyetDinhChuyenDoiLoaiHinh).HasMaxLength(200);
            entity.Property(e => e.SoQuyetDinhGiaoTuChu).HasMaxLength(200);
            entity.Property(e => e.SoQuyetDinhThanhLap).HasMaxLength(200);
            entity.Property(e => e.TenDaiHocTrucThuoc).HasMaxLength(200);
            entity.Property(e => e.TenDonVi).HasMaxLength(200);
            entity.Property(e => e.TenHuyen).HasMaxLength(200);
            entity.Property(e => e.TenTiengAnh).HasMaxLength(200);
            entity.Property(e => e.TenTinh).HasMaxLength(100);
            entity.Property(e => e.TenXa).HasMaxLength(200);
            entity.Property(e => e.TuChuGiaoDucQpan)
                .HasMaxLength(50)
                .HasColumnName("TuChuGiaoDucQPAN");
        });

        modelBuilder.Entity<VCongTrinhCoSoVatChat>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vCongTrinhCoSoVatChat", "CSVC");

            entity.Property(e => e.CongTrinhCsvctrongNha)
                .HasMaxLength(50)
                .HasColumnName("CongTrinhCSVCTrongNha");
            entity.Property(e => e.DoiTuongSuDung).HasMaxLength(200);
            entity.Property(e => e.HinhThucSoHuu).HasMaxLength(50);
            entity.Property(e => e.LoaiCongTrinhCoSoVatChat).HasMaxLength(200);
            entity.Property(e => e.MaCongTrinh).HasMaxLength(50);
            entity.Property(e => e.MucDichSuDungCsvc)
                .HasMaxLength(200)
                .HasColumnName("MucDichSuDungCSVC");
            entity.Property(e => e.NamDuaVaoSuDung).HasColumnType("text");
            entity.Property(e => e.SoChoOchoCanBoGiangDay).HasColumnName("SoChoOChoCanBoGiangDay");
            entity.Property(e => e.SoPhongOcongVu).HasColumnName("SoPhongOCongVu");
            entity.Property(e => e.TenCongTrinh).HasMaxLength(200);
            entity.Property(e => e.TinhTrangCoSoVatChat).HasMaxLength(200);
        });

        modelBuilder.Entity<VDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGd>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vDanhHieuThiDuaGiaiThuongKhenThuongCuaCoSoGD", "CSGD");

            entity.Property(e => e.CapKhenThuong).HasMaxLength(200);
            entity.Property(e => e.LoaiDanhHieuThiDuaGiaiThuongKhenThuong).HasMaxLength(200);
            entity.Property(e => e.NamKhenThuong).HasColumnType("text");
            entity.Property(e => e.PhuongThucKhenThuong).HasMaxLength(200);
            entity.Property(e => e.SoQuyetDinhKhenThuong).HasMaxLength(200);
            entity.Property(e => e.ThiDuaGiaiThuongKhenThuong).HasMaxLength(200);
        });

        modelBuilder.Entity<VDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc", "NH");

            entity.Property(e => e.CapKhenThuong).HasMaxLength(200);
            entity.Property(e => e.Ho).HasMaxLength(50);
            entity.Property(e => e.LoaiDanhHieuThiDuaGiaiThuongKhenThuong).HasMaxLength(200);
            entity.Property(e => e.NamKhenThuong).HasColumnType("text");
            entity.Property(e => e.PhuongThucKhenThuong).HasMaxLength(200);
            entity.Property(e => e.SoCccd)
                .HasMaxLength(50)
                .HasColumnName("SoCCCD");
            entity.Property(e => e.SoQuyetDinhKhenThuong).HasMaxLength(50);
            entity.Property(e => e.Ten).HasMaxLength(50);
            entity.Property(e => e.ThiDuaGiaiThuongKhenThuong).HasMaxLength(200);
        });

        modelBuilder.Entity<VDanhSachNganhDaoTao>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vDanhSachNganhDaoTao", "NDT");

            entity.Property(e => e.CoQuanBanHanh).HasMaxLength(50);
            entity.Property(e => e.HinhThucDaoTaoTheoChuyenNgu).HasMaxLength(50);
            entity.Property(e => e.MaNganhMoLanDau).HasMaxLength(50);
            entity.Property(e => e.NamBatDauDaoTao).HasColumnType("text");
            entity.Property(e => e.NamBatDauDaoTaoTuXa).HasColumnType("text");
            entity.Property(e => e.NamBatDauThucHienUuTienDaoTaoNhanLucDuLichCntt)
                .HasColumnType("text")
                .HasColumnName("NamBatDauThucHienUuTienDaoTaoNhanLucDuLichCNTT");
            entity.Property(e => e.NamTuyenSinhVaDaoTaoGanNhat).HasColumnType("text");
            entity.Property(e => e.NganhDaoTaoLienKetNuocNgoai).HasMaxLength(50);
            entity.Property(e => e.NguoiKy).HasMaxLength(50);
            entity.Property(e => e.QuyetDinhTuChu).HasMaxLength(50);
            entity.Property(e => e.SoNamDaoTaoThSts).HasColumnName("SoNamDaoTaoThSTS");
            entity.Property(e => e.SoQuyetDinhChoPhepDoiTenNganh).HasMaxLength(50);
            entity.Property(e => e.SoQuyetDinhChoPhepMoNganh).HasMaxLength(50);
            entity.Property(e => e.SoQuyetDinhDaoTaoTuXa).HasMaxLength(50);
            entity.Property(e => e.TenNganhMoLanDau).HasMaxLength(200);
            entity.Property(e => e.TrangThaiDaoTao).HasMaxLength(50);
            entity.Property(e => e.TuChuMoNganh).HasMaxLength(50);
            entity.Property(e => e.UuTienDaoTaoNhanLucDuLichCntt)
                .HasMaxLength(50)
                .HasColumnName("UuTienDaoTaoNhanLucDuLichCNTT");
        });

        modelBuilder.Entity<VDanhSachVanBangChungChi>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vDanhSachVanBangChungChi", "VB");

            entity.Property(e => e.ChuongTrinhDaoTao).HasMaxLength(200);
            entity.Property(e => e.Ho).HasMaxLength(50);
            entity.Property(e => e.LoaiTotNghiep).HasMaxLength(50);
            entity.Property(e => e.NamTotNghiep).HasColumnType("text");
            entity.Property(e => e.SoCccd)
                .HasMaxLength(50)
                .HasColumnName("SoCCCD");
            entity.Property(e => e.SoHieuVanBang).HasMaxLength(50);
            entity.Property(e => e.SoQuyetDinhCongNhanTotNghiep).HasMaxLength(50);
            entity.Property(e => e.SoQuyetDinhThanhLapHoiDongDanhGiaLuanVan).HasMaxLength(50);
            entity.Property(e => e.SoVaoSoGocCapVanBang).HasMaxLength(50);
            entity.Property(e => e.Ten).HasMaxLength(50);
            entity.Property(e => e.TenDonViBangCap).HasMaxLength(200);
            entity.Property(e => e.TenVanBang).HasMaxLength(200);
        });

        modelBuilder.Entity<VDatDai>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vDatDai", "CSVC");

            entity.Property(e => e.HinhThucSoHuu).HasMaxLength(50);
            entity.Property(e => e.MaGiayChungNhanQuyenSoHuu).HasMaxLength(200);
            entity.Property(e => e.MinhChungQuyenSoHuuDatDai).HasMaxLength(200);
            entity.Property(e => e.MucDichSuDungDat).HasMaxLength(200);
            entity.Property(e => e.NamBatDauSuDungDat).HasColumnType("text");
            entity.Property(e => e.TenDonViSoHuu).HasMaxLength(200);
        });

        modelBuilder.Entity<VDauMoiLienHe>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vDauMoiLienHe", "CSGD");

            entity.Property(e => e.DauMoiLienHe).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.SoDienThoai).HasMaxLength(50);
        });

        modelBuilder.Entity<VDeAnDuAnChuongTrinh>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vDeAnDuAnChuongTrinh", "HTQT");

            entity.Property(e => e.MaDeAnDuAnChuongTrinh).HasMaxLength(50);
            entity.Property(e => e.NguonKinhPhiChoDeAn).HasMaxLength(50);
            entity.Property(e => e.TenDeAnDuAnChuongTrinh).HasMaxLength(200);
        });

        modelBuilder.Entity<VDoanCongTac>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vDoanCongTac", "HTQT");

            entity.Property(e => e.KetQuaCongTac).HasMaxLength(200);
            entity.Property(e => e.MaDoanCongTac).HasMaxLength(50);
            entity.Property(e => e.PhanLoaiDoanRaDoanVao).HasMaxLength(50);
            entity.Property(e => e.SoQuyetDinh).HasMaxLength(50);
            entity.Property(e => e.TenDoanCongTac).HasMaxLength(200);
            entity.Property(e => e.TenNuoc).HasMaxLength(200);
        });

        modelBuilder.Entity<VDoanhNghiepKhcn>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vDoanhNghiepKHCN", "KHCN");

            entity.Property(e => e.DiaDiemThanhLap).HasMaxLength(200);
            entity.Property(e => e.HinhThucDoanhNghiepKhcn)
                .HasMaxLength(50)
                .HasColumnName("HinhThucDoanhNghiepKHCN");
            entity.Property(e => e.KinhPhiGopVonTuTaiSanTriTue).HasMaxLength(50);
            entity.Property(e => e.MaDoanhNghiep).HasMaxLength(50);
            entity.Property(e => e.TenDoanhNghiep).HasMaxLength(300);
            entity.Property(e => e.TyLeGopVonCuaCsgddh).HasColumnName("TyLeGopVonCuaCSGDDH");
        });

        modelBuilder.Entity<VDoiTuongThamGium>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vDoiTuongThamGia", "KHCN");

            entity.Property(e => e.LoaiThamGia).HasMaxLength(50);
            entity.Property(e => e.MaLoaiThamGia).HasMaxLength(50);
            entity.Property(e => e.PhanLoaiDoiNguNguoiHoc)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.SoCccd)
                .HasMaxLength(50)
                .HasColumnName("SoCCCD");
            entity.Property(e => e.VaiTroThamGia).HasMaxLength(50);
        });

        modelBuilder.Entity<VDonViLienKetDaoTaoGiaoDuc>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vDonViLienKetDaoTaoGiaoDuc", "CSGD");

            entity.Property(e => e.DiaChi).HasMaxLength(200);
            entity.Property(e => e.DienThoai).HasMaxLength(50);
            entity.Property(e => e.LoaiLienKet).HasMaxLength(200);
            entity.Property(e => e.MaDonVi).HasMaxLength(50);
            entity.Property(e => e.TenDonVi).HasMaxLength(200);
        });

        modelBuilder.Entity<VDuLieuTrungTuyen>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vDuLieuTrungTuyen", "TS");

            entity.Property(e => e.Cccd)
                .HasMaxLength(50)
                .HasColumnName("CCCD");
            entity.Property(e => e.ChuongTrinhDaoTaoDaTotNghiepTrinhDoDaiHoc).HasMaxLength(50);
            entity.Property(e => e.ChuongTrinhDaoTaoDaTotNghiepTrinhDoThacSi).HasMaxLength(50);
            entity.Property(e => e.DoiTuongDauVao).HasMaxLength(200);
            entity.Property(e => e.DoiTuongUuTien).HasMaxLength(50);
            entity.Property(e => e.HinhThucTuyenSinh).HasMaxLength(50);
            entity.Property(e => e.HoVaTen).HasMaxLength(50);
            entity.Property(e => e.KhoaDaoTaoTrungTuyen).HasMaxLength(50);
            entity.Property(e => e.KhuVuc).HasMaxLength(200);
            entity.Property(e => e.MaTuyenSinh).HasMaxLength(50);
            entity.Property(e => e.NganhDaTotNghiepTrinhDoDaiHoc).HasMaxLength(50);
            entity.Property(e => e.NganhDaTotNghiepTrinhDoThacSi).HasMaxLength(50);
            entity.Property(e => e.SoQuyetDinhTrungTuyen).HasMaxLength(50);
            entity.Property(e => e.ToHopMonTrungTuyen).HasMaxLength(200);
            entity.Property(e => e.TruongThpt)
                .HasMaxLength(200)
                .HasColumnName("TruongTHPT");
        });

        modelBuilder.Entity<VGiaHanChuongTrinhDaoTao>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vGiaHanChuongTrinhDaoTao", "CTDT");

            entity.Property(e => e.MaChuongTrinhDaoTao).HasMaxLength(200);
            entity.Property(e => e.SoQuyetDinhGiaHan).HasMaxLength(200);
            entity.Property(e => e.TenChuongTrinh).HasMaxLength(200);
        });

        modelBuilder.Entity<VGiaiThuongKhoaHoc>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vGiaiThuongKhoaHoc", "KHCN");

            entity.Property(e => e.CoQuanBanHanhQuyetDinh).HasMaxLength(50);
            entity.Property(e => e.CoQuanToChucGiaiThuong).HasMaxLength(50);
            entity.Property(e => e.LoaiGiaiThuongKhcn)
                .HasMaxLength(200)
                .HasColumnName("LoaiGiaiThuongKHCN");
            entity.Property(e => e.MaGiaiThuong).HasMaxLength(50);
            entity.Property(e => e.MucGiaiThuong).HasMaxLength(50);
            entity.Property(e => e.QuyetDinhCapBangKhen).HasMaxLength(50);
            entity.Property(e => e.TenDeTaiDuocTraoGiai).HasMaxLength(50);
            entity.Property(e => e.TenDonViDuocTraoGiai).HasMaxLength(50);
        });

        modelBuilder.Entity<VGvduocCuDiDaoTao>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vGVDuocCuDiDaoTao", "HTQT");

            entity.Property(e => e.HinhThucThamGiaGvduocCuDiDaoTao)
                .HasMaxLength(200)
                .HasColumnName("HinhThucThamGiaGVDuocCuDiDaoTao");
            entity.Property(e => e.MaCanBo).HasMaxLength(50);
            entity.Property(e => e.NguonKinhPhiCuaGvduocCuDiDaoTao)
                .HasMaxLength(50)
                .HasColumnName("NguonKinhPhiCuaGVDuocCuDiDaoTao");
            entity.Property(e => e.TenCoSoGiaoDucThamGiaOnn)
                .HasMaxLength(200)
                .HasColumnName("TenCoSoGiaoDucThamGiaONN");
            entity.Property(e => e.TenNuoc).HasMaxLength(200);
            entity.Property(e => e.TinhTrangGiangVienDuocCuDiDaoTao).HasMaxLength(200);
        });

        modelBuilder.Entity<VHinhThucDaoTaoCuaNganh>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vHinhThucDaoTaoCuaNganh", "NDT");

            entity.Property(e => e.HinhThucDaoTao).HasMaxLength(200);
            entity.Property(e => e.NganhDaoTao).HasMaxLength(200);
        });

        modelBuilder.Entity<VHoatDongBaoVeMoiTruong>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vHoatDongBaoVeMoiTruong", "KHCN");

            entity.Property(e => e.CoQuanChuQuan).HasMaxLength(200);
            entity.Property(e => e.CoQuanChuTri).HasMaxLength(50);
            entity.Property(e => e.DanhGiaKetQuaNhiemVu).HasMaxLength(50);
            entity.Property(e => e.DonViThucHienLuuTruSanPham).HasMaxLength(50);
            entity.Property(e => e.LoaiNhiemVuBaoVeMoiTruong).HasMaxLength(50);
            entity.Property(e => e.MaNhiemVu).HasMaxLength(50);
            entity.Property(e => e.NguonKinhPhi).HasMaxLength(200);
            entity.Property(e => e.PhanCapNhiemVu).HasMaxLength(50);
            entity.Property(e => e.SanPhamChinhCuaNhiemVu).HasMaxLength(50);
            entity.Property(e => e.TenNhiemVuBvmt)
                .HasMaxLength(300)
                .HasColumnName("TenNhiemVuBVMT");
            entity.Property(e => e.TinhTrangNhiemVu).HasMaxLength(50);
        });

        modelBuilder.Entity<VHoatDongTaiChinh>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vHoatDongTaiChinh", "TCTS");

            entity.Property(e => e.HoatDongTaiChinh).HasMaxLength(200);
            entity.Property(e => e.NamTaiChinh).HasColumnType("text");
            entity.Property(e => e.NoiDung).HasColumnType("text");
        });

        modelBuilder.Entity<VHocVien>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vHocVien", "NH");

            entity.Property(e => e.DanToc).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.GioiTinh).HasMaxLength(200);
            entity.Property(e => e.Ho).HasMaxLength(50);
            entity.Property(e => e.LoaiKhuyetTat).HasMaxLength(50);
            entity.Property(e => e.NoiSinh).HasMaxLength(200);
            entity.Property(e => e.QueQuan).HasMaxLength(200);
            entity.Property(e => e.Sdt).HasMaxLength(50);
            entity.Property(e => e.SoCccd)
                .HasMaxLength(50)
                .HasColumnName("SoCCCD");
            entity.Property(e => e.SoSoBaoHiem).HasMaxLength(50);
            entity.Property(e => e.Ten).HasMaxLength(50);
            entity.Property(e => e.TenHuyen).HasMaxLength(200);
            entity.Property(e => e.TenNuoc).HasMaxLength(200);
            entity.Property(e => e.TenTinh).HasMaxLength(100);
            entity.Property(e => e.TenXa).HasMaxLength(200);
            entity.Property(e => e.TonGiao).HasMaxLength(50);
        });

        modelBuilder.Entity<VHoiThaoHoiNghi>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vHoiThaoHoiNghi", "HTQT");

            entity.Property(e => e.CoQuanCoThamQuyenCapPhep).HasMaxLength(200);
            entity.Property(e => e.DonViChuTri).HasMaxLength(200);
            entity.Property(e => e.MaHoiThaoHoiNghi).HasMaxLength(50);
            entity.Property(e => e.MucTieu).HasMaxLength(200);
            entity.Property(e => e.NguonKinhPhi).HasMaxLength(200);
            entity.Property(e => e.TenHoiThaoHoiNghi).HasMaxLength(200);
        });

        modelBuilder.Entity<VKhoaHoc>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vKhoaHoc", "CSGD");

            entity.Property(e => e.DenNam).HasColumnType("text");
            entity.Property(e => e.TuNam).HasColumnType("text");
        });

        modelBuilder.Entity<VKhoanNopNganSach>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vKhoanNopNganSach", "TCTS");

            entity.Property(e => e.MaKhoanNop).HasMaxLength(50);
            entity.Property(e => e.NamTaiChinh).HasColumnType("text");
            entity.Property(e => e.TenKhoanNopNganSach).HasMaxLength(200);
        });

        modelBuilder.Entity<VKhoanTrichLapQuy>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vKhoanTrichLapQuy", "TCTS");

            entity.Property(e => e.MaKhoanTrichLapQuy).HasMaxLength(50);
            entity.Property(e => e.NamTaiChinh).HasColumnType("text");
            entity.Property(e => e.TenKhoanTrichLapQuy).HasMaxLength(200);
        });

        modelBuilder.Entity<VKhoiNganhDaoTao>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vKhoiNganhDaoTao", "NDT");

            entity.Property(e => e.KhoiNganhDaoTao).HasMaxLength(50);
        });

        modelBuilder.Entity<VKiTucXa>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vKiTucXa", "CSVC");

            entity.Property(e => e.HinhThucSoHuu).HasMaxLength(50);
            entity.Property(e => e.MaKyTucxa).HasMaxLength(50);
            entity.Property(e => e.NamDuaVaoSuDung).HasColumnType("text");
            entity.Property(e => e.TinhTrangCoSoVatChat).HasMaxLength(200);
        });

        modelBuilder.Entity<VKyLuatNguoiHoc>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vKyLuatNguoiHoc", "NH");

            entity.Property(e => e.CapQuyetDinh).HasMaxLength(200);
            entity.Property(e => e.Ho).HasMaxLength(50);
            entity.Property(e => e.LoaiKyLuat).HasMaxLength(200);
            entity.Property(e => e.LyDo).HasColumnType("text");
            entity.Property(e => e.NamBiKyLuat).HasColumnType("text");
            entity.Property(e => e.SoCccd)
                .HasMaxLength(50)
                .HasColumnName("SoCCCD");
            entity.Property(e => e.SoQuyetDinh).HasMaxLength(50);
            entity.Property(e => e.Ten).HasMaxLength(50);
        });

        modelBuilder.Entity<VLichSuDoiTenTruong>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vLichSuDoiTenTruong", "CSGD");

            entity.Property(e => e.SoQuyetDinhDoiTen).HasMaxLength(200);
            entity.Property(e => e.TenTruongCu).HasMaxLength(200);
            entity.Property(e => e.TenTruongCuTiengAnh).HasMaxLength(200);
        });

        modelBuilder.Entity<VLoaiHinhDaoTaoKhacDuocChoPhepMoNganh>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vLoaiHinhDaoTaoKhacDuocChoPhepMoNganh", "NDT");

            entity.Property(e => e.LoaiHinhDaoTao).HasMaxLength(200);
            entity.Property(e => e.NganhDaoTao).HasMaxLength(200);
            entity.Property(e => e.SoQuyetDinhChoPhep).HasMaxLength(50);
        });

        modelBuilder.Entity<VLoaiThuChi>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vLoaiThuChi", "TCTS");

            entity.Property(e => e.MaLoaiThuChi).HasMaxLength(50);
            entity.Property(e => e.MoTa).HasColumnType("text");
            entity.Property(e => e.PhanLoaiThuChi).HasMaxLength(50);
            entity.Property(e => e.TenLoaiThuChi).HasMaxLength(200);
        });

        modelBuilder.Entity<VLuuHocSinhSinhVienNn>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vLuuHocSinhSinhVienNN", "HTQT");

            entity.Property(e => e.LoaiLuuHocSinh).HasMaxLength(200);
            entity.Property(e => e.NguonKinhPhiChoLuuHocSinh).HasMaxLength(50);
        });

        modelBuilder.Entity<VNamApdungChuongTrinh>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vNamApdungChuongTrinh", "CTDT");

            entity.Property(e => e.MaChuongTrinhDaoTao).HasMaxLength(200);
            entity.Property(e => e.TenChuongTrinh).HasMaxLength(200);
        });

        modelBuilder.Entity<VNgonNguGiangDay>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vNgonNguGiangDay", "CTDT");

            entity.Property(e => e.MaChuongTrinhDaoTao).HasMaxLength(200);
            entity.Property(e => e.NgoaiNgu).HasMaxLength(50);
            entity.Property(e => e.TenChuongTrinh).HasMaxLength(200);
            entity.Property(e => e.TenKhungNangLucNgoaiNgu).HasMaxLength(50);
        });

        modelBuilder.Entity<VNguoi>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vNguoi");

            entity.Property(e => e.ChucDanhKhoaHoc).HasMaxLength(200);
            entity.Property(e => e.DanToc).HasMaxLength(50);
            entity.Property(e => e.Expr1).HasMaxLength(200);
            entity.Property(e => e.HangThuongBinh).HasMaxLength(50);
            entity.Property(e => e.Ho).HasMaxLength(50);
            entity.Property(e => e.HoGiaDinhChinhSach).HasMaxLength(200);
            entity.Property(e => e.NganhDaoTao).HasMaxLength(200);
            entity.Property(e => e.NgoaiNgu).HasMaxLength(50);
            entity.Property(e => e.SoCccd)
                .HasMaxLength(50)
                .HasColumnName("SoCCCD");
            entity.Property(e => e.Ten).HasMaxLength(50);
            entity.Property(e => e.TenKhungNangLucNgoaiNgu).HasMaxLength(50);
            entity.Property(e => e.TenNuoc).HasMaxLength(200);
            entity.Property(e => e.TenTrinhDoLyLuanChinhTri).HasMaxLength(50);
            entity.Property(e => e.TonGiao).HasMaxLength(50);
            entity.Property(e => e.TrinhDoDaoTao).HasMaxLength(200);
            entity.Property(e => e.TrinhDoQuanLyNhaNuoc).HasMaxLength(200);
            entity.Property(e => e.TrinhDoTinHoc).HasMaxLength(200);
        });

        modelBuilder.Entity<VNguoiHocVayTinDung>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vNguoiHocVayTinDung", "NH");

            entity.Property(e => e.DiaChi).HasColumnType("text");
            entity.Property(e => e.Ho).HasMaxLength(50);
            entity.Property(e => e.SoCccd)
                .HasMaxLength(50)
                .HasColumnName("SoCCCD");
            entity.Property(e => e.Ten).HasMaxLength(50);
            entity.Property(e => e.TenToChucTinDung).HasColumnType("text");
            entity.Property(e => e.TinhTrangVay).HasMaxLength(50);
        });

        modelBuilder.Entity<VNhiemVuKhcn>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vNhiemVuKHCN", "KHCN");

            entity.Property(e => e.CoQuanChuQuan).HasMaxLength(200);
            entity.Property(e => e.CoQuanChuTri).HasMaxLength(200);
            entity.Property(e => e.DanhGiaKetQuaNhiemVu).HasMaxLength(200);
            entity.Property(e => e.LinhVucNghienCuu).HasMaxLength(200);
            entity.Property(e => e.LoaiNhiemVu).HasMaxLength(50);
            entity.Property(e => e.MaNhiemVu).HasMaxLength(50);
            entity.Property(e => e.NguoiChuTri).HasMaxLength(200);
            entity.Property(e => e.NguonKinhPhi).HasMaxLength(200);
            entity.Property(e => e.PhanCapNhiemVu).HasMaxLength(50);
            entity.Property(e => e.SanPhamChinhCuaNhiemVu).HasMaxLength(200);
            entity.Property(e => e.TenNhiemVu).HasMaxLength(300);
            entity.Property(e => e.TinhTrangNhiemVu).HasMaxLength(50);
            entity.Property(e => e.TongKinhPhiCuaNhiemVu).HasColumnType("text");
        });

        modelBuilder.Entity<VNhomNganhDaoTao>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vNhomNganhDaoTao", "NDT");

            entity.Property(e => e.LinhVucDaoTao).HasMaxLength(200);
            entity.Property(e => e.NganhDaoTao).HasMaxLength(200);
            entity.Property(e => e.NhomNganh).HasMaxLength(200);
        });

        modelBuilder.Entity<VNhomNghienCuuManh>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vNhomNghienCuuManh", "KHCN");

            entity.Property(e => e.CacNhiemVuNckh)
                .HasMaxLength(50)
                .HasColumnName("CacNhiemVuNCKH");
            entity.Property(e => e.MaNhomNghienCuuManh).HasMaxLength(50);
            entity.Property(e => e.SoQuyetDinhThanhLap).HasMaxLength(50);
            entity.Property(e => e.TenNhomNghienCuuManh).HasMaxLength(300);
            entity.Property(e => e.ToChucBanHanhQuyetDinh).HasMaxLength(50);
        });

        modelBuilder.Entity<VPhongHocGiangDuongHoiTruong>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vPhongHocGiangDuongHoiTruong", "CSVC");

            entity.Property(e => e.HinhThucSoHuu).HasMaxLength(50);
            entity.Property(e => e.LoaiDeAnChuongTrinh).HasMaxLength(200);
            entity.Property(e => e.LoaiPhongHoc).HasMaxLength(200);
            entity.Property(e => e.MaPhongHocGiangDuongHoiTruong).HasMaxLength(50);
            entity.Property(e => e.NamDuaVaoSuDung).HasColumnType("text");
            entity.Property(e => e.PhanLoaiCsvc)
                .HasMaxLength(200)
                .HasColumnName("PhanLoaiCSVC");
            entity.Property(e => e.TenPhongHocGiangDuongHoiTruong)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.TinhTrangCoSoVatChat).HasMaxLength(200);
        });

        modelBuilder.Entity<VPhongThiNghiem>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vPhongThiNghiem", "CSVC");

            entity.Property(e => e.LinhVucNghienCuu).HasMaxLength(200);
            entity.Property(e => e.LoaiPhongThiNghiem).HasMaxLength(200);
            entity.Property(e => e.MaCongTrinh).HasMaxLength(50);
            entity.Property(e => e.MucDoDapUngNhuCauNckh)
                .HasMaxLength(200)
                .HasColumnName("MucDoDapUngNhuCauNCKH");
            entity.Property(e => e.NamDuaVaoSuDung).HasColumnType("text");
        });

        modelBuilder.Entity<VPhongThucHanh>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vPhongThucHanh", "CSVC");

            entity.Property(e => e.LinhVucNghienCuu).HasMaxLength(200);
            entity.Property(e => e.MaCongTrinh).HasMaxLength(50);
            entity.Property(e => e.MucDoDapUngNhuCauNckh)
                .HasMaxLength(200)
                .HasColumnName("MucDoDapUngNhuCauNCKH");
            entity.Property(e => e.NamDuaVaoSuDung).HasColumnType("text");
        });

        modelBuilder.Entity<VQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai", "CTDT");

            entity.Property(e => e.HinhThucDaoTao).HasMaxLength(200);
            entity.Property(e => e.LoaiQuyetDinh).HasMaxLength(200);
            entity.Property(e => e.MaChuongTrinhDaoTao).HasMaxLength(200);
            entity.Property(e => e.SoQuyetDinh).HasMaxLength(200);
            entity.Property(e => e.TenChuongTrinh).HasMaxLength(200);
        });

        modelBuilder.Entity<VSachDaXuatBan>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vSachDaXuatBan", "KHCN");

            entity.Property(e => e.DangTaiLieu).HasMaxLength(50);
            entity.Property(e => e.LoaiSachTapChi).HasMaxLength(200);
            entity.Property(e => e.MaChuanIsbn)
                .HasMaxLength(50)
                .HasColumnName("MaChuanISBN");
            entity.Property(e => e.MaNhiemVu).HasMaxLength(50);
            entity.Property(e => e.MaSach).HasMaxLength(50);
            entity.Property(e => e.NamViet).HasColumnType("text");
            entity.Property(e => e.NamXuatBan).HasColumnType("text");
            entity.Property(e => e.Nxb)
                .HasMaxLength(50)
                .HasColumnName("NXB");
            entity.Property(e => e.TenSach).HasMaxLength(300);
        });

        modelBuilder.Entity<VTaiSanDonVi>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vTaiSanDonVi", "TCTS");

            entity.Property(e => e.MaLoaiTaiSan).HasMaxLength(50);
            entity.Property(e => e.MoTa).HasColumnType("text");
            entity.Property(e => e.NamTaiChinh).HasColumnType("text");
            entity.Property(e => e.TenLoaiTaiSan).HasMaxLength(200);
        });

        modelBuilder.Entity<VTaiSanTriTue>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vTaiSanTriTue", "KHCN");

            entity.Property(e => e.ChuSoHuu).HasMaxLength(50);
            entity.Property(e => e.CongBoBang).HasMaxLength(50);
            entity.Property(e => e.Ipc)
                .HasMaxLength(50)
                .HasColumnName("IPC");
            entity.Property(e => e.LoaiTaiSanTriTue).HasMaxLength(50);
            entity.Property(e => e.MaGiaiPhapSangChe).HasMaxLength(50);
            entity.Property(e => e.MaNhiemVu).HasMaxLength(50);
            entity.Property(e => e.NamDuocChapNhanDonHopLe).HasColumnType("text");
            entity.Property(e => e.NguoiChuTri).HasMaxLength(50);
            entity.Property(e => e.QuyetDinhCapBangGiayChungNhan).HasMaxLength(200);
            entity.Property(e => e.TacGiaSangCheGiaiPhap).HasMaxLength(50);
            entity.Property(e => e.TenTaiSanTriTue).HasMaxLength(300);
            entity.Property(e => e.ToChucCapBang).HasMaxLength(200);
            entity.Property(e => e.ToChucCapBangGiayChungNhan).HasMaxLength(200);
        });

        modelBuilder.Entity<VTapChiKhoaHoc>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vTapChiKhoaHoc", "KHCN");

            entity.Property(e => e.LinhVucNghienCuu).HasMaxLength(200);
            entity.Property(e => e.MaChuanIssn)
                .HasMaxLength(50)
                .HasColumnName("MaChuanISSN");
            entity.Property(e => e.MaTapChi).HasMaxLength(50);
            entity.Property(e => e.TapChiTrongNuoc).HasMaxLength(200);
            entity.Property(e => e.TenTapChiTiengAnh).HasMaxLength(300);
            entity.Property(e => e.TenTapChiTiengViet).HasMaxLength(300);
        });

        modelBuilder.Entity<VThanhPhanThamGiaDoanCongTac>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vThanhPhanThamGiaDoanCongTac", "HTQT");

            entity.Property(e => e.MaCanBo).HasMaxLength(50);
            entity.Property(e => e.MaDoanCongTac).HasMaxLength(50);
            entity.Property(e => e.VaiTroThamGia).HasMaxLength(50);
        });

        modelBuilder.Entity<VThietBiPtnThtren500Tr>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vThietBiPTN_THTren500Tr", "CSVC");

            entity.Property(e => e.HangSanXuat).HasMaxLength(200);
            entity.Property(e => e.MaCongTrinh).HasMaxLength(50);
            entity.Property(e => e.MaThietBi).HasMaxLength(50);
            entity.Property(e => e.NamDuaVaoSuDung).HasColumnType("text");
            entity.Property(e => e.NamSanXuat).HasColumnType("text");
            entity.Property(e => e.TenNuoc).HasMaxLength(200);
            entity.Property(e => e.TenThietBi).HasMaxLength(200);
        });

        modelBuilder.Entity<VThoaThuanHopTacQuocTe>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vThoaThuanHopTacQuocTe", "HTQT");

            entity.Property(e => e.MaThoaThuan).HasMaxLength(50);
            entity.Property(e => e.SoVanBanKyKet).HasMaxLength(50);
            entity.Property(e => e.TenNuoc).HasMaxLength(200);
            entity.Property(e => e.TenThoaThuan).HasMaxLength(200);
            entity.Property(e => e.TenToChuc).HasMaxLength(200);
        });

        modelBuilder.Entity<VThongTinHocBong>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vThongTinHocBong", "NH");

            entity.Property(e => e.DonViTaiTro).HasColumnType("text");
            entity.Property(e => e.Ho).HasMaxLength(50);
            entity.Property(e => e.LoaiHocBong).HasMaxLength(200);
            entity.Property(e => e.SoCccd)
                .HasMaxLength(50)
                .HasColumnName("SoCCCD");
            entity.Property(e => e.Ten).HasMaxLength(50);
            entity.Property(e => e.TenHocBong).HasColumnType("text");
        });

        modelBuilder.Entity<VThongTinHocTapNghienCuuSinh>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vThongTinHocTapNghienCuuSinh", "NH");

            entity.Property(e => e.ChuongTrinhDaoTao).HasMaxLength(200);
            entity.Property(e => e.DoiTuongDauVao).HasMaxLength(200);
            entity.Property(e => e.Expr1).HasMaxLength(50);
            entity.Property(e => e.Ho).HasMaxLength(50);
            entity.Property(e => e.LoaiHinhDaoTao).HasMaxLength(200);
            entity.Property(e => e.LoaiTotNghiep).HasMaxLength(50);
            entity.Property(e => e.MaCanBo).HasMaxLength(50);
            entity.Property(e => e.MaHocVien).HasMaxLength(50);
            entity.Property(e => e.QuyChuanNguoiHuongDan).HasColumnType("text");
            entity.Property(e => e.SinhVienNam).HasMaxLength(50);
            entity.Property(e => e.SoCccd)
                .HasMaxLength(50)
                .HasColumnName("SoCCCD");
            entity.Property(e => e.SoQuyetDinhCongNhan).HasMaxLength(50);
            entity.Property(e => e.SoQuyetDinhThanhLapHoiDongBaoVeCapCoSo).HasMaxLength(50);
            entity.Property(e => e.SoQuyetDinhThanhLapHoiDongBaoVeCapTruong).HasMaxLength(50);
            entity.Property(e => e.SoQuyetDinhThoiHoc).HasMaxLength(50);
            entity.Property(e => e.Ten).HasMaxLength(50);
            entity.Property(e => e.TenLuanVan).HasColumnType("text");
            entity.Property(e => e.TrangThaiHoc).HasMaxLength(50);
        });

        modelBuilder.Entity<VThongTinHocTapSinhVien>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vThongTinHocTapSinhVien", "NH");

            entity.Property(e => e.BangTotNghiepLienThong).HasMaxLength(50);
            entity.Property(e => e.ChuongTrinhDaoTao).HasMaxLength(200);
            entity.Property(e => e.DangOnoiTru)
                .HasMaxLength(50)
                .HasColumnName("DangONoiTru");
            entity.Property(e => e.DoiTuongDauVao).HasMaxLength(200);
            entity.Property(e => e.Ho).HasMaxLength(50);
            entity.Property(e => e.KetQuaTuyenSinh).HasColumnType("text");
            entity.Property(e => e.Khoa).HasMaxLength(200);
            entity.Property(e => e.LoaiHinhDaoTao).HasMaxLength(200);
            entity.Property(e => e.LoaiTotNghiep).HasMaxLength(50);
            entity.Property(e => e.Lop).HasMaxLength(50);
            entity.Property(e => e.MaHocVien).HasMaxLength(50);
            entity.Property(e => e.SinhVienNam).HasMaxLength(50);
            entity.Property(e => e.SoCccd)
                .HasMaxLength(50)
                .HasColumnName("SoCCCD");
            entity.Property(e => e.SoQuyetDinhThoiHoc).HasMaxLength(50);
            entity.Property(e => e.SoQuyetDinhTotNghiep).HasMaxLength(50);
            entity.Property(e => e.SoQuyetDinhTrungTuyen).HasMaxLength(50);
            entity.Property(e => e.Ten).HasMaxLength(50);
            entity.Property(e => e.TrangThaiHoc).HasMaxLength(50);
        });

        modelBuilder.Entity<VThongTinHopTac>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vThongTinHopTac", "HTQT");

            entity.Property(e => e.DonViTrienKhai).HasMaxLength(200);
            entity.Property(e => e.HinhThucHopTac).HasMaxLength(200);
            entity.Property(e => e.MaHopTac).HasMaxLength(50);
            entity.Property(e => e.SanPhamChinh).HasMaxLength(200);
            entity.Property(e => e.TenThoaThuan).HasMaxLength(200);
        });

        modelBuilder.Entity<VThongTinKiemDinhCuaChuongTrinh>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vThongTinKiemDinhCuaChuongTrinh", "CTDT");

            entity.Property(e => e.KetQuaKiemDinh).HasMaxLength(200);
            entity.Property(e => e.MaChuongTrinhDaoTao).HasMaxLength(200);
            entity.Property(e => e.SoQuyetDinh).HasMaxLength(200);
            entity.Property(e => e.TenChuongTrinh).HasMaxLength(200);
            entity.Property(e => e.ToChucKiemDinh).HasMaxLength(200);
        });

        modelBuilder.Entity<VThongTinLinhVucDaoTao>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vThongTinLinhVucDaoTao", "NDT");

            entity.Property(e => e.KhoiNganhDaoTao).HasMaxLength(50);
            entity.Property(e => e.LinhVucDaoTao).HasMaxLength(200);
        });

        modelBuilder.Entity<VThongTinNguoiHocGdtc>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vThongTinNguoiHocGDTC", "NH");

            entity.Property(e => e.Ho).HasMaxLength(50);
            entity.Property(e => e.KetQuaHocTap).HasColumnType("text");
            entity.Property(e => e.SoCccd)
                .HasMaxLength(50)
                .HasColumnName("SoCCCD");
            entity.Property(e => e.Ten).HasMaxLength(50);
            entity.Property(e => e.TieuChuanDanhGiaXepLoaiTheLuc).HasColumnType("text");
        });

        modelBuilder.Entity<VThongTinViPham>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vThongTinViPham", "NH");

            entity.Property(e => e.HinhThucXuLy).HasColumnType("text");
            entity.Property(e => e.Ho).HasMaxLength(50);
            entity.Property(e => e.LoaiViPham).HasMaxLength(50);
            entity.Property(e => e.NoiDungViPham).HasColumnType("text");
            entity.Property(e => e.SoCccd)
                .HasMaxLength(50)
                .HasColumnName("SoCCCD");
            entity.Property(e => e.Ten).HasMaxLength(50);
        });

        modelBuilder.Entity<VThongTinViecLamSauTotNghiep>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vThongTinViecLamSauTotNghiep", "NH");

            entity.Property(e => e.DonViTuyenDung).HasColumnType("text");
            entity.Property(e => e.HinhThucTuyenDung).HasMaxLength(50);
            entity.Property(e => e.Ho).HasMaxLength(50);
            entity.Property(e => e.SoCccd)
                .HasMaxLength(50)
                .HasColumnName("SoCCCD");
            entity.Property(e => e.Ten).HasMaxLength(50);
            entity.Property(e => e.TenDonViCapBang).HasColumnType("text");
            entity.Property(e => e.ViTriViecLam).HasMaxLength(200);
        });

        modelBuilder.Entity<VThuVienTrungTamHocLieu>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vThuVienTrungTamHocLieu", "CSVC");

            entity.Property(e => e.HinhThucSoHuu).HasMaxLength(50);
            entity.Property(e => e.MaThuVienTrungTamHocLieu).HasMaxLength(50);
            entity.Property(e => e.NamDuaVaoSuDung).HasColumnType("text");
            entity.Property(e => e.SoLuonngThuVienDienTuLienKetNn).HasColumnName("SoLuonngThuVienDienTuLienKetNN");
            entity.Property(e => e.TenThuVienTrungTamHocLieu).HasMaxLength(200);
            entity.Property(e => e.TinhTrangCoSoVatChat).HasMaxLength(200);
        });

        modelBuilder.Entity<VToChucHopTacDoanhNghiep>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vToChucHopTacDoanhNghiep", "HTDN");

            entity.Property(e => e.KetQuaHopTac).HasMaxLength(50);
            entity.Property(e => e.LoaiDeAnChuongTrinh).HasMaxLength(200);
            entity.Property(e => e.MaToChucHopTacDoanhNghiep).HasMaxLength(50);
            entity.Property(e => e.NoiDungHopTac).HasMaxLength(200);
            entity.Property(e => e.TenToChucHopTacDoanhNghiep).HasMaxLength(200);
        });

        modelBuilder.Entity<VToChucHopTacQuocTe>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vToChucHopTacQuocTe", "HTQT");

            entity.Property(e => e.KetQuaHopTac).HasMaxLength(200);
            entity.Property(e => e.LoaiToChuc).HasMaxLength(200);
            entity.Property(e => e.MaHopTac).HasMaxLength(50);
            entity.Property(e => e.TenNuoc).HasMaxLength(200);
            entity.Property(e => e.TenToChuc).HasMaxLength(200);
        });

        modelBuilder.Entity<VToChucKiemDinh>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vToChucKiemDinh", "CSGD");

            entity.Property(e => e.KetQuaKiemDinh).HasMaxLength(200);
            entity.Property(e => e.SoQuyetDinhKiemDinh).HasMaxLength(200);
            entity.Property(e => e.ToChucKiemDinh).HasMaxLength(200);
        });

        modelBuilder.Entity<VVanBanTuChu>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vVanBanTuChu", "CSGD");

            entity.Property(e => e.CoQuanQuyetDinhBanHanh).HasMaxLength(200);
            entity.Property(e => e.LoaiVanBan).HasMaxLength(200);
            entity.Property(e => e.QuyetDinhBanHanh).HasMaxLength(200);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

public DbSet<C500Hemis.Models.VCoCauToChuc2> VCoCauToChuc2 { get; set; } = default!;

public DbSet<C500Hemis.Models._VDeAnDuAnChuongTrinh> _VDeAnDuAnChuongTrinh { get; set; } = default!;

public DbSet<C500Hemis.Models._VDoanCongTac> _VDoanCongTac { get; set; } = default!;

public DbSet<C500Hemis.Models._VGvduocCuDiDaoTao> _VGvduocCuDiDaoTao { get; set; } = default!;


}
