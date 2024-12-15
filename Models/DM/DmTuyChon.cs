using System;
using System.Collections.Generic;

namespace C500Hemis.Models.DM;

public partial class DmTuyChon
{
    public int IdTuyChon { get; set; }

    public string? TuyChon { get; set; }

    public virtual ICollection<TbCoSoGiaoDuc> TbCoSoGiaoDucHoatDongKhongLoiNhuanNavigations { get; set; } = new List<TbCoSoGiaoDuc>();

    public virtual ICollection<TbCoSoGiaoDuc> TbCoSoGiaoDucTuChuGiaoDucQpanNavigations { get; set; } = new List<TbCoSoGiaoDuc>();

    public virtual ICollection<TbCongTrinhCoSoVatChat> TbCongTrinhCoSoVatChats { get; set; } = new List<TbCongTrinhCoSoVatChat>();

    public virtual ICollection<TbDanhSachNganhDaoTao> TbDanhSachNganhDaoTaoHinhThucDaoTaoTheoChuyenNguNavigations { get; set; } = new List<TbDanhSachNganhDaoTao>();

    public virtual ICollection<TbDanhSachNganhDaoTao> TbDanhSachNganhDaoTaoNganhDaoTaoLienKetNuocNgoaiNavigations { get; set; } = new List<TbDanhSachNganhDaoTao>();

    public virtual ICollection<TbDanhSachNganhDaoTao> TbDanhSachNganhDaoTaoUuTienDaoTaoNhanLucDuLichCnttNavigations { get; set; } = new List<TbDanhSachNganhDaoTao>();

    public virtual ICollection<TbNguoiHocVayTinDung> TbNguoiHocVayTinDungs { get; set; } = new List<TbNguoiHocVayTinDung>();
}
