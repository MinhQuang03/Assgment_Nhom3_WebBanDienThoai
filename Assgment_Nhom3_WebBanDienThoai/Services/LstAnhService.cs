using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.Services
{
    public class LstAnhService : ILstAnhService
    {
        private ShoppingDbContext _context;

        public LstAnhService()
        {
            _context = new ShoppingDbContext();
        }
        public bool Create(ListAnh obj)
        {
            try
            {
                obj.Id = Guid.NewGuid();
                _context.ListAnhs.Add(obj);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Update(ListAnh obj)
        {
            try
            {
                _context.ListAnhs.Update(obj);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(Guid Id)
        {
            try
            {
                var obj = _context.ListAnhs.FirstOrDefault(a => a.Id == Id);
                _context.ListAnhs.Remove(obj);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public ListAnh GetById(Guid id)
        {
            return _context.ListAnhs.FirstOrDefault(c => c.Id == id);
        }

        public List<ListAnh> GetAll()
        {
            return _context.ListAnhs.ToList();
        }
    }
}
