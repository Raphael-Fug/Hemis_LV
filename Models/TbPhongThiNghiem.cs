using C500Hemis.Models.DM;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace C500Hemis.Models;

public partial class TbPhongThiNghiem
{
    [DisplayName("STT ")]
    [Range(1, int.MaxValue, ErrorMessage = "STT phải là số dương.")]
    public int IdPhongThiNghiem { get; set; }
    [DisplayName("STT Công trình")]

    public int? IdCongTrinhCsvc { get; set; }
    [DisplayName("STT Loại phòng thí nghiệm ")]

    public int? IdLoaiPhongThiNghiem { get; set; }
    [DisplayName("STT Lĩnh vực ")]

    public int? IdLinhVuc { get; set; }
    [DisplayName("Mức độ đáp ứng nhu cầu NCKH ")]

    public string? MucDoDapUngNhuCauNckh { get; set; }
    [DisplayName("Năm đưa vào sử dụng ")]

    public string? NamDuaVaoSuDung { get; set; }
    [DisplayName("Công trình cơ sở vật chất ")]

    public virtual TbCongTrinhCoSoVatChat? IdCongTrinhCsvcNavigation { get; set; }
    [DisplayName("Lĩnh vực ")]

    public virtual DmLinhVucNghienCuu? IdLinhVucNavigation { get; set; }
    [DisplayName("Loại phòng thí nghiệm ")]

    public virtual DmLoaiPhongThiNghiem? IdLoaiPhongThiNghiemNavigation { get; set; }
}