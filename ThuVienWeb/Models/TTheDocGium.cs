using System;
using System.Collections.Generic;

namespace ThuVienWeb.Models;

public partial class TTheDocGium
{
    public string MaThe { get; set; } = null!;

    public string? MaDg { get; set; }

    public DateTime? NgayBatDau { get; set; }

    public DateTime? NgayKhoaThe { get; set; }

    public string? Anh { get; set; }

    public virtual TDocGium? MaDgNavigation { get; set; }

    public virtual ICollection<TMuonTra> TMuonTras { get; set; } = new List<TMuonTra>();
}
