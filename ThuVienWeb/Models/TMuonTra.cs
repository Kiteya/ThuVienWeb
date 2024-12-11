using System;
using System.Collections.Generic;

namespace ThuVienWeb.Models;

public partial class TMuonTra
{
    public string MaThe { get; set; } = null!;

    public string MaBanSao { get; set; } = null!;

    public double? DatCoc { get; set; }

    public DateTime? NgayMuon { get; set; }

    public DateTime? NgayPhaiTra { get; set; }

    public DateTime? NgayTra { get; set; }

    public string? TinhTrangSach { get; set; }

    public double? Phat { get; set; }

    public virtual TBanSaoSach MaBanSaoNavigation { get; set; } = null!;

    public virtual TTheDocGium MaTheNavigation { get; set; } = null!;
}
