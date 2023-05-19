namespace Assgment_Nhom3_WebBanDienThoai.Models
{
    public class ChipGPU
    {
        public Guid Id { get; set; }

        public string Ten { get; set; }

        public virtual List<ChiTietSanPham> ChiTietSanPhams { get; set; }
    }
}
