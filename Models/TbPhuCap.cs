using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbPhuCap
{
    [Required(ErrorMessage = "Vui long nhap iD")]
    public int IdPhuCap { get; set; }

    [Required(ErrorMessage = "Vui long nhap iD")]
    public int? IdCanBo { get; set; }

    [Required(ErrorMessage = "Vui long nhap so tien ")]
    public int? PhuCapThuHutNghe { get; set; }

    [Required(ErrorMessage = "Vui long nhap %")]
    public int? PhuCapThamNien { get; set; }

    [Required(ErrorMessage = "Vui long nhap %")]
    public int? PhuCapUuDaiNghe { get; set; }

    [Required(ErrorMessage = "Vui long nhap %")]
    public int? PhuCapChucVu { get; set; }

    [Required(ErrorMessage = "Vui long nhap so tien ")]
    public int? PhuCapDocHai { get; set; }

    [Required(ErrorMessage = "Vui long nhap so tien ")]
    public int? PhuCapKhac { get; set; }
    [Required(ErrorMessage = "Vui longf nhap Bac luong")]
    public int? IdBacLuong { get; set; }

    [Required(ErrorMessage = "Vui long nhap %")]
    public int? PhanTramVuotKhung { get; set; }

    [Required(ErrorMessage = "Vui long nhap He so luong")]
    public int? IdHeSoLuong { get; set; }

    [Required(ErrorMessage = "Vui long nhap Ngay Thang Nam")]
    public DateOnly? NgayThangNamHuongLuong { get; set; }

    public virtual DmBacLuong1? IdBacLuongNavigation { get; set; }

    public virtual TbCanBo? IdCanBoNavigation { get; set; }

    public virtual DmHeSoLuong? IdHeSoLuongNavigation { get; set; }
}