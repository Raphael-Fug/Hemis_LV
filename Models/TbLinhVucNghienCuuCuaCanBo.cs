using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbLinhVucNghienCuuCuaCanBo
{
    [DisplayName(displayName: "ID lĩnh vực nghiên cứu của cán bộ")]
    public int IdLinhVucNghienCuuCuaCanBo { get; set; }
    [DisplayName(displayName: "ID Cán bộ")]
    public int? IdCanBo { get; set; }
    [DisplayName(displayName: "ID lĩnh vực nghiên cứu")]
    public int? IdLinhVucNghienCuu { get; set; }
    [DisplayName(displayName: "Là lĩnh vực nghiên cứu chuyên sâu")]
    public bool? LaLinhVucNghienCuuChuyenSau { get; set; }
    [DisplayName(displayName: "Số năm nghiên cứu")]
    public int? SoNamNghienCuu { get; set; }
    [DisplayName(displayName: "Id cán bộ navigation")]
    public virtual TbCanBo? IdCanBoNavigation { get; set; }
    [DisplayName(displayName: "Id lĩnh vực nghiên cứu navigation")]
    public virtual DmLinhVucNghienCuu? IdLinhVucNghienCuuNavigation { get; set; }
}
