﻿using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;

namespace Assgment_Nhom3_WebBanDienThoai.Services
{
    public class ChipGPUServices : IChipGPUServices
    {
        private ShoppingDbContext _context;
        public ChipGPUServices()
        {
            _context = new ShoppingDbContext();
        }
        public bool Create(ChipGPU obj)
        {
            try
            {
                _context.ChipGPUs.Add(obj);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(Guid id)
        {
            try
            {
                var obj = _context.ChipGPUs.FirstOrDefault(x => x.Id == id);
                _context.ChipGPUs.Remove(obj);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<ChipGPU> GetAll()
        {
            return _context.ChipGPUs.ToList();
        }

<<<<<<< HEAD
<<<<<<< Updated upstream
        public ChipGPU GetChipGPUById(Guid id)
=======
        public ChipGPU GetChipGPUsById(Guid id)
>>>>>>> Stashed changes
=======
        public ChipGPU GetChipGPUById(Guid id)
>>>>>>> b1e186e0a7587ef6700df88d596bd0bba174aaae
        {
            return _context.ChipGPUs.FirstOrDefault(c => c.Id == id);
        }

        public bool Update(ChipGPU obj)
        {
            try
            {
                var x = _context.ChipGPUs.Find(obj.Id);
                x.Ten = obj.Ten;
                _context.ChipGPUs.Update(x);
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
