using Assgment_Nhom3_WebBanDienThoai.IServices;
using Assgment_Nhom3_WebBanDienThoai.Models;
using Assgment_Nhom3_WebBanDienThoai.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonChiTietController : ControllerBase
    {
        private readonly IHoaDonChiTietServices _hoaDonChiTiet;
        private IChiTietSanPhamServices ctsp;
        private IImeiServices mei;
        ShoppingDbContext context = new ShoppingDbContext();
        public HoaDonChiTietController()
        {
            mei = new ImeiServices();
            ctsp = new  ChiTietSanPhamServices();
            _hoaDonChiTiet = new HoaDonChiTietServices();
        }
        // GET: api/<HoaDonChiTietController>
        [HttpGet("Get-all-hoaDonChiTiet")]
        public IEnumerable<HoaDonChiTiet> GetAll()
        {
            return _hoaDonChiTiet.GetAllHoaDonChiTiets();
        }

        // GET api/<HoaDonChiTietController>/5
        [HttpPost("Create-HoaDonChiTiet")]
        public bool CreateHoaDonChiTiet(Guid IdHoaDon, Guid IdChiTietSp, int SoLuong, int TrangThai)
        {
            var a = mei.GetAll().Where(a=>a.IdCtsp == IdChiTietSp).ToList();
            var ct = ctsp.GetAll().FirstOrDefault(a => a.Id == IdChiTietSp);
            var hd = _hoaDonChiTiet.GetAllHoaDonChiTiets().FirstOrDefault(a=>a.IdChiTietSp == IdChiTietSp && a.IdHoaDon ==  IdHoaDon  );
            if (SoLuong > a.Count)
            {
                BadRequest("soluong qua lon");
                return false;
            }
            else
            {
                if (hd == null)
                {
                    HoaDonChiTiet hoaDonChiTiet = new HoaDonChiTiet();
                    hoaDonChiTiet.Id = Guid.NewGuid();
                    hoaDonChiTiet.IdHoaDon = IdHoaDon;
                    hoaDonChiTiet.IdChiTietSp = IdChiTietSp;
                    hoaDonChiTiet.SoLuong = SoLuong;
                    hoaDonChiTiet.Gia = Convert.ToInt64(ctsp.GetAll().FirstOrDefault(a => a.Id == IdChiTietSp).DonGia);
                    hoaDonChiTiet.TrangThai = TrangThai;
                    return _hoaDonChiTiet.CreateHoaDonChiTiet(hoaDonChiTiet);

                }
                else
                {

                    var hds = _hoaDonChiTiet.GetAllHoaDonChiTiets().FirstOrDefault(a => a.IdChiTietSp == IdChiTietSp && a.IdHoaDon == IdHoaDon);
                    hds.SoLuong += SoLuong;
                    hds.Gia = Convert.ToInt64(ct.DonGia * hds.SoLuong);
                   
                    return _hoaDonChiTiet.UpdateHoaDonChiTiet(hds);
                }

            }



        }

        // POST api/<HoaDonChiTietController>
        [HttpDelete("Delete-HoaDonChiTiet-{id}")]
        public bool Post(Guid id)
        {
            return _hoaDonChiTiet.DeleteHoaDonChiTiet(id);
        }

        // PUT api/<HoaDonChiTietController>/5
        [HttpPut("Update-HoaDonChiTiet-{id}")]
        public bool Put(Guid id,Guid IdHoaDon, Guid IdChiTietSp, int SoLuong, long Gia, int TrangThai)
        {
            HoaDonChiTiet hoaDonChiTiet = new HoaDonChiTiet();
            hoaDonChiTiet.Id = id;
            hoaDonChiTiet.IdHoaDon = IdHoaDon;
            hoaDonChiTiet.IdChiTietSp = IdChiTietSp;
            hoaDonChiTiet.SoLuong = SoLuong;
            hoaDonChiTiet.TrangThai = TrangThai;
            return _hoaDonChiTiet.UpdateHoaDonChiTiet(hoaDonChiTiet);
        }

        // DELETE api/<HoaDonChiTietController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
