using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.Services
{
    public class GiamGiaServices : IGiamGiaServices
    {
        ShoppingDbContext _dbContext;
        public GiamGiaServices()
        {
            this._dbContext = new ShoppingDbContext();    
        }
        public bool Create(GiamGia gh)
        {
            try
            {
                _dbContext.GiamGias.Add(gh);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(GiamGia gh)
        {
            try
            {
                _dbContext.GiamGias.Remove(gh);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<GiamGia> GetAll()
        {
            return _dbContext.GiamGias.ToList();
        }

        public bool Update(GiamGia gh)
        {
            try
            {
                _dbContext.GiamGias.Update(gh);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
