namespace Assgment_Nhom3_WebBanDienThoai.Models
{
    public class NhaSanXuat
    {
        public Guid Id { get; set; }

        public string Ten { get; set; }

        public List<SanPham> SanPhams { get; set; }

    }
}
