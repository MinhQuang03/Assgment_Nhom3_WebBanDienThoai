using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.Services
{
    public class CongSacServices : ICongSacServices
    {

        private ShoppingDbContext _context;

        public CongSacServices()
        {
            _context = new ShoppingDbContext();
        }
        public bool CreateCongSac(CongSac cs)
        {
            try
            {
                _context.CongSacs.Add(cs);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteCongSac(Guid id)
        {
            try
            {
                var obj = _context.CongSacs.FirstOrDefault(x => x.Id == id);
                _context.CongSacs.Remove(obj);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<CongSac> GetAllCongSacs()
        {
            return _context.CongSacs.ToList();
        }

        public CongSac GetCongSacsById(Guid id)
        {
            return _context.CongSacs.FirstOrDefault(c => c.Id == id);
        }

        public List<CongSac> GetCongSacsByName(string name)
        {
            return _context.CongSacs.Where(c => c.Ten == name).ToList();
        }

        public bool UpdateCongSac(CongSac cs)
        {
            try
            {
                _context.CongSacs.Update(cs);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
