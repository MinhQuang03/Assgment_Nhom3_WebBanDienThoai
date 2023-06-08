using Assgment_Nhom3_WebBanDienThoai.Models;
using Microsoft.AspNetCore.Components.Web;

namespace Assgment_Nhom3_WebBanDienThoai.IServices
{
    public interface ILstAnhService
    {
        bool Create(ListAnh obj);
        bool Update(ListAnh obj);
        bool Delete(Guid Id);
        ListAnh GetById(Guid id);
        List<ListAnh> GetAll();
    }
}
