using System;
using System.Collections.Generic;
using C500Hemis.Models.DM;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace C500Hemis.Models;

public partial class TbThanhPhanThamGiaDoanCongTac
{
    [DisplayName(displayName: "Mã thành phần tham gia đoàn công tác")]
    public int IdThanhPhanThamGiaDoanCongTac { get; set; }
    [Required(ErrorMessage = "Mã Đoàn công tác là bắt buộc.")]
    public int? IdDoanCongTac { get; set; }
    [Required(ErrorMessage = "Mã công tác là bắt buộc.")]
    public int? IdCanBo { get; set; }
    [Required(ErrorMessage = "Vai trò là bắt buộc.")]
    public int? IdVaiTroThamGia { get; set; }


    public virtual TbCanBo? IdCanBoNavigation { get; set; }

    public virtual TbDoanCongTac? IdDoanCongTacNavigation { get; set; }

    public virtual DmVaiTroThamGium? IdVaiTroThamGiaNavigation { get; set; }
}
