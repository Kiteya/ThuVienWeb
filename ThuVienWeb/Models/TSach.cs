using System;
using System.Collections.Generic;

namespace ThuVienWeb.Models;

public partial class TSach
{
    public string MaSach { get; set; } = null!;

    public string? TenSach { get; set; }

    public string? MaLoai { get; set; }

    public string? MaNgonNgu { get; set; }

    public string? MaNxb { get; set; }

    public string? TacGia { get; set; }

    public string? NamXb { get; set; }

    public string? LanXb { get; set; }

    public string? GioiThieu { get; set; }

    public string? TongSoTrang { get; set; }

    public string? Tap { get; set; }

    public string? TongSoTap { get; set; }

    public double? GiaTriSach { get; set; }

    public string? FileAnh { get; set; }

    public virtual TLoaiSach? MaLoaiNavigation { get; set; }

    public virtual TNgonNgu? MaNgonNguNavigation { get; set; }

    public virtual TNhaXb? MaNxbNavigation { get; set; }

    public virtual ICollection<TBanSaoSach> TBanSaoSaches { get; set; } = new List<TBanSaoSach>();
}
