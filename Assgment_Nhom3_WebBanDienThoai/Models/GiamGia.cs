namespace Assgment_Nhom3_WebBanDienThoai.Models
{
    public class GiamGia
    {
        public Guid Id { get; set; }

        public DateTime? NgayBatDau { get; set; }

        public DateTime? NgayKetThuc { get; set; }

        public string GhiChu { get; set; }

        public int TrangThai { get; set; }

        public List<ChiTietSanPham> ChiTietSanPhams { get; set; }
    }
}
