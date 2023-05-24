using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.IServices
{
    public interface IPhanQuyenServices
    {
        public bool CreateQuyen(Pin p);
        public bool UpdatePin(Pin p);
        public bool DeletePin(Guid id);
        public List<Pin> GetAllPins();
        public Pin GetPinsById(Guid id);

        public List<Pin> GetPinsByName(string name);
    }
}
