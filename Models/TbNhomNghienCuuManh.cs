using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace C500Hemis.Models;

[Table("TbNhomNghienCuuManh")]
public partial class TbNhomNghienCuuManh
{
    [Key]
    public int IdNhomNghienCuuManh { get; set; }

    public string? MaNhomNghienCuuManh { get; set; }

    [Required]

    public string? TenNhomNghienCuuManh { get; set; }


    public string? SoQuyetDinhThanhLap { get; set; }


    public string? ToChucBanHanhQuyetDinh { get; set; }

    [DataType(DataType.Date)]
    public DateOnly? NgayQuyetDinh { get; set; }

    public string? CacNhiemVuNckh { get; set; }

    public string? TomTatKetQuaDatDuoc { get; set; }
}