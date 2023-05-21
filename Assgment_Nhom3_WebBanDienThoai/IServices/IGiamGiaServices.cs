using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.IServices
{
    public interface IGiamGiaServices
    {
        List<GiamGia> GetAll();

        bool Create(GiamGia gh);

        bool Update(GiamGia gh);

        bool Delete(GiamGia gh);
    }
}
