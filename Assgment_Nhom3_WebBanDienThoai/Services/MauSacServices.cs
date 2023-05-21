using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.Services
{
    public class MauSacServices : IMauSacServices
    {
        private ShoppingDbContext _context;
        public MauSacServices()
        {
            _context = new ShoppingDbContext();
        }
        public bool CreateMauSac(MauSac ms)
        {
            try
            {
                _context.MauSacs.Add(ms);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteMauSac(Guid id)
        {
            try
            {
                var obj = _context.MauSacs.FirstOrDefault(x => x.Id == id);
                _context.MauSacs.Remove(obj);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<MauSac> GetAllMauSacs()
        {
            return _context.MauSacs.ToList();
        }

        public MauSac GetMauSacsById(Guid id)
        {
            return _context.MauSacs.FirstOrDefault(c => c.Id == id);
        }

        public List<MauSac> GetMauSacsByName(string name)
        {
            return _context.MauSacs.Where(c => c.Ten == name).ToList();
        }

        public bool UpdateMauSac(MauSac ms)
        {
            try
            {
                _context.MauSacs.Update(ms);
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
