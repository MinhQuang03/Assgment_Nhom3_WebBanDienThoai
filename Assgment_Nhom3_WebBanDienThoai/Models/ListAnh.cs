﻿namespace Assgment_Nhom3_WebBanDienThoai.Models;

public class ListAnh
{
    public Guid Id { get; set; }

    public Guid IdCtsp { get; set; }

    public string Anh { get; set; }

    public virtual ChiTietSanPham? ChiTietSanPhams { get; set; }
}