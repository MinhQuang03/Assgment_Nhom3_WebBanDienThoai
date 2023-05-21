using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.IServices
{
    public interface ISimServices
    {
        List<Sim> GetAll();

        bool Create(Sim sim);

        bool Update(Sim sim);

        bool Delete(Sim sim);
    }
}
