using System;
using System.Collections.Generic;
using System.ComponentModel;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

//Dương Minh Vũ
public partial class TbKiTucXa
{
    [DisplayName("Id Kí túc xá")]
    public int IdKiTucXa { get; set; }


    [DisplayName("Mã ký túc xá")]
    public string? MaKyTucxa { get; set; }


    [DisplayName("Hình thức sở hữu")]
    public int? IdHinhThucSoHuu { get; set; }


    [DisplayName("Tổng chỗ ở")]
    public int? TongChoO { get; set; }


    [DisplayName("Tổng diện tích")]

    public double? TongDienTich { get; set; }


    [DisplayName("Tình trạng CSVC")]
    public int? IdTinhTrangCsvc { get; set; }


    [DisplayName("Số phòng")]
    public int? SoPhong { get; set; }


    [DisplayName("Năm đưa vào sử dụng")]
    public int? NamDuaVaoSuDung { get; set; }


    [DisplayName("Hình thức sở hữu")]
    public virtual DmHinhThucSoHuu? IdHinhThucSoHuuNavigation { get; set; }


    [DisplayName("Tình trạng CSVC")]
    public virtual DmTinhTrangCoSoVatChat? IdTinhTrangCsvcNavigation { get; set; }
}