using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.Services
{
    public class SimServices : ISimServices
    {
        ShoppingDbContext _dbContext;

        public SimServices()
        {
        }

        public SimServices(ShoppingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Create(Sim sim)
        {
            try
            {
                _dbContext.Sims.Add(sim);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Sim sim)
        {
            try
            {
                _dbContext.Sims.Remove(sim);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Sim> GetAll()
        {
            return _dbContext.Sims.ToList();
        }

        public bool Update(Sim sim)
        {
            try
            {
                _dbContext.Sims.Update(sim);
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
